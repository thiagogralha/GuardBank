using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuardBank.API.Entities
{
    public class Objetivo : Base
    {
        [Key]
        [Display(Name ="Id")]
        public int ObjetivoId { get; set; }
        public int SobreClienteId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMensal { get; set; }
        public int Tempo { get; set; }
        public decimal Total { get; set; }
        public List<SobreCliente> LstSobreCliente { get; set; }
    }
}
