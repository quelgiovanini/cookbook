namespace Cookbook.Recipes.Ingredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions => $"Sift Flour. {base.PreparationInstructions}.";
}
