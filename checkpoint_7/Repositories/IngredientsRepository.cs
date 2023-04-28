namespace checkpoint_7.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Ingredient Spawn(Ingredient ingredientData)
  {
    string sql = @"
INSERT INTO ingredients
  (Name, Quantity, RecipeId)
values
  (@Name, @Quantity, @RecipeId);
SELECT LAST_INSERT_ID()
;";
    int Id = _db.ExecuteScalar<int>(sql, ingredientData);
    ingredientData.Id = Id;
    return ingredientData;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
SELECT * 
FROM ingredients
WHERE recipeId = @recipeId
;";
    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    return ingredients;
  }

}
