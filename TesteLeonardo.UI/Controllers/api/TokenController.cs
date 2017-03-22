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
    public class TokenController : ApiController
    {
        public Token Get()
        {
            ServiceReference1.Service1Client clienteWcf = new ServiceReference1.Service1Client();

            var token = clienteWcf.GenerateToken();

            return token;
        }
    }
}
