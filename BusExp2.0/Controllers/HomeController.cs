using BusExp2._0.DAL;
using BusExp2._0.Models;
using BusExp2._0.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BusExp2._0.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
        /*     if(Sessao.RetornarUsuario() == null)
             {
                 return RedirectToAction("Login", "Usuario");
             }
             return View(UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario()));
             */

            return View();
        }
        
        
        public ActionResult VerRota(string enderecoInicial, string enderecoFinal)
        {
            enderecoInicial = enderecoInicial.Replace(" ", "+");
            enderecoFinal = enderecoFinal.Replace(" ", "+");
            RootObject s = new RootObject();
            RootObject s1 = new Models.RootObject();
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + enderecoInicial + "&key=AIzaSyCI5TVZ7WbLV9a55VDiQNTrpChA5h6bAYY";
            WebClient endereco = new WebClient();
            string json = endereco.DownloadString(url);
            byte[] bytes = Encoding.Default.GetBytes(json);
            json = Encoding.UTF8.GetString(bytes);
            s = JsonConvert.DeserializeObject<RootObject>(json);
            string url1 = "https://maps.googleapis.com/maps/api/geocode/json?address=" + enderecoFinal + "&key=AIzaSyCI5TVZ7WbLV9a55VDiQNTrpChA5h6bAYY";
            WebClient endereco1 = new WebClient();
            string json1 = endereco.DownloadString(url);
            byte[] bytes1 = Encoding.Default.GetBytes(json1);
            json1 = Encoding.UTF8.GetString(bytes1);
            s1 = JsonConvert.DeserializeObject<RootObject>(json1);
            LatitudeLongitude EnderecoInicial = new LatitudeLongitude();
            LatitudeLongitude EnderecoFinal = new LatitudeLongitude();
            EnderecoInicial.Lat = s.results[0].geometry.location.lat.ToString();
            EnderecoInicial.Lng = s.results[0].geometry.location.lng.ToString();
            EnderecoFinal.Lat = s1.results[0].geometry.location.lat.ToString();
            EnderecoFinal.Lng = s1.results[0].geometry.location.lng.ToString();

            TempData["EnderecoInicial"] = EnderecoInicial;
            TempData["EnderecoFinal"] = EnderecoFinal;
            ViewBag.EnderecoInicial = EnderecoInicial;
            ViewBag.EnderecoFinal = EnderecoFinal;
            return RedirectToAction("Jose","Home");

        }

        public ActionResult xxx()
        {
            return View();
        }
       
    }
}