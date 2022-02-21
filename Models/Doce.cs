using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Doce
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public decimal Valor { get; set; }

        public DateTime? DataFab { get; set; }

        public Doce()
        {
        }
    }
}