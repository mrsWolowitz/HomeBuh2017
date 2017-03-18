using System;

namespace HomeBuh.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public DateTime DateOperation { get; set; }
        public int BuhAccountID { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}