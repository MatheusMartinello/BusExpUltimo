using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace BusExp2._0.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarUsuario(Usuario u)
        {
            
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
                return true;
            
        }
        
        public static List<Usuario> RetornarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }
        public static Usuario BuscarUsuario(Usuario u) {
            return (ctx.Usuarios.FirstOrDefault(x => x.Cpf.Equals(u.Cpf)));
        }
        public static Usuario BuscarUsuarioPorId(string id) {
            return ctx.Usuarios.FirstOrDefault(x => x.Sessao.Equals(id)); ;
        }
        public static Usuario BuscarUsuarioPorLoginSenha(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Cpf.Equals(usuario.Cpf) && x.Senha.Equals(usuario.Senha));
        }
    }
}