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

  internal List<Recipe> GetAll()
  {
    string sql = @"
    SELECT 
    rec.*,
    creator.* 
    FROM recipes rec
    JOIN accounts creator ON rec.creatorId = creator.id
    ;";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (rec, creator) =>
    {
      rec.Creator = creator;
      return rec;
    }).ToList();
    return recipes;
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

  internal Recipe Edit(Recipe originalRecipe)
  {
    string sql = @"
    UPDATE recipes rec
    SET
      Title = @Title,
      Instructions = @Instructions,
      Img = @Img,
      Category = @Category
    WHERE id = @id;

    SELECT 
    rec.*,
    creator.* 
    FROM recipes rec
    JOIN accounts creator ON rec.creatorId = creator.id
    WHERE rec.id = @id
    ;";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (rec, creator) =>
    {
      rec.Creator = creator;
      return rec;
    }, originalRecipe).FirstOrDefault();
    return recipe;
  }

  internal int DeSpawn(int recipeId)
  {
    string sql = @"
DELETE
FROM recipes
WHERE id = @recipeId
LIMIT 1
;";

    int rowsAffected = _db.Execute(sql, new { recipeId });
    return rowsAffected;
  }
}
