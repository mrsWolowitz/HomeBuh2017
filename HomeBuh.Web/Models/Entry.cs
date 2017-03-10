using System;

namespace HomeBuh.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public DateTime DateOperation { get; set; }
        public int AccountID { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
