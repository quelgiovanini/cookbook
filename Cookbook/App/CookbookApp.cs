using Cookbook.Recipes;

namespace Cookbook.App;

public class CookbookApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInterface _recipesConsoleUserInterface;
    public CookbookApp(
                       IRecipesRepository recipesRepository,
                       IRecipesUserInterface recipesConsoleUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesConsoleUserInterface = recipesConsoleUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesConsoleUserInterface.LoadStoredRecipes(allRecipes);

        _recipesConsoleUserInterface.CreateRecipe();

        var ingredients = _recipesConsoleUserInterface.LoadIngredients();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesConsoleUserInterface.ShowMessage("Recipe Added: ");
            _recipesConsoleUserInterface.ShowMessage(recipe.ToString());

        }
        else
        {
            _recipesConsoleUserInterface.ShowMessage(
                "No ingredients have been selected." +
                "Recipe will not be saved.");
        }

        _recipesConsoleUserInterface.Exit();
    }
}
