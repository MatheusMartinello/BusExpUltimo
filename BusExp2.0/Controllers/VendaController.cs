﻿using BusExp2._0.DAL;
using BusExp2._0.Models;
using BusExp2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
////
namespace BusExp2._0.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Index()
        {
            if (Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
        public ActionResult Pagamento()
        {
            if (Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Pagamento(LiberaCatraca l)
        {
            LiberaCatraca lc = new LiberaCatraca();
            HistoricoPagamentos h = new HistoricoPagamentos();
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
            Credito c = CreditoDAO.CreditoPorUsuario(u);
            l.credito = c;
            l.usuario = u;
            l.ValorPago = "4,20";
            
            CreditoDAO.ModificaValorCredito(-Convert.ToDouble(l.ValorPago),l.credito);
            LiberaCatracaDAO.CadastrarLiberaCatraca(l);
            h.LiberaCatraca = l;
            lc = l;
            //HistoricoGastosDAO.CadastrarLiberaCatraca(h);
            TempData["LiberarCatraca"] = lc;
            return RedirectToAction("Index","Home");
            
        } 
        
    }
}