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

  internal List<MyFavorite> GetAccountFavorites(string accountId)
  {
    string sql = @"
SELECT 
fav.*,
myFavorite.*,
creator.*
FROM favorites fav
JOIN recipes myFavorite ON fav.recipeId = myFavorite.id
JOIN accounts creator ON myFavorite.creatorId = creator.id
WHERE fav.AccountId = @accountId
;";

    List<MyFavorite> myFavorites = _db.Query<Favorite, MyFavorite, Account, MyFavorite>(sql, (fav, myFavorite, creator) =>
    {
      myFavorite.FavoriteId = fav.Id;
      myFavorite.Creator = creator;
      return myFavorite;
    }, new { accountId }).ToList();
    return myFavorites;
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
