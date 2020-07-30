using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuardBank.API.Entities
{
    public class Perfil : Base
    {
        [Key]
        [Display(Name ="Id")]
        public int PerfilId { get; set; }
        public int SobreClienteId { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public bool AceitaTermo { get; set; }

        public SobreCliente SobreCliente { get; set; }

    }
}
