using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TesteLeonardo.Dominio;

namespace TesteLeonardo.Servico
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Token GenerateToken();

        [OperationContract]
        bool ValidateToken(string token);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }


    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
