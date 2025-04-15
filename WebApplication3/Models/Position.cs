﻿namespace WebApplication3.Models
{
    public class Position
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
