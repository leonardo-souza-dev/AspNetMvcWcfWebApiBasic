using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLeonardo.Dominio;

namespace TesteLeonardo.Interface
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> ObterProdutos();
    }
}
