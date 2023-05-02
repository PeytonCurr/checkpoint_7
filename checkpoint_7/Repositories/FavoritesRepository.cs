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

  internal List<MyFavorites> GetAccountFavorites(string accountId)
  {
    string sql = @"
SELECT 
fav.*,
MyFavorite.*
FROM favorites fav
JOIN recipes MyFavorite ON MyFavorite.id = fav.recipeId
WHERE fav.AccountId = @accountId
;";

    List<MyFavorites> MyFavorites = _db.Query<Favorite, MyFavorites, MyFavorites>(sql, (fav, MyFavorite) =>
    {
      MyFavorite.FavoriteId = fav.RecipeId;
      return MyFavorite;
    }, new { accountId }).ToList();
    return MyFavorites;
  }

  internal Favorite GetOne(int favoriteId)
  {
    string sql = @"
SELECT *
FROM favorites
WHERE id = @favoriteId
;";

    Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
    return favorite;
  }

  internal void DeSpawn(int favoriteId)
  {
    string sql = @"
    DELETE
    FROM favorites
    WHERE id = @favoriteId
    LIMIT 1
    ;";

    _db.Execute(sql, new { favoriteId });
  }
}
