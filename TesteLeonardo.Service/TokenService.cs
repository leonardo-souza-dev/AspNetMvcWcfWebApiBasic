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
            var agora = DateTime.Now;
            token.ExpiraEm = agora;
            var chave = Helper.StringCipher.Encrypt(agora.ToString(), "=L$J&&ybt+7!A!wn").ToUpper();
            token.Guid = Guid.Parse(chave);
            return token;
        }

        public bool ValidateToken(string pToken)
        {
            //TODO: implementar a decriptografia com metodo novo do helper
            if (token == null || token.Guid == null)
            {
                return false;
            }
            var validacaoGuid = token.Guid.ToString().ToUpper() == pToken.ToUpper();
            var validacaoTempo = token.ExpiraEm > DateTime.Now;

            return validacaoGuid && validacaoTempo;
        }
    }
}
