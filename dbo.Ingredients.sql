CREATE TABLE [dbo].[Ingredients] (
    [Ingredient_Id]   INT           IDENTITY (1, 1) NOT NULL UNIQUE,
    [Ingredient_Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Ingredient_Id] ASC)
);

