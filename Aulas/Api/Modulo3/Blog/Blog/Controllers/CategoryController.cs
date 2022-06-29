using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    [Route("/Home")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> Get([FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.AsNoTracking().ToListAsync();
                return Ok(categories);
            }
            catch
            {
                return StatusCode(500, "05X05 Falha interna  no servidor");
            }
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetId([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    NotFound();
                return Ok(category);
            }
            catch
            {
                return StatusCode(500, "05X06 Falha interna  no servidor");
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromBody] Category model, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = model;
                await context.Categories.AddAsync(model);
                await context.SaveChangesAsync();
                return Created($"v1/categories/{model.Id}", model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05X09 Não foi possivel criar a categoria");
            }
            catch
            {
                return StatusCode(500, "05X10 Falha interna  no servidor");
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Category model, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    NotFound();


                category.Name = model.Name;
                category.Slug = model.Slug;

                context.Categories.Update(category);
                await context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05X07 Não foi possivel Alterar a categoria");
            }
            catch
            {
                return StatusCode(500, "05X10 Falha interna  no servidor");
            }
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    NotFound();
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05X08 Não foi possivel Deletar a categoria");
            }
            catch
            {
                return StatusCode(500, "05X10 Falha interna  no servidor");
            }

        }
    }
}
