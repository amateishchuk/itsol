using ItSolutionExpert.DataAccessLayer.Entities;
using ItSolutionExpert.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ItSolutionExpert.Controllers
{
    public class ItemsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return View(await _dataContext.Items.ToListAsync());
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var item = await _dataContext.Items.FindAsync(id);
            if (item == null)
                return HttpNotFound();
            return View(item);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _dataContext.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Item item, int[] selectedCategories)
        {
            if (!ModelState.IsValid)
                return View(item);
            foreach (var selectedCategory in selectedCategories)
                item.Categories.Add(await _dataContext.Categories.FindAsync(selectedCategory));

            _dataContext.Items.Add(item);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var item = await _dataContext.Items.FindAsync(id);
            if (item == null)
                return HttpNotFound();

            ViewBag.Categories = await _dataContext.Categories.ToListAsync();

            return View(item);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Item item, int[] selectedCategories)
        {
            if (!ModelState.IsValid)
                return View(item);

            var newItem = await _dataContext.Items.FindAsync(item.Id);
            newItem.Name = item.Name;
            newItem.Description = item.Description;
            newItem.Url = item.Url;

            newItem.Categories.Clear();
            if (selectedCategories != null)
            {
                var categories = await _dataContext.Categories
                    .Where(c => selectedCategories
                    .Contains(c.Id))
                    .ToListAsync();

                foreach (var c in categories)
                {
                    newItem.Categories.Add(c);
                }
            }

            _dataContext.Entry(newItem).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }        
    }
}