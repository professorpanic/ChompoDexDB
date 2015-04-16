﻿SELECT DISTINCT RecipeIngredientAmounts.amount, Measurements.Measurement_Name AS Measurement, Ingredients.Ingredient_Name AS Ingredient
FROM RecipeIngredientAmounts
INNER JOIN Measurements
ON RecipeIngredientAmounts.Measurement_Id = Measurements.Measurement_ID
INNER JOIN Ingredients
ON Ingredients.Ingredient_Id=RecipeIngredientAmounts.Ingredient_Id; 