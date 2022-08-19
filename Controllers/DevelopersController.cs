
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("[controller]")]
[ApiController]
public class DevelopersController : ControllerBase
{
  private readonly WebAPIExercisesContext context;

  public DevelopersController(WebAPIExercisesContext context)
  {
    this.context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<Developer>>> Get()
  {
    return Ok(await context.Developers.ToListAsync());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Developer>> Get(int id)
  {
    var hero = await context.Developers.FindAsync(id);
    if (hero == null)
      return NotFound($"Hero with id '{id}' not found");
    return Ok(hero);
  }

  [HttpPost]
  public async Task<ActionResult<List<Developer>>> AddHero(Developer dev)
  {
    context.Developers.Add(dev);

    await context.SaveChangesAsync();
    return Ok(await context.Developers.ToListAsync());
  }
}