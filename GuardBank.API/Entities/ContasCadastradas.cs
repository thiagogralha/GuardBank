using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuardBank.API.Entities
{
    public class ContasCadastradas : Base
    {
        [Key]
        [Display(Name ="Id")]
        public int ContaCadastradaId { get; set; }
        public int SobreClienteId { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public List<SobreCliente> LstSobreCliente { get; set; }

    }
}
