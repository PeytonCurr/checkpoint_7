namespace checkpoint_7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _FavoritesService;

  public FavoritesController(FavoritesService favoritesService)
  {
    _FavoritesService = favoritesService;
  }

}
