namespace checkpoint_7.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
  {
    _ingredientsService = ingredientsService;
    _auth = auth;
  }

  [HttpPost]
  public ActionResult<List<Ingredient>> Spawn([FromBody] Ingredient ingredientData)
  {
    try
    {
      Ingredient ingredient = _ingredientsService.Spawn(ingredientData);
      return Ok(ingredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{ingredientId}")]
  public ActionResult<string> DeSpawn(int ingredientId)
  {
    try
    {
      string message = _ingredientsService.DeSpawn(ingredientId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
