CREATE TABLE [dbo].[RecipeIngredientAmounts]
(
	[amount] INT NULL, 
    [Ingredient_Id] INT NOT NULL, 
    [Recipe_Id] INT NOT NULL, 
    [Measurement_Id] INT NULL,
	CONSTRAINT Ingredient_id_fk FOREIGN KEY ([Ingredient_Id]) references Ingredients (Ingredient_Id),
	CONSTRAINT recipe_id_fk FOREIGN KEY (Recipe_ID) references Recipes (Recipe_Id),
	CONSTRAINT measurement_id_fk FOREIGN KEY (Measurement_ID) references Measurements (Measurement_ID) 
)
