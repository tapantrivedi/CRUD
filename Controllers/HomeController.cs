using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using CRUD.Models;
using System.Linq;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private CrudContext dbContext;

        public HomeController (CrudContext ABC){

            dbContext= ABC;
        }


    
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dish> mydish = dbContext.Dish.ToList();
            return View(mydish);
        }
        [HttpGet]
        [Route("/Add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Create")]
        public IActionResult Create(Dish Lo)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(Lo);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add");
        }
        [HttpGet]
        [Route("{dish_id}")]
        public IActionResult Name(int dish_id)
        {
            Dish myname = dbContext.Dish.SingleOrDefault(dish=>dish.iddishes == dish_id);
            ViewBag.Show= myname;
            return View("Name", myname);
        }



        [HttpGet]
        [Route("/delete/{dish_id}")]
        public IActionResult Delete(int dish_id)
    
        {
            
            Dish myname = dbContext.Dish.SingleOrDefault(dish=>dish.iddishes == dish_id);
            dbContext.Dish.Remove(myname);
            dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Update/{dish_id}")]
    
        public IActionResult Update(int dish_id)
        {
            Dish bla = dbContext.Dish.SingleOrDefault(dish=>dish.iddishes == dish_id);
            ViewBag.Show = bla;
            return View("Update");
        }

        [HttpPost]
        [Route("/update/{dish_id}")]
        public IActionResult Updatey(int dish_id, Dish gandhi)
        {
            Dish bla = dbContext.Dish.SingleOrDefault(gare => gare.iddishes == dish_id);
            ViewBag.Show = bla;
            if (ModelState.IsValid)
            {
        
                
                    bla.Name = gandhi.Name;
                    bla.Chef= gandhi.Chef;
                    bla.Calories= gandhi.Calories;
                    bla.Description=gandhi.Description;
                    bla.Tastiness=gandhi.Tastiness;
                    bla.UpdatedAt = DateTime.Now;
                    dbContext.SaveChanges();
                    return RedirectToAction("Name",new {dish_id = dish_id});
                
            }
            return View("Update",bla);
        
        }



    }
}
