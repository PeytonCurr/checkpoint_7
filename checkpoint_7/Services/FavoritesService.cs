namespace checkpoint_7.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;

  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal Favorite Spawn(Favorite favoriteData)
  {
    if (favoriteData.RecipeId == 0) throw new Exception("This Favorite can't be created as it is missing a RecipeId");
    Favorite favorite = _repo.Spawn(favoriteData);
    return favorite;
  }

  internal List<Favorite> GetAccountFavorites(string accountId)
  {
    List<Favorite> favorites = _repo.GetAccountFavorites(accountId);
    return favorites;
  }

}
