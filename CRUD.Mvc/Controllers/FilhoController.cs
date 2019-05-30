using CRUD.Model.Model;
using CRUD.Model.ModelsDao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Mvc.Controllers
{
    public class FilhoController : Controller
    {
        FilhoDao DB = new FilhoDao();
        PaiDao PaiDao = new PaiDao();

        // GET: filho
        public ActionResult Index()
        {
            var filhos = DB.RetornaTodos();

            List<Filho> listfilho = new List<Filho>();

            foreach (DataRow i in filhos.Rows)
            {
                Pai p = new Pai
                {
                    Id = Int32.Parse(i["paiId"].ToString()),
                    Nome = i["paiNome"].ToString(),
                    Cpf = i["paiCpf"].ToString()
                };

                Filho f = new Filho
                {
                    Id = Int32.Parse(i["filhoId"].ToString()),
                    Nome = i["filhoNome"].ToString(),
                    Idade = i["filhoIdade"].ToString(),
                    Pai = p
                };

                listfilho.Add(f);
            }

            return View(listfilho);
        }

        // GET: filho/Details/5
        public ActionResult Details(int id)
        {
            var filho = new Filho();

            foreach (DataRow i in DB.GetById(id).Rows)
            {
                filho.Id = Int32.Parse(i["filhoId"].ToString());
                filho.Nome = i["filhoNome"].ToString();
                filho.Idade = i["filhoIdade"].ToString();
            }

            return View(filho);
        }

        // GET: filho/Create
        public ActionResult Create()
        {
            var pais = PaiDao.RetornaTodos();
            var listPais = new List<Pai>();

            foreach (DataRow i in pais.Rows)
            {
                var pai = new Pai
                {
                    Id = Int32.Parse(i["id"].ToString()),
                    Nome = i["nome"].ToString(),
                    Cpf = i["cpf"].ToString()
                };

                listPais.Add(pai);
            }

            ViewBag.Pais = new SelectList(listPais, "Id", "Nome");

            return View();
        }

        // POST: filho/Create
        [HttpPost]
        public ActionResult Create(Filho filho, int idPai)
        {
            try
            {
                var pai = new Pai();
                
                foreach (DataRow i in PaiDao.GetById(idPai).Rows)
                {
                    pai.Id = Int32.Parse(i["id"].ToString());
                    pai.Nome = i["nome"].ToString();
                    pai.Cpf = i["cpf"].ToString();
                }

                filho.Pai = pai;

                DB.Insert(filho);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: filho/Edit/5
        public ActionResult Edit(int id)
        {
            var filho = new Filho();
            var pais = new List<Pai>();

            foreach (DataRow i in PaiDao.RetornaTodos().Rows)
            {
                var pai = new Pai
                {
                    Id = Int32.Parse(i["id"].ToString()),
                    Nome = i["nome"].ToString(),
                    Cpf = i["cpf"].ToString()
                };

                pais.Add(pai);
            }

            foreach (DataRow i in DB.GetById(id).Rows)
            {
                var pai = new Pai
                {
                    Id = Int32.Parse(i["paiId"].ToString()),
                    Nome = i["paiNome"].ToString(),
                    Cpf = i["paiCpf"].ToString()
                };

                filho.Id = Int32.Parse(i["filhoId"].ToString());
                filho.Nome = i["filhoNome"].ToString();
                filho.Idade = i["filhoIdade"].ToString();
                filho.Pai = pai;
            }

            ViewBag.Pais = new SelectList(pais, "Id", "Nome", filho.Pai.Id);

            return View(filho);
        }

        // POST: filho/Edit/5
        [HttpPost]
        public ActionResult Edit(Filho filho, int idPai)
        {
            try
            {
                var pai = new Pai();
                foreach (DataRow i in PaiDao.GetById(idPai).Rows)
                {
                    pai.Id = Int32.Parse(i["id"].ToString());
                    pai.Nome = i["nome"].ToString();
                    pai.Cpf = i["cpf"].ToString();
                }

                filho.Pai = pai;

                DB.Edit(filho);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: filho/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DB.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
                throw ex;
            }
        }

        public ActionResult Error()
        {
            ViewBag.Error = "Erro ao executar ação.";
            return View();
        }
    }
}
