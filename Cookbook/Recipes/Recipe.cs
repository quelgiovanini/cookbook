using Cookbook.Recipes.Ingredients;

namespace Cookbook.Recipes;

public class Recipe
{
    public readonly IEnumerable<Ingredient> Ingredients = new List<Ingredient>();

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        var ingredientData = new List<string>();
        foreach (var ingredient in Ingredients)
        {
            ingredientData.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
        }
        return string.Join(Environment.NewLine, ingredientData);
    }
}
