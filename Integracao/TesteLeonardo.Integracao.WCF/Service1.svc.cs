using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TesteLeonardo.Dominio;
using TesteLeonardo.Interface;
using TesteLeonardo.Service;

namespace TesteLeonardo.Servico
{
    public class Service1 : IService1
    {
       

        public Token GenerateToken()
        {
            ITokenService tokenService = new TokenService();
            return tokenService.GenerateToken();
        }

        public bool ValidateToken(string guid)
        {
            ITokenService tokenService = new TokenService();
            return tokenService.ValidateToken(guid);
        }
    }
}
