namespace checkpoint_7.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int Spawn(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
      (Title, Instructions, Img, Category, CreatorId)
    values
      (@title, @instructions, @img, @category, @creatorId);
    SELECT LAST_INSERT_ID();";
    int Id = _db.ExecuteScalar<int>(sql, recipeData);
    return Id;
  }

  internal Recipe GetOne(int recipeId)
  {
    string sql = @"
SELECT
rec.*,
creator.*
FROM recipes rec
JOIN accounts creator ON rec.creatorId = creator.id
WHERE rec.id = @recipeId;
";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (rec, creator) =>
    {
      rec.Creator = creator;
      return rec;
    }, new { recipeId }).FirstOrDefault();
    return recipe;
  }

}
