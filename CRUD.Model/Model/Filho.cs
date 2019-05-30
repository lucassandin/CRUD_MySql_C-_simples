using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Model
{
    public class Filho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }

        public Pai Pai { get; set; }
    }
}
