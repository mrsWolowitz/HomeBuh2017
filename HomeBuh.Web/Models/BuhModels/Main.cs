using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBuh.Web.Models.BuhModels
{
    public class Main
    {
        public int Id { get; set; }
        public DateTime DateOperation { get; set; }
        public int Account { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
