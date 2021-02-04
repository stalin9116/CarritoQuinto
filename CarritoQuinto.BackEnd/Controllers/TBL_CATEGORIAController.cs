using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarritoQuinto.BackEnd.Models;

namespace CarritoQuinto.BackEnd.Controllers
{
    public class TBL_CATEGORIAController : Controller
    {
        private BDDCARRITO2Entities db = new BDDCARRITO2Entities();

        // GET: TBL_CATEGORIA
        public async Task<ActionResult> Index()
        {
            return View(await db.TBL_CATEGORIA.Where(data=>data.cat_status=="A").ToListAsync());
        }

        // GET: TBL_CATEGORIA/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CATEGORIA tBL_CATEGORIA = await db.TBL_CATEGORIA.FindAsync(id);
            if (tBL_CATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CATEGORIA);
        }

        // GET: TBL_CATEGORIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_CATEGORIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cat_nombre,cat_id,cat_descripcion,cat_status,cat_fechacreacion")] TBL_CATEGORIA tBL_CATEGORIA)
        {
            if (ModelState.IsValid)
            {
                tBL_CATEGORIA.cat_fechacreacion = DateTime.Now;
                tBL_CATEGORIA.cat_status = "A";

                db.TBL_CATEGORIA.Add(tBL_CATEGORIA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_CATEGORIA);
        }

        // GET: TBL_CATEGORIA/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CATEGORIA tBL_CATEGORIA = await db.TBL_CATEGORIA.FindAsync(id);
            if (tBL_CATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CATEGORIA);
        }

        // POST: TBL_CATEGORIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cat_nombre,cat_id,cat_descripcion,cat_status,cat_fechacreacion")] TBL_CATEGORIA tBL_CATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_CATEGORIA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_CATEGORIA);
        }

        // GET: TBL_CATEGORIA/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CATEGORIA tBL_CATEGORIA = await db.TBL_CATEGORIA.FindAsync(id);
            if (tBL_CATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CATEGORIA);
        }

        // POST: TBL_CATEGORIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            TBL_CATEGORIA tBL_CATEGORIA = await db.TBL_CATEGORIA.FindAsync(id);
            db.TBL_CATEGORIA.Remove(tBL_CATEGORIA);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
