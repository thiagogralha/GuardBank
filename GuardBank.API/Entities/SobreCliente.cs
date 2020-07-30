using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuardBank.API.Entities
{
    public class SobreCliente : Base
    {
        [Key]
        [Display(Name ="Id")]
        public int SobreClienteId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string NomeApelido { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter no máximo 100 caracteres")]
        public string ConfirmarEmail { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 5 e 20 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 20 caracteres")]
        public string Senha { get; set; }

        public string Role { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
