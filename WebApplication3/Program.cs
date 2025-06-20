﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Net;
using Twilio.TwiML.Voice;
using WebApplication3.AppFilter;
using WebApplication3.AppMiddleware;
using WebApplication3.Models;
using WebApplication3.Services;
using static Serilog.Sinks.MSSqlServer.ColumnOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<TimeElapsedFilter>();
        options.Filters.Add<CatchError>();
    })
    .AddViewLocalization();

#region DI
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();
builder.Services.AddTransient<IMessage, EmailSender>();
builder.Services.AddScoped<TokenService>();
#endregion


#region Auth
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/denied";
});
#endregion


#region Lang with Resources
//builder.Services.AddLocalization(options=>options.ResourcesPath= "Resources");

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCulture = new[]
//    {
//        new CultureInfo("ru-RU"),
//        new CultureInfo("kk-KZ"),
//        new CultureInfo("en-US")
//    };

//    options.DefaultRequestCulture = new RequestCulture(culture: "kk-KZ", uiCulture: "kk-KZ");
//    options.SupportedCultures = supportedCulture;
//    options.SupportedUICultures = supportedCulture;
//});


var serviceProvider = builder.Services.BuildServiceProvider();

var languageService = serviceProvider.GetRequiredService<ILanguageService>();
var languages = languageService.GetLanguages();// kk-KZ
var cultures = languages.Select(language => new CultureInfo(language.Culture)).ToList();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(culture: "kk-KZ", uiCulture: "kk-KZ");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

#endregion




#region Logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341/")
    .WriteTo.File("Logs/hoteAtrLogrs.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer(
    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
    sinkOptions: new MSSqlServerSinkOptions()
    {
        TableName = "Log",
        AutoCreateSqlDatabase = true
    })
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();
#endregion




var app = builder.Build();

var supportedCulture = new[] { "en-US", "kk-KZ", "ru-RU", "uz-Latn-UZ" };
var locaizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("kk-KZ")
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(locaizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<UseTimeElapsed>();
//app.UseRequestLogging();

app.MapControllerRoute(
    name: "contactUs",
    pattern: "contact-us",
    defaults: new { controller = "Home", action = "Contact" });

////rooms → Показать все номера
//app.MapControllerRoute(
//    name: "rooms",
//    pattern: "rooms",
//    defaults: new { controller = "Room", action = "Index" });

////rooms?category=luxury → Показать номера категории "люкс"
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "rooms/category/{category}",
//    defaults: new { controller = "Room", action = "RoomList" });

////rooms ? category = standard & capacity = 2 → Показать стандартные номера на 2 человек
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "rooms/category/{category}/{capacity}/",
//    defaults: new { controller = "Room", action = "RoomList" });

//// rooms/101 → Показать номер с ID 101
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "rooms/{roomId:int}",
//    defaults: new { controller = "Room", action = "RoomDetails" });

////rooms/luxury-101 → Показать номер категории люкс с ID 101
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "booking/luxury-{bookId:int}",
//    defaults: new { controller = "Room", action = "RoomDetails" });



////booking/101 → Показать форму бронирования для номера 101
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "booking/{bookId:int}",
//    defaults: new { controller = "Booking", action = "BookingDetails" });

////profile/bookings → Список всех бронирований пользователя
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "profile/bookings",
//    defaults: new { controller = "Booking", action = "Profiles" });

////profile/bookings/25 → Подробности по бронированию с ID 25
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "profile/bookings/{bookId:int}",
//    defaults: new { controller = "Booking", action = "Profiles" });

////search?checkIn=2025-04-01&checkOut=2025-04-10&guests=2
//app.MapControllerRoute(
//    name: "roomsCategory",
//    pattern: "search/{checkIn:date}/{checkOut:date}/{guests:int}",
//    defaults: new { controller = "Booking", action = "Search" });

//app.MapGet("/Check", () => "Hello world");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
