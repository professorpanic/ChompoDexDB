using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace ChompoDexDB
    {
    public partial class RecipeBookDBForm : Form
        {
        RecipeDBForm recForm = new RecipeDBForm();
        
        public RecipeBookDBForm()
            {
            InitializeComponent();
            recForm.SetParent(this);
            
            }

        private void RecipeBookForm_Load(object sender, EventArgs e)
            {
            
            this.ResetRecipeDataSource();
            }

        private void RecipeBookAddButton_Click(object sender, EventArgs e)
            {
            recForm.NewOrEditFlag = true;
            recForm = new RecipeDBForm();
            
            DataGridViewRow newRecipeRow = new DataGridViewRow();
            newRecipeRow.CreateCells(recipesDataGridView);
            newRecipeRow.SetValues(-1, "", "", "");
            recForm.SetParent(this);
            recForm.LoadRecipe(newRecipeRow);
            recForm.ShowDialog();
            }

        private void RecipeBookDeleteButton_Click(object sender, EventArgs e)
            {
            DataGridViewRow selectedRow = new DataGridViewRow();
            selectedRow = recipesDataGridView.SelectedRows[0];
            string ingredientDeleteQuery = "DELETE Ingredients FROM Ingredients WHERE Ingredients.Recipe_ID= '" + selectedRow.Cells[0].Value.ToString() + "';";
            string recipeDeleteQuery = "DELETE Recipes FROM Recipes WHERE Recipe_Id= '" + selectedRow.Cells[0].Value.ToString() + "';";
            runQuery(ingredientDeleteQuery);
            runQuery(recipeDeleteQuery);
   
            ResetRecipeDataSource();
            }

        private void RecipeBookEditButton_Click(object sender, EventArgs e)
            {
            DataGridViewRow selectedRow = new DataGridViewRow();
            selectedRow = recipesDataGridView.SelectedRows[0];
            recForm.LoadRecipe(selectedRow);
            recForm.ShowDialog();
            }

        

        private void recipeNameSearchButton_Click(object sender, EventArgs e)
            {
            this.recipesTableAdapter.Fill(this.chompoDexDatabaseDataSet.Recipes);
            searchResultsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string query = "SELECT DISTINCT Recipes.Recipe_Id AS 'Recipe Number', Recipes.Recipe_Name AS Name, Recipes.Cooking_Time AS 'Cooking Time' FROM Recipes WHERE Recipe_Name = @recipeName;";

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            cmd.Parameters.AddWithValue("recipeName", recipeSearchNameText.Text);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);


            DataSet SearchTableSet = new DataSet();

            adapter.Fill(SearchTableSet);

            if (SearchTableSet != null && SearchTableSet.Tables.Count > 0)
                {
                object o = SearchTableSet.Tables[0];
                }

            BindingSource source = new BindingSource();
            source.DataSource = SearchTableSet.Tables[0];
            searchResultsGridView.DataSource = source;

            }

        private void ingredientSearchButton_Click(object sender, EventArgs e)
            {
            this.recipesTableAdapter.Fill(this.chompoDexDatabaseDataSet.Recipes);
            searchResultsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string query = "SELECT DISTINCT Recipes.Recipe_Id AS 'Recipe Number', Recipes.Recipe_Name AS Name, Recipes.Cooking_Time AS 'Cooking Time' FROM Recipes INNER JOIN Ingredients ON Recipes.Recipe_Id = Ingredients.Recipe_Id WHERE Ingredients.Ingredient_Name = @ingredientName;";

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            cmd.Parameters.AddWithValue("ingredientName", recipeIngredientSearchTextBox.Text);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);


            DataSet SearchTableSet = new DataSet();

            adapter.Fill(SearchTableSet);

            BindingSource source = new BindingSource();
            source.DataSource = SearchTableSet.Tables[0];
            searchResultsGridView.DataSource = source;
            }

        //blanks out everything and starts from scratch with a new RecipeDBForm object, to clear references.
        private void newRecipeBookToolStripMenuItem_Click(object sender, EventArgs e)
            {
            string query = "TRUNCATE TABLE RECIPES;";
            runQuery(query);
            query = "TRUNCATE TABLE INGREDIENTS;";
            runQuery(query);
            
            recForm = new RecipeDBForm();
            }

        //saves a recipebook from DB to a .txt file with xml code
        private void saveRecipeBookToolStripMenuItem_Click(object sender, EventArgs e)
            {

            saveRecipeDialog.Filter = "XML-File | *.xml";
            if (saveRecipeDialog.ShowDialog() == DialogResult.OK)
                {
                string cookBookName = saveRecipeDialog.FileName;
                
                using (Stream output = File.Create(cookBookName))
                    {
                    string recipesQuery = "SELECT * FROM Ingredients;";
                    
                    System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(recipesQuery, con);
                    System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    

                    output.Close();
                    adapter.Fill(chompoDexDatabaseDataSet.Ingredients);
                    chompoDexDatabaseDataSet.WriteXml(cookBookName, XmlWriteMode.WriteSchema);
                    }
                
                }
            }

        //for loading xml, inserting into DB,  and displaying the recipes inside
        private void loadRecipeBookToolStripMenuItem1_Click(object sender, EventArgs e)
            {

            

            if (loadRecipeDialog.ShowDialog() == DialogResult.OK)
                {
                string name = loadRecipeDialog.FileName;

                chompoDexDatabaseDataSet.Clear();
                
                string query = "TRUNCATE TABLE RECIPES;";
                runQuery(query);
                query = "TRUNCATE TABLE INGREDIENTS;";
                runQuery(query);
                using (Stream input = File.OpenRead(name))
                    {
                    System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
                    
                    con.Open();

                    try
                        {
                        
                        chompoDexDatabaseDataSet.ReadXml(input, XmlReadMode.ReadSchema);
                        
                        }
                    catch (Exception ex)
                        {

                        }
                    input.Close();
                    using (SqlBulkCopy bulkCopier = new SqlBulkCopy(con))
                        {
                        bulkCopier.DestinationTableName="Recipes";
                        bulkCopier.WriteToServer(chompoDexDatabaseDataSet.Recipes);
                        }

                    using (SqlBulkCopy bulkCopier = new SqlBulkCopy(con))
                        {
                        bulkCopier.DestinationTableName = "Ingredients";
                        bulkCopier.WriteToServer(chompoDexDatabaseDataSet.Ingredients);
                        }
                    con.Close();
                    
                    }
                
                ResetRecipeDataSource();
                }
            }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
            Application.Exit();
            }

        

        //helper method for refreshing the gridview after its datasource has been changed.
        public void ResetRecipeDataSource()
            {
            try
                {
                this.recipesTableAdapter.Fill(this.chompoDexDatabaseDataSet.Recipes);
                }

            catch (Exception ex)
                {

                }
            recipesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string query = "SELECT DISTINCT Recipes.Recipe_Id AS 'Recipe Number', Recipes.Recipe_Name AS Name, Recipes.Cooking_Time AS 'Cooking Time' FROM Recipes;";
            string ingredientsQuery = "SELECT * FROM Ingredients";
            string measurementsQuery = "SELECT * FROM Measurements";

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            System.Data.SqlClient.SqlDataAdapter recipesAdapter = new System.Data.SqlClient.SqlDataAdapter(cmd);

            System.Data.SqlClient.SqlCommand ingCmd = new System.Data.SqlClient.SqlCommand(ingredientsQuery, con);
            System.Data.SqlClient.SqlDataAdapter ingredientsAdapter = new System.Data.SqlClient.SqlDataAdapter(ingCmd);


            System.Data.SqlClient.SqlCommand measCmd = new System.Data.SqlClient.SqlCommand(measurementsQuery, con);
            System.Data.SqlClient.SqlDataAdapter measurementsAdapter = new System.Data.SqlClient.SqlDataAdapter(measCmd);

            DataSet recipeTableSet = new DataSet();
            
            recipesAdapter.Fill(recipeTableSet);
            
            BindingSource source = new BindingSource();
            source.DataSource = recipeTableSet.Tables[0];
            recipesDataGridView.DataSource = source;
            }

        public void ResetRecipeDataSource(string loadedFile)
            {

            using (Stream input = File.OpenRead(loadedFile))
                {
                
                chompoDexDatabaseDataSet.ReadXml(input, XmlReadMode.ReadSchema);
                tableAdapterManager.UpdateAll(chompoDexDatabaseDataSet);
                input.Close();
                }


            recipesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            string query = "SELECT DISTINCT Recipes.Recipe_Id AS 'Recipe Number', Recipes.Recipe_Name AS Name, Recipes.Cooking_Time AS 'Cooking Time' FROM Recipes;";

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);


            DataSet recipeTableSet = new DataSet();

            adapter.Fill(recipeTableSet);

            BindingSource source = new BindingSource();
            source.DataSource = chompoDexDatabaseDataSet.Recipes;
            recipesDataGridView.DataSource = source;
            }

        private void recipesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            DataGridViewRow selectedRow = new DataGridViewRow();
            selectedRow = recipesDataGridView.SelectedRows[0];

            for (int counter = 0; counter < selectedRow.Cells.Count; counter++)
                {
                Console.WriteLine(selectedRow.Cells[counter].Value.ToString());
                }
            
            }

        private void runQuery(string query)
            {
            
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            
            con.Open();
            System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(query, con);
            myCommand.ExecuteNonQuery();
            con.Close();

            ResetRecipeDataSource();
            }

        private void searchResultsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            recForm.NewOrEditFlag = false;
            DataGridViewRow selectedRow = new DataGridViewRow();
            selectedRow = searchResultsGridView.SelectedRows[0];
            recForm.LoadRecipe(selectedRow);
            recForm.ShowDialog();
            searchResultsGridView.DataSource = null;
            }

        

        }
    }
