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
    
    public class PRODUCTOController : Controller
    {
        private BDDCARRITO2Entities db = new BDDCARRITO2Entities();

        // GET: PRODUCTO

        [Authorize(Roles = "Admin, Asistente")]
        public async Task<ActionResult> Index()
        {
            var tBL_PRODUCTO = db.TBL_PRODUCTO.Include(t => t.TBL_CATEGORIA);
            return View(await tBL_PRODUCTO.ToListAsync());
        }

        // GET: PRODUCTO/Details/5
        [Authorize(Roles = "Admin, Asistente")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRODUCTO tBL_PRODUCTO = await db.TBL_PRODUCTO.FindAsync(id);
            if (tBL_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PRODUCTO);
        }

        // GET: PRODUCTO/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.TBL_CATEGORIA, "cat_id", "cat_nombre");
            return View();
        }

        // POST: PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pro_id,pro_codigo,pro_nombre,pro_preciocompra,pro_precioventa,pro_imagen,pro_descripcion,pro_stockminimo,pro_stockmaximo,pro_fechacreacion,pro_status,cat_id")] TBL_PRODUCTO tBL_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PRODUCTO.Add(tBL_PRODUCTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.TBL_CATEGORIA, "cat_id", "cat_nombre", tBL_PRODUCTO.cat_id);
            return View(tBL_PRODUCTO);
        }

        // GET: PRODUCTO/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRODUCTO tBL_PRODUCTO = await db.TBL_PRODUCTO.FindAsync(id);
            if (tBL_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.TBL_CATEGORIA, "cat_id", "cat_nombre", tBL_PRODUCTO.cat_id);
            return View(tBL_PRODUCTO);
        }

        // POST: PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pro_id,pro_codigo,pro_nombre,pro_preciocompra,pro_precioventa,pro_imagen,pro_descripcion,pro_stockminimo,pro_stockmaximo,pro_fechacreacion,pro_status,cat_id")] TBL_PRODUCTO tBL_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PRODUCTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.TBL_CATEGORIA, "cat_id", "cat_nombre", tBL_PRODUCTO.cat_id);
            return View(tBL_PRODUCTO);
        }

        // GET: PRODUCTO/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRODUCTO tBL_PRODUCTO = await db.TBL_PRODUCTO.FindAsync(id);
            if (tBL_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PRODUCTO);
        }

        // POST: PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBL_PRODUCTO tBL_PRODUCTO = await db.TBL_PRODUCTO.FindAsync(id);
            db.TBL_PRODUCTO.Remove(tBL_PRODUCTO);
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
