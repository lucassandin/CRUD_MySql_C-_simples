using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Mvc.ViewModels
{
    public class PaiFilhoViewModels
    {
        public int IdPai { get; set; }
        public string Pai { get; set; }
        public string Cpf { get; set; }

        public int IdFilho { get; set; }
        public string Filho { get; set; }
        public string Idade { get; set; }

    }
}