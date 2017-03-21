using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLeonardo.Dominio;
using TesteLeonardo.Repositorio;

namespace TesteLeonardo.Service
{
    public static class TokenService
    {
        private static Token token;
        public static Token Token { get { return token; } set { token = value; } }

        public static Token GenerateToken()
        {
            token = new Token();
            token.Guid = Guid.NewGuid();
            token.ExpiraEm = DateTime.Now.AddMinutes(1);

            return token;
        }
    }
}
