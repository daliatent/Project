﻿namespace Project.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
    }
}
