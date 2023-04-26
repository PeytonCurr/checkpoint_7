namespace checkpoint_7.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe GetOne(int recipeId)
  {
    Recipe recipe = _repo.GetOne(recipeId);
    if (recipe == null) throw new Exception($"Recipe ID: {recipeId} does not exist");
    return recipe;
  }

  internal Recipe Spawn(Recipe recipeData)
  {
    int recipeId = _repo.Spawn(recipeData);
    Recipe recipe = this.GetOne(recipeId);
    return recipe;
  }
}