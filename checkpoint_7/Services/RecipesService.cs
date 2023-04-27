namespace checkpoint_7.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }
  internal Recipe Spawn(Recipe recipeData)
  {
    int recipeId = _repo.Spawn(recipeData);
    Recipe recipe = this.GetOne(recipeId);
    return recipe;
  }

  internal List<Recipe> GetAll()
  {
    List<Recipe> recipes = _repo.GetAll();
    return recipes;
  }

  internal Recipe GetOne(int recipeId)
  {
    Recipe recipe = _repo.GetOne(recipeId);
    if (recipe == null) throw new Exception($"Recipe ID: {recipeId} does not exist");
    return recipe;
  }

  internal Recipe Edit(Recipe recipeData, string userId)
  {
    Recipe originalRecipe = this.GetOne(recipeData.Id);

    if (originalRecipe.CreatorId != userId) throw new Exception("You are not Authorized to Edit this Recipe");

    originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
    originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
    originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
    originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;

    Recipe recipe = _repo.Edit(originalRecipe);
    return recipe;
  }

  internal string DeSpawn(int recipeId, string userId)
  {
    Recipe recipe = this.GetOne(recipeId);

    if (recipe.CreatorId != userId) throw new Exception("You are not Authorized to Delete this Recipe");

    int rowsAffected = _repo.DeSpawn(recipeId);

    if (rowsAffected == 0) throw new Exception("Delete Failed");
    if (rowsAffected > 1) throw new Exception("Shes gonna Blow!!!");
    return $"Recipe: {recipe.Title} was Deleted";
  }
}
