using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtulaDotNetTest.Data;
using AtulaDotNetTest.Models.Entities;

namespace AtulaDotNetTest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sku,Name")] Product product)
        {
            try
            {
                // Attempt to add the product to the context
                _context.Add(product);
                // Save changes to the database
                await _context.SaveChangesAsync();

                // Set the success message
                TempData["NotificationMessage"] = "Product successfully created!";
                
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                
                Console.WriteLine($"Error saving product: {ex.Message}");
                
                return View("Error"); 
            }
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Load categories and set selected categories
            ViewBag.Categories = new MultiSelectList(_context.Categories, "Id", "Name", product.Categories.Select(c => c.Id));
            product.SelectedCategoryIds = product.Categories.Select(c => c.Id).ToList();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,Name,SelectedCategoryIds")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            try
            {
                // Fetch the existing product from the database
                var existingProduct = await _context.Products
                    .Include(p => p.Categories)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update product details
                existingProduct.Sku = product.Sku;
                existingProduct.Name = product.Name;

                // Clear existing categories and add the selected ones
                existingProduct.Categories.Clear();
                foreach (var categoryId in product.SelectedCategoryIds)
                {
                    var category = await _context.Categories.FindAsync(categoryId);
                    if (category != null)
                    {
                        existingProduct.Categories.Add(category);
                    }
                }

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Set the success message
                TempData["NotificationMessage"] = "Product successfully updated!";

                // Redirect to the Index action upon successful update
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }



        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();

            // Set the success message
            TempData["NotificationMessage"] = "Product successfully deleted!";

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
