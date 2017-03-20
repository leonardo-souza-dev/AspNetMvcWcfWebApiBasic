using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLeonardo.Dominio;
using TesteLeonardo.Interface;

namespace TesteLeonardo.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ApplicationDbContext Db;

        public ProdutoRepositorio(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            return Db.Produtos.ToList();
        }
    }
}
