using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TesteLeonardo.Dominio;
using TesteLeonardo.Service;

namespace TesteLeonardo.Servico
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Token token;

        public Token GenerateToken()
        {
            TokenService.GenerateToken();

            return TokenService.Token;
        }

        public bool ValidateToken(string token)
        {
            var validacaoGuid = TokenService.Token.Guid.ToString().ToUpper() == token.ToUpper();
            var validacaoTempo = TokenService.Token.ExpiraEm > DateTime.Now;

            return validacaoGuid && validacaoTempo;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
