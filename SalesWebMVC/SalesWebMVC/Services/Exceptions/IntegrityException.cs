using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Exceptions {
    public class IntegrityException : ApplicationException {

        //Tratamento de Erro de Integridade Referencial
        public IntegrityException(string message) : base( message)
        {
        }
    }
}
