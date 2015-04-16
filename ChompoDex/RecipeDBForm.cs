using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ChompoDexDB
    {
    public partial class RecipeDBForm : Form
        {
        RecipeBookDBForm catalogFormParentRef;
        DataGridViewRow passedRow;
        //true for when form is loaded to add a new recipe, false for when editing one
        public bool NewOrEditFlag { get; set; }
        string query;


        public RecipeDBForm()
            {
            InitializeComponent();
            }

        public void LoadRecipe(DataGridViewRow row)
            {
            passedRow = row;
            }

        private void RecipeDBForm_Load(object sender, EventArgs e)
            {
            // This line of code loads data into the 'chompoDexDatabaseDataSet1.Ingredients' table. You can move, or remove it, as needed.
            this.ingredientsTableAdapter1.Fill(this.chompoDexDatabaseDataSet1.Ingredients);
            
            // This line of code loads data into the 'chompoDexDatabaseDataSet1.Measurements' table. You can move, or remove it, as needed.
            this.measurementsTableAdapter1.Fill(this.chompoDexDatabaseDataSet1.Measurements);
            // This line of code loads data into the 'chompoDexDatabaseDataSet1.Measurements' table. You can move, or remove it, as needed.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            amountTextBox.Mask = "0999";
            
            if (passedRow != null)
                {
                recipe_NameTextBox.Text = passedRow.Cells[1].Value.ToString();
                cooking_TimeTextBox.Text = passedRow.Cells[2].Value.ToString();

                
                query = "SELECT Instructions FROM Recipes WHERE Recipes.Recipe_Id= @recipeId;";
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
                cmd.Parameters.AddWithValue("recipeId", passedRow.Cells[0].Value);

                try
                    {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        {
                        instructionsTextBox.Text = (reader["Instructions"].ToString());
                        }
                    }
                finally
                    {
                    con.Close();
                    }
                ReloadIngredientList(passedRow);
                }
            }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
            
            }

        private void addIngredientButton_Click(object sender, EventArgs e)
            {
            query =
                
            "INSERT INTO Ingredients (Ingredient_Name, Recipe_Id, Measurement_Id, Amount) VALUES (@ingredientName, @recipeId, @measurementName,  @amount);";
            
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            cmd.Parameters.AddWithValue("ingredientName", ingredient_NameTextBox.Text);
            cmd.Parameters.AddWithValue("recipeId", passedRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("measurementName", measurementName_comboBox.SelectedValue);
            cmd.Parameters.AddWithValue("amount", amountTextBox.Text);
            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
            ReloadIngredientList(passedRow);
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            for (int counter = 0; counter < dataGridView1.SelectedRows.Count; counter++  )
                {
                Console.WriteLine(dataGridView1.SelectedRows[counter].ToString());
                }
            }

        public void SetParent(RecipeBookDBForm parent)
            {
            catalogFormParentRef = parent;
            }

        private void ReloadIngredientList(DataGridViewRow incomingRow)
            {
            query =
                "SELECT DISTINCT Ingredients.amount AS Amount, Measurements.Measurement_Name AS Measurement, Ingredients.Ingredient_Name AS Ingredient FROM Ingredients INNER JOIN Measurements ON Ingredients.Measurement_Id = Measurements.Measurement_ID WHERE Ingredients.Recipe_ID = " +incomingRow.Cells[0].Value + ";";


            ReloadIngredientList();
            }

        protected void ReloadIngredientList()
            {
            if (String.IsNullOrEmpty(query))
                {
                query = "";
                    
                }


            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);


            DataSet ingredientTableSet = new DataSet();

            adapter.Fill(ingredientTableSet);

            if (ingredientTableSet != null && ingredientTableSet.Tables.Count > 0)
                {
                Console.WriteLine("in the reloadingredientlist if loop");
                object o = ingredientTableSet.Tables[0];
                }
            
            BindingSource source = new BindingSource();
            source.DataSource = ingredientTableSet.Tables[0];
            dataGridView1.DataSource = source;
            
                
            }

        private void recipeCancelButton_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void recipeOKButton_Click(object sender, EventArgs e)
            {

            if (passedRow.Cells[0].Value.Equals(-1))
                {
                query =
                "INSERT INTO Recipes (Recipe_Name, Cooking_Time, Instructions) VALUES ( @recipeName, @cookingTime, @instructions);";
                }
            else
                {
                query =
                     "UPDATE Recipes SET Recipe_Name= @recipeName, Cooking_Time= @cookingTime, Instructions= @instructions WHERE Recipe_Id= @recipeId;";
                }
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            cmd.Parameters.AddWithValue("recipeName", recipe_NameTextBox.Text);
            cmd.Parameters.AddWithValue("cookingTime", cooking_TimeTextBox.Text);
            cmd.Parameters.AddWithValue("instructions", instructionsTextBox.Text);
            cmd.Parameters.AddWithValue("recipeId", passedRow.Cells[0].Value);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            query =
                "SELECT Recipe_Id FROM Recipes WHERE Recipe_Name= @recipeName AND Cooking_Time= @cookingTime AND Instructions= @instructions;";
            
            cmd = new System.Data.SqlClient.SqlCommand(query, con);
            cmd.Parameters.AddWithValue("recipeName", recipe_NameTextBox.Text);
            cmd.Parameters.AddWithValue("cookingTime", cooking_TimeTextBox.Text);
            cmd.Parameters.AddWithValue("instructions", instructionsTextBox.Text);

            con.Open();
            int recipeId=(int)cmd.ExecuteScalar();
            con.Close();

            query =
                "UPDATE Ingredients SET " + "Recipe_Id = " + recipeId + "WHERE Recipe_Id = -1;";
            cmd = new System.Data.SqlClient.SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            
            this.Close();

            }

        

        private void removeIngredientButton_Click(object sender, EventArgs e)
            {
            
            
            query =
                "DELETE FROM Ingredients WHERE Recipe_Id= @recipeId AND  Ingredient_Name= @ingredientName;";

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            cmd.Parameters.AddWithValue("recipeId", passedRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("ingredientName", dataGridView1.SelectedRows[0].Cells[2].Value);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            ReloadIngredientList(passedRow);
            }

        protected override void OnFormClosing(FormClosingEventArgs e)
            {
            base.OnFormClosing(e);
            NewOrEditFlag = false;
            query =
                "DELETE Ingredients FROM Ingredients WHERE Ingredients.Recipe_Id= -1;";

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ChompoDexDB.Properties.Settings.connString"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            con.Open();

            SqlCommand myCommand = new SqlCommand(query, con);

            myCommand.ExecuteNonQuery();
            
            con.Close();
            catalogFormParentRef.ResetRecipeDataSource();
            }

        private void printRecipeButton_Click(object sender, EventArgs e)
            {
            string ingredientListString = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                ingredientListString += row.Cells[0].Value + " " + row.Cells[1].Value + " " + row.Cells[2].Value + Environment.NewLine;
                }
            
            StringBuilder output = new StringBuilder();
            output.Append(recipe_NameTextBox.Text + Environment.NewLine
                + "Cooking Time: " + cooking_TimeTextBox.Text + Environment.NewLine
                + ingredientListString + "Instructions: " + Environment.NewLine
                + instructionsTextBox.Text);

            PrintDocument document = new PrintDocument();
            document.PrintPage += delegate(object sender1, PrintPageEventArgs args1)
            {
                args1.Graphics.DrawString(output.ToString(),
                    new Font("Times New Roman", 14),
                    new SolidBrush(Color.Black),
                    new RectangleF(0, 0, document.DefaultPageSettings.PrintableArea.Width, document.DefaultPageSettings.PrintableArea.Height));
            };

            try
                {
                document.Print();
                }

            catch (Exception ex)
                {
                throw new Exception("Error Occured While Printing", ex);
                }
            }
        }
    }
