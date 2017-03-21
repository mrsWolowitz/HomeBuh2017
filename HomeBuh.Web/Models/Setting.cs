using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBuh.Models
{
    public class Setting
    {
        public int ID { get; set; }
        /// <summary>
        /// Дата запрета редактирования записей
        /// </summary>
        public DateTime DateProhibitionEditing { get; set; }
    }
}
