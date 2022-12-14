using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuItens.Context;
using MenuItens.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MenuTestProject")]
namespace MenuItens.Controllers //Controller of Product Moldel based on Context Class
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MenuItensContext _context;

        public ProductController(MenuItensContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            return await _context.Product.ToListAsync();
        }

        // GET: api/Product/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/Id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            if (Active_Components_Confirmation_Type2(id))
            {
                return BadRequest();
            }
            if (Active_Components_Confirmation_Type3(id))
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //Confirms that the product has a valid id
        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Confirms that the type 2 Product has at least one active component
        internal bool Active_Components_Confirmation_Type2(int id)
        {
            return (_context.Product?.Any(e => e.Id == id && e.PrdType == 2 && e.PrdActive != null && e.PrdActive.PrdStatus == 1 && e.Components.All(x => x.PrdId == e.Id && x.ProductChild.PrdActive.PrdStatus == 0))).GetValueOrDefault();
        }

        //Confirms that the type 3 Product has all active components
        internal bool Active_Components_Confirmation_Type3(int id)
        {
            return (_context.Product?.Any(e => e.Id == id && e.PrdType == 3 && e.PrdActive != null && e.PrdActive.PrdStatus == 1 && e.Components.Any(x => x.PrdId == e.Id && x.ProductChild.PrdActive.PrdStatus == 0))).GetValueOrDefault();
        }

    }
}
