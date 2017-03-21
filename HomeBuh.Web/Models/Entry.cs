using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBuh.Models
{
    public class Entry
    {
        public int ID { get; set; }
        /// <summary>
        /// Дата операции из чека
        /// </summary>
        public DateTime DateOperation { get; set; }
        public int BuhAccountID { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Дата создания записи
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateLastUpdate {get; set; }
    }
}