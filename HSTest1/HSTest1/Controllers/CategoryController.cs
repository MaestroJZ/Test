using HCTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using HCTest1.Models;

[ApiController]
[Route("api/")]
public class CategoryController : ControllerBase
{
    private readonly CategoryContext _context;

    public CategoryController(CategoryContext context)
    {
        _context = context;
    }

    [HttpGet("Categories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }

    [HttpGet("Products")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    [HttpGet("Product/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products
            .SingleOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        return product;
    }
        
    [HttpGet("Products/{Categoryid}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(int Categoryid)
    {
        var tovary = await _context.Products.Where(t => t.CategoryId == Categoryid).ToListAsync();
        if (tovary == null || tovary.Count == 0)
        {
            return NotFound();
        }
        return tovary;
    }

    [HttpPost("addcategory")]
    public async Task<ActionResult<Category>> AddCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return BadRequest();
        }
        var tovar = new Category { Name = category };
        await _context.Categories.AddAsync(tovar);
        await _context.SaveChangesAsync();
        return tovar;
    }

    [HttpDelete("Categories/{name}")]
    public async Task<ActionResult> DeleteCategoryByName(string name)
    {
        var category = await _context.Categories.SingleOrDefaultAsync(c => c.Name == name);
        if (category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    
    [HttpPost("PostProduct")]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        var category = await _context.Categories.FindAsync(product.CategoryId);
        if (category == null) {
            return BadRequest("The category does not exist.");
        }

        product.Category = category;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}