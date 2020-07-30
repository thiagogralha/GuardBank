using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuardBank.API.Entities
{
    public class Endereco : Base
    {
        [Key]
        [Display(Name ="Id")]
        public int EnderecoId { get; set; }
        public int SobreClienteId { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public SobreCliente SobreCliente { get; set; }
    }
}
