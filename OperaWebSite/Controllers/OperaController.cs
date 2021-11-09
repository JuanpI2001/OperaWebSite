using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Data;
using OperaWebSite.Models;
using System.Data.Entity;
using System.Diagnostics;
using OperaWebSite.Filters;//agregamos para usar los filtros 

namespace OperaWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        //Crear  Instancia  del dbcontext 

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index
        public ActionResult Index()
        {
            //traer todas las operas usando EF
            var operas = context.Operas.ToList();

            //el controler retorna una vista "Index" con la lista de operas 
            return View("Index", operas);
        }

        // creamos dos metodos para la insercion de la opera en la DB
        //Primero create por GET para retornar la vista de registro

        [HttpGet]// El GET  es implicito pero se puede aclarar
        public ActionResult Create()
        {
            //Creamos la instancia sin valores en las propiedades
            Opera opera = new Opera();
            //Retornamos la vista "Create" que tiene el objeto opera 
            return View("Create", opera);
        }

        //Segundo Create es por Post, para insertar la nueva opera en la base
        //Cuando el usuario en la vista create hace click en enviar 

        //Opera/Create -->Post

        [HttpPost]//El Post es implicito pero se puede aclarar
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", opera);
        }

        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }    
        }
        // opera/delete/Id
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Opera opera = context.Operas.Find(id);
            context.Operas.Remove(opera);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Edit", opera);
            }
            return HttpNotFound();
        }

        //Opera/Edit 
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirm(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", opera);
        }

        //Filtro de accion - ocurre antes
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //controller/action
        //    //{controller}/{action}
        //    //Opera/Create
        //    var controller = filterContext.RouteData.Values["controller"];
        //    var action = filterContext.RouteData.Values["action"];
        //    Debug.WriteLine("Controller:" + controller + "Action:" + action +"Paso por OnActionExecuting");
        //}
        ////Filtro de accion - ocurre despues
        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    var controller = filterContext.RouteData.Values["controller"];
        //    var action = filterContext.RouteData.Values["action"];
        //    Debug.WriteLine("Controller:" + controller + "Action:" + action + "Paso por OnActionExecuted");
        //}
    }
}