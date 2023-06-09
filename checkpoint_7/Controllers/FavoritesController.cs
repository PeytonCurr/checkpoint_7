namespace checkpoint_7.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _FavoritesService;
  private readonly Auth0Provider _auth;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
  {
    _FavoritesService = favoritesService;
    _auth = auth;
  }


  [HttpPost]
  public async Task<ActionResult<Favorite>> Spawn([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      Favorite favorite = _FavoritesService.Spawn(favoriteData);
      return Ok(favorite);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{favoriteId}")]
  public async Task<ActionResult<string>> DeSpawn(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _FavoritesService.DeSpawn(favoriteId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
