using System.Web.Mvc;

namespace MAutoSS.Web.Controllers
{
    public class DealershipsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dealerships/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dealerships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealerships/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealerships/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dealerships/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealerships/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dealerships/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
