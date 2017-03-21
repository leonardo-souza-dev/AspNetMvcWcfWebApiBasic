using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteLeonardo.Interface;

namespace TesteLeonardo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepositorio ProdutoRepositorio;

        public HomeController(IProdutoRepositorio produtoRepositorio)
        {
            this.ProdutoRepositorio = produtoRepositorio;
        }

        public ActionResult Index()
        {
            var produtos = ProdutoRepositorio.ObterProdutos();

            return View(produtos);
        }

        public ActionResult GerarToken()
        {
            ServiceReference1.Service1Client clienteWcf = new ServiceReference1.Service1Client();

            var token = clienteWcf.GetToken();

            ViewBag.Token = token;

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}