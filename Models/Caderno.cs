using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Caderno
    {       
        public int Id { get; set; } // [Required] não posso usar ele no id porque o front nao me manda o id.

        [Required]        
        public string Titulo { get; set; }

        [Required]
        [Range(0, 999999.99)] // ele vai de 0 até 999999.99 <- com duas casa após o " . "
        public decimal Valor { get; set; }

        [Required]
        [Range(0, 99999)] // ele vai de 0 até 999999 ( não aceita negativo nem com casa decimal . ) 
        public int NrFolhas { get; set; }

        public Caderno()
        {
        }

        public void copiarDados(Models.Caderno caderno)
        {
            this.Titulo = caderno.Titulo;
            this.Valor = caderno.Valor;
            this.NrFolhas = caderno.NrFolhas;
        }
    }
}