using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace HomeBuh.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Description { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
