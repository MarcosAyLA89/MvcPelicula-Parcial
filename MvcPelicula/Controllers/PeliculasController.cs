using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPelicula.Models;

namespace MvcPelicula.Controllers
{
    public class PeliculasController : Controller
    {
        private PeliculaDBContext db = new PeliculaDBContext();

        // GET: Peliculas
        public ActionResult Index(string buscarString, string generoPelicula, decimal? precio,int? directorPelicula)
        {
            var GeneroLst = new List<string>();
            var GeneroQry = from d in db.Peliculas
                            orderby d.Genero
                            select d.Genero;
            GeneroLst.AddRange(GeneroQry.Distinct());
            ViewBag.generoPelicula = new SelectList(GeneroLst);
            var peliculas = from p in db.Peliculas
                            select p;
            if (!String.IsNullOrEmpty(buscarString))
            {
                peliculas = peliculas.Where(s => s.Titulo.Contains(buscarString));
            }
            if (!string.IsNullOrEmpty(generoPelicula))
            {
                peliculas = peliculas.Where(x => x.Genero == generoPelicula);
            }
            if (!string.IsNullOrEmpty(precio.ToString()) || precio<=0)
            {
                peliculas = peliculas.Where(x => x.Precio == precio);
            }
            if (!string.IsNullOrEmpty(directorPelicula.ToString()) || precio <= 0)
            {
                peliculas = peliculas.Where(x => x.DirectorId == directorPelicula);
            }


            List<Director> DirectoresLst = new List<Director>();
            DirectoresLst = db.Directors.ToList();
            foreach (Director item in DirectoresLst)
            {

                item.Nombre = item.Nombre + " " + item.Apellido;
            }
            ViewBag.directorPelicula = new SelectList(DirectoresLst, "ID", "Nombre");


            return View(peliculas.Include(n => n.Director));
            
        }



        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            List<Director> DirectoresLst = new List<Director>();
            DirectoresLst = db.Directors.ToList();
            foreach(Director item in DirectoresLst)
            {

                item.Nombre = item.Nombre + " " + item.Apellido;
            }
            ViewBag.DirectorPelicula = new SelectList(DirectoresLst,"ID","Nombre");

            return View();
        }

        // POST: Peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,FechaLanzamiento,Genero,Precio,Calificacion,Productor,DirectorId")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            List<Director> DirectoresLst = new List<Director>();
            DirectoresLst = db.Directors.ToList();
            foreach (Director item in DirectoresLst)
            {

                item.Nombre = item.Nombre + " " + item.Apellido;
            }
            ViewBag.DirectorPelicula = new SelectList(DirectoresLst, "ID", "Nombre");
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,FechaLanzamiento,Genero,Precio,Calificacion,Productor,DirectorId")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
            db.SaveChanges();
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
