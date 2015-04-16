CREATE TABLE [dbo].[Recipes] (
    [Recipe_Id]     INT NOT NULL IDENTITY UNIQUE,
    [Recipe_Name]   NVARCHAR (50)  NOT NULL,
    [Cooking_Time]  NCHAR (20)     NULL,
    [Instructions] NVARCHAR (MAX) NULL,
    [Ingredient_Id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Recipe_Id] ASC),
    CONSTRAINT Ingredient_recipe_id_fk FOREIGN KEY (Ingredient_Id) REFERENCES Ingredients (Ingredient_Id)
);

