namespace checkpoint_7.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal Ingredient Spawn(Ingredient ingredientData)
  {
    if (ingredientData.RecipeId == 0) throw new Exception("You cant create this Ingredient, as there is no RecipeId");
    Ingredient ingredient = _repo.Spawn(ingredientData);
    return ingredient;
  }
  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
    if (ingredients == null) throw new Exception($"The Ingredients at ID: {recipeId} do not exist!");
    return ingredients;
  }

  internal string DeSpawn(int ingredientId)
  {
    int rowsAffected = _repo.DeSpawn(ingredientId);
    if (rowsAffected == 0) throw new Exception("Delete Failed");
    if (rowsAffected > 1) throw new Exception("Shes gonna Blow!!!");
    return $"The Ingredient at ID: {ingredientId} was deleted!";
  }
}
