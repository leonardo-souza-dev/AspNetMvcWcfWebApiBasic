using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TesteLeonardo.Dominio;
using TesteLeonardo.Interface;

namespace TesteLeonardo.UI.Api.Controllers
{
    public class ProdutosController : ApiController
    {
        private readonly IProdutoRepositorio ProdutoRepositorio;

        public ProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            this.ProdutoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> Get()
        {
            var produtos = ProdutoRepositorio.ObterProdutos();

            return produtos;
        }
    }
}
