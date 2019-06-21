using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.Utils    
{
    public class Sessao
    {
        private static string carrinhoId = "CARRINHO_ID";
        private static string usuario = "USUARIO";
        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session[carrinhoId] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[carrinhoId] = guid.ToString();
            }
            return HttpContext.Current.Session[carrinhoId].ToString();
        }
        public static string Login(int login)
        {
            HttpContext.Current.Session[usuario] = login;
            return HttpContext.Current.Session[usuario].ToString();
        }
        public static string RetornarUsuario()
        {
            if (HttpContext.Current.Session[usuario] == null)
            {
                return null;
            }
            return HttpContext.Current.Session[usuario].ToString();
        }

        public static void ZerarSessao()
        {
            HttpContext.Current.Session[carrinhoId] = null;
        }
    }
}