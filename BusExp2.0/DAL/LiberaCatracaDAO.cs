﻿using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class LiberaCatracaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarLiberaCatraca(LiberaCatraca p)
        {
            ctx.LiberaCatracas.Add(p);
            ctx.SaveChanges();
        }
        public static LiberaCatraca RetornaPagamentoUsuario(Usuario U) {
            return ctx.LiberaCatracas.FirstOrDefault(x => x.usuario == U);
        }
        public static List<LiberaCatraca> RetornaListaCatraca()
        {
            return ctx.LiberaCatracas.ToList();
        }
    }
}