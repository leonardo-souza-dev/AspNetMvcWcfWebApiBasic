﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TesteLeonardo.Dominio;
using TesteLeonardo.Interface;
using TesteLeonardo.Service;

namespace TesteLeonardo.UI.Api.Controllers
{
    public class ProdutosController : ApiController
    {
        private readonly IProdutoRepositorio ProdutoRepositorio;
        private readonly ITokenService TokenService;

        public ProdutosController(IProdutoRepositorio produtoRepositorio, ITokenService tokenService)
        {
            ProdutoRepositorio = produtoRepositorio;
            TokenService = tokenService;
        }

        public IEnumerable<Produto> Get(string token, string expiraEm)
        {
            if (TokenService.ValidateToken(token, expiraEm))
            {
                var produtos = ProdutoRepositorio.ObterProdutos();

                return produtos;
            }

            return null;
        }
    }
}
