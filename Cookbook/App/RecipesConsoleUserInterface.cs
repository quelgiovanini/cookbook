using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;

namespace Cookbook.App;

public class RecipesConsoleUserInterface : IRecipesUserInterface
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInterface(
        IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadLine();
    }

    public void LoadStoredRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Stored recipes are: " + Environment.NewLine);

            var countIndex = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{countIndex}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                countIndex++;
            }
        }
    }

    public void CreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " +
            "Available ingredients are: ");

        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);

        }
    }

    public IEnumerable<Ingredient> LoadIngredients()
    {
        bool loadStop = false;
        var ingredients = new List<Ingredient>();

        while (!loadStop)
        {
            Console.WriteLine("Add an ingredient by ID, " +
                "or type any key when done.");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                loadStop = true;
            }
        }

        return ingredients;
    }
}
