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

  internal List<MyFavorites> GetAccountFavorites(string accountId)
  {
    List<MyFavorites> favorites = _repo.GetAccountFavorites(accountId);
    return favorites;
  }

  internal Favorite GetOne(int favoriteId)
  {
    Favorite favorite = _repo.GetOne(favoriteId);
    return favorite;
  }

  internal string DeSpawn(int favoriteId, string accountId)
  {
    Favorite favorite = this.GetOne(favoriteId);
    if (favorite.AccountId != accountId) throw new Exception("You don't have authorization to delete this Favorite!");
    _repo.DeSpawn(favoriteId);
    return $"The relationship at favoriteId: {favoriteId} has been deleted!";
  }
}
