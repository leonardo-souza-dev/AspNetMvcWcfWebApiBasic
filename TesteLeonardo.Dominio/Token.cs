using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLeonardo.Dominio
{
    public class Token
    {
        public Guid Guid { get; set; }
        public DateTime ExpiraEm { get; set; }
    }
}
