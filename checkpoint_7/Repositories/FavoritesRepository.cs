namespace checkpoint_7.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite Spawn(Favorite favoriteData)
  {
    string sql = @"
INSERT INTO favorites
  (AccountId, RecipeId)
Values
  (@accountId, @recipeId);
  SELECT LAST_INSERT_ID()
;";

    int Id = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = Id;
    return favoriteData;
  }

  internal List<Favorite> GetAccountFavorites(string accountId)
  {
    string sql = @"
SELECT 
fav.*
rec.*
FROM favorites fav
JOIN recipes rec ON fav.recipeId = rec.Id
WHERE fav.AccountId = @accountId
;";

    List<Favorite> favorites = _db.Query<Favorite, Recipe, Favorite>(sql, (fav, rec) =>
    {
      fav.RecipeId = rec.Id;
      return fav;
    }, new { accountId }).ToList();
    return favorites;
  }
}
