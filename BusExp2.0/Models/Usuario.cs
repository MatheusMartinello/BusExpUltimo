using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BusExp2._0.Utils;
using System.Web.UI.WebControls;
using BusExp2._0.Models.ProjetoIESB.Models;

namespace BusExp2._0.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string SobreNome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha do usuário")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(5, ErrorMessage = "No mínimo 4 caracteres!")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não coincidem!")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
    }
}