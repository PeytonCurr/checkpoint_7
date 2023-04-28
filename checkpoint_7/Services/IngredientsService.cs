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
}
