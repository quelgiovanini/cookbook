using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;

namespace Cookbook.App;

public interface IRecipesUserInterface
{
    void ShowMessage(string message);

    void Exit();
    void LoadStoredRecipes(IEnumerable<Recipe> allRecipes);
    void CreateRecipe();
    IEnumerable<Ingredient> LoadIngredients();
}
