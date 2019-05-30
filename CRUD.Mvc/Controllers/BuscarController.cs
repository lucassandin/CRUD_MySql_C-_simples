using CRUD.Model.Model;
using CRUD.Model.ModelsDao;
using CRUD.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Mvc.Controllers
{
    public class BuscarController : Controller
    {
        private PaiDao paidao = new PaiDao();
        private FilhoDao filhodao = new FilhoDao();
        private BuscarDao buscardao = new BuscarDao();

        // GET: Buscar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string tabela, string procurar)
        {
            var _tabela = tabela;
            var _procurar = procurar;
            var listViewModels = new List<PaiFilhoViewModels>();
            var pais = new List<Pai>();
            var filhos = new List<Filho>();

            if (tabela == "Pai")
            {
                foreach (DataRow i in buscardao.BuscarPorNome("pai", procurar).Rows)
                {
                    var pai = new Pai()
                    {
                        Id = Int32.Parse(i["id"].ToString()),
                        Nome = i["nome"].ToString(),
                        Cpf = i["cpf"].ToString(),
                    };

                    pais.Add(pai);
                }

                return View("_ResultPai", pais);
            } else if(tabela == "Filho")
            {
                foreach (DataRow i in buscardao.BuscarPorNome("filho", procurar).Rows)
                {
                    var pai = new Pai()
                    {
                        Id = Int32.Parse(i["paiId"].ToString()),
                        Nome = i["paiNome"].ToString(),
                        Cpf = i["paiCpf"].ToString(),
                    };

                    var filho = new Filho()
                    {
                        Id = Int32.Parse(i["filhoId"].ToString()),
                        Nome = i["filhoNome"].ToString(),
                        Idade = i["filhoIdade"].ToString(),
                        Pai = pai
                    };

                    filhos.Add(filho);
                }

                return View("_ResultFilho", filhos);
            }
            else
            {
                foreach (DataRow i in buscardao.RetornaTodos().Rows)
                {
                    var viewmodel = new PaiFilhoViewModels()
                    {
                        IdPai = Int32.Parse(i["paiId"].ToString()),
                        Pai = i["paiNome"].ToString(),
                        Cpf = i["paiCpf"].ToString(),

                        IdFilho = Int32.Parse(i["filhoId"].ToString()),
                        Filho = i["filhoNome"].ToString(),
                        Idade = i["filhoIdade"].ToString()
                    };

                    listViewModels.Add(viewmodel);
                }

                return View("_Result", listViewModels);
            }
        }
    }
}