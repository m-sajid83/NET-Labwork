using InventoryManagementNet6.Data;
using InventoryManagementNet6.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementNet6.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View(InventoryDb.GetAll());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid) return View(product);

        InventoryDb.Add(product);
        TempData["Message"] = "Product added successfully.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var product = InventoryDb.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Product product)
    {
        if (id != product.ProductId) return BadRequest();
        if (!ModelState.IsValid) return View(product);

        if (!InventoryDb.Update(product)) return NotFound();

        TempData["Message"] = "Product updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var product = InventoryDb.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        InventoryDb.Delete(id);
        TempData["Message"] = "Product deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
