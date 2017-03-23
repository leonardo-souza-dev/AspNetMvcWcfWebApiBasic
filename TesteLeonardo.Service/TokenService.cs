using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLeonardo.Dominio;
using TesteLeonardo.Interface;
using TesteLeonardo.Repositorio;

namespace TesteLeonardo.Service
{
    public class TokenService : ITokenService
    {

        private static Token token;
        public static Token Token { get { return token; } set { token = value; } }

        public Token GenerateToken()
        {
            Token token = new Token();
            
            //var expiraEm = DateTime.Now.AddMinutes(1);
            var expiraEm = DateTime.Now.AddSeconds(10);

            token.ExpiraEm = expiraEm;
            var md5 = Helper.StringCipher.ToMD5(expiraEm.ToString("HH:mm:ss"));
            //token.Guid = Guid.Parse(md5);
            token.Chave = md5;
            return token;
        }
         
        public bool ValidateToken(string pToken, string expiraEm)
        {
            bool validacaoToken = false;

            if (string.IsNullOrEmpty(pToken))
            {
                return validacaoToken;
            }
            var validacaoMd5 = Helper.StringCipher.ValidaMD5(pToken, expiraEm);

            if (validacaoMd5)
            { 
                var expira = Convert.ToDateTime(expiraEm);

                if (expira > DateTime.Now)
                {
                    validacaoToken = true;
                }
            }

            return validacaoToken;
        }
    }
}
