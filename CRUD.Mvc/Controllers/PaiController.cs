using CRUD.Model.Model;
using CRUD.Model.ModelsDao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace CRUD.Mvc.Controllers
{
    public class PaiController : Controller
    {
        PaiDao pd = new PaiDao();

        // GET: Pai
        public ActionResult Index()
        {
            var pais = pd.RetornaTodos();

            List<Pai> listPai = new List<Pai>();

            foreach (DataRow i in pais.Rows)
            {
                Pai p = new Pai
                {
                    Id = Int32.Parse(i["id"].ToString()),
                    Nome = i["nome"].ToString(),
                    Cpf = i["cpf"].ToString()
                };

                listPai.Add(p);
            }

            return View(listPai);
        }

        // GET: Pai/Details/5
        public ActionResult Details(int id)
        {
            var pai = new Pai();

            foreach (DataRow i in pd.GetById(id).Rows)
            {
                pai.Id = Int32.Parse(i["id"].ToString());
                pai.Nome = i["nome"].ToString();
                pai.Cpf = i["cpf"].ToString();
            }

            return View(pai);
        }

        // GET: Pai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pai/Create
        [HttpPost]
        public ActionResult Create(Pai pai)
        {
            try
            {
                pd.Insert(pai);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pai/Edit/5
        public ActionResult Edit(int id)
        {
            var pai = new Pai();

            foreach (DataRow i in pd.GetById(id).Rows)
            {
                pai.Id = Int32.Parse(i["id"].ToString());
                pai.Nome = i["nome"].ToString();
                pai.Cpf = i["cpf"].ToString();
            }

            return View(pai);
        }

        // POST: Pai/Edit/5
        [HttpPost]
        public ActionResult Edit(Pai pai)
        {
            try
            {
                pd.Edit(pai);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pai/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                pd.Delete(id);

                return RedirectToAction("Index");
            } catch(Exception ex)
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
