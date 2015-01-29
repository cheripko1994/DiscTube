using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WPP.Models
{
    public class Catagorie
    {
        [Key]
        [DisplayName("Catagorie ID")]
        public int ID { get; set; }

        [DisplayName("Тип")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}