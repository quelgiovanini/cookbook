using Cookbook.App;
using Cookbook.DataAccess;
using Cookbook.FileAccess;
using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;

var ingredientsRegister = new IngredientsRegister();

IStringsRepository stringRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTxtRepository();

const string FileName = "recipes";
var fileData = new FileData(FileName, Format);

var cookBookApp = new CookbookApp(
       new RecipesRepository(
           stringRepository,
           ingredientsRegister),
       new RecipesConsoleUserInterface(
           ingredientsRegister));

cookBookApp.Run(fileData.ToPath());

Console.ReadKey();