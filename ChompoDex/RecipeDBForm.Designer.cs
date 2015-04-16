namespace ChompoDexDB
    {
    partial class RecipeDBForm
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label recipe_NameLabel;
            System.Windows.Forms.Label cooking_TimeLabel;
            System.Windows.Forms.Label instructionsLabel;
            System.Windows.Forms.Label ingredient_NameLabel;
            System.Windows.Forms.Label amountLabel;
            System.Windows.Forms.Label measurement_NameLabel;
            this.recipe_NameTextBox = new System.Windows.Forms.TextBox();
            this.cooking_TimeTextBox = new System.Windows.Forms.TextBox();
            this.instructionsTextBox = new System.Windows.Forms.TextBox();
            this.ingredient_NameTextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.MaskedTextBox();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.removeIngredientButton = new System.Windows.Forms.Button();
            this.ingredientsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ingredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chompoDexDatabaseDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chompoDexDatabaseDataSet1 = new ChompoDexDB.ChompoDexDatabaseDataSet();
            this.chompoDexDatabaseDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.measurementName_comboBox = new System.Windows.Forms.ComboBox();
            this.measurementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.measurementsTableAdapter1 = new ChompoDexDB.ChompoDexDatabaseDataSetTableAdapters.MeasurementsTableAdapter();
            this.recipeOKButton = new System.Windows.Forms.Button();
            this.recipeCancelButton = new System.Windows.Forms.Button();
            this.ingredientsTableAdapter1 = new ChompoDexDB.ChompoDexDatabaseDataSetTableAdapters.IngredientsTableAdapter();
            this.printRecipeButton = new System.Windows.Forms.Button();
            recipe_NameLabel = new System.Windows.Forms.Label();
            cooking_TimeLabel = new System.Windows.Forms.Label();
            instructionsLabel = new System.Windows.Forms.Label();
            ingredient_NameLabel = new System.Windows.Forms.Label();
            amountLabel = new System.Windows.Forms.Label();
            measurement_NameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chompoDexDatabaseDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chompoDexDatabaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chompoDexDatabaseDataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // recipe_NameLabel
            // 
            recipe_NameLabel.AutoSize = true;
            recipe_NameLabel.Location = new System.Drawing.Point(37, 57);
            recipe_NameLabel.Name = "recipe_NameLabel";
            recipe_NameLabel.Size = new System.Drawing.Size(75, 13);
            recipe_NameLabel.TabIndex = 3;
            recipe_NameLabel.Text = "Recipe Name:";
            // 
            // cooking_TimeLabel
            // 
            cooking_TimeLabel.AutoSize = true;
            cooking_TimeLabel.Location = new System.Drawing.Point(226, 60);
            cooking_TimeLabel.Name = "cooking_TimeLabel";
            cooking_TimeLabel.Size = new System.Drawing.Size(75, 13);
            cooking_TimeLabel.TabIndex = 5;
            cooking_TimeLabel.Text = "Cooking Time:";
            // 
            // instructionsLabel
            // 
            instructionsLabel.AutoSize = true;
            instructionsLabel.Location = new System.Drawing.Point(37, 334);
            instructionsLabel.Name = "instructionsLabel";
            instructionsLabel.Size = new System.Drawing.Size(64, 13);
            instructionsLabel.TabIndex = 7;
            instructionsLabel.Text = "Instructions:";
            // 
            // ingredient_NameLabel
            // 
            ingredient_NameLabel.AutoSize = true;
            ingredient_NameLabel.Location = new System.Drawing.Point(37, 109);
            ingredient_NameLabel.Name = "ingredient_NameLabel";
            ingredient_NameLabel.Size = new System.Drawing.Size(88, 13);
            ingredient_NameLabel.TabIndex = 10;
            ingredient_NameLabel.Text = "Ingredient Name:";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new System.Drawing.Point(37, 135);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new System.Drawing.Size(46, 13);
            amountLabel.TabIndex = 12;
            amountLabel.Text = "Amount:";
            // 
            // measurement_NameLabel
            // 
            measurement_NameLabel.AutoSize = true;
            measurement_NameLabel.Location = new System.Drawing.Point(37, 161);
            measurement_NameLabel.Name = "measurement_NameLabel";
            measurement_NameLabel.Size = new System.Drawing.Size(105, 13);
            measurement_NameLabel.TabIndex = 16;
            measurement_NameLabel.Text = "Measurement Name:";
            // 
            // recipe_NameTextBox
            // 
            this.recipe_NameTextBox.Location = new System.Drawing.Point(118, 54);
            this.recipe_NameTextBox.Name = "recipe_NameTextBox";
            this.recipe_NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.recipe_NameTextBox.TabIndex = 4;
            // 
            // cooking_TimeTextBox
            // 
            this.cooking_TimeTextBox.Location = new System.Drawing.Point(307, 57);
            this.cooking_TimeTextBox.Name = "cooking_TimeTextBox";
            this.cooking_TimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.cooking_TimeTextBox.TabIndex = 6;
            // 
            // instructionsTextBox
            // 
            this.instructionsTextBox.Location = new System.Drawing.Point(118, 331);
            this.instructionsTextBox.Multiline = true;
            this.instructionsTextBox.Name = "instructionsTextBox";
            this.instructionsTextBox.Size = new System.Drawing.Size(382, 102);
            this.instructionsTextBox.TabIndex = 8;
            // 
            // ingredient_NameTextBox
            // 
            this.ingredient_NameTextBox.Location = new System.Drawing.Point(148, 106);
            this.ingredient_NameTextBox.Name = "ingredient_NameTextBox";
            this.ingredient_NameTextBox.Size = new System.Drawing.Size(152, 20);
            this.ingredient_NameTextBox.TabIndex = 11;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(148, 132);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(45, 20);
            this.amountTextBox.TabIndex = 13;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(307, 104);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(109, 23);
            this.addIngredientButton.TabIndex = 14;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // removeIngredientButton
            // 
            this.removeIngredientButton.Location = new System.Drawing.Point(307, 135);
            this.removeIngredientButton.Name = "removeIngredientButton";
            this.removeIngredientButton.Size = new System.Drawing.Size(109, 23);
            this.removeIngredientButton.TabIndex = 15;
            this.removeIngredientButton.Text = "Remove Ingredient";
            this.removeIngredientButton.UseVisualStyleBackColor = true;
            this.removeIngredientButton.Click += new System.EventHandler(this.removeIngredientButton_Click);
            // 
            // ingredientsBindingSource1
            // 
            this.ingredientsBindingSource1.DataMember = "Ingredients";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(484, 107);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ingredientsBindingSource
            // 
            this.ingredientsBindingSource.DataMember = "Ingredients";
            this.ingredientsBindingSource.DataSource = this.chompoDexDatabaseDataSet1BindingSource;
            // 
            // chompoDexDatabaseDataSet1BindingSource
            // 
            this.chompoDexDatabaseDataSet1BindingSource.DataSource = this.chompoDexDatabaseDataSet1;
            this.chompoDexDatabaseDataSet1BindingSource.Position = 0;
            // 
            // chompoDexDatabaseDataSet1
            // 
            this.chompoDexDatabaseDataSet1.DataSetName = "ChompoDexDatabaseDataSet";
            this.chompoDexDatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chompoDexDatabaseDataSet1BindingSource1
            // 
            this.chompoDexDatabaseDataSet1BindingSource1.DataSource = this.chompoDexDatabaseDataSet1;
            this.chompoDexDatabaseDataSet1BindingSource1.Position = 0;
            // 
            // measurementName_comboBox
            // 
            this.measurementName_comboBox.DataSource = this.measurementsBindingSource;
            this.measurementName_comboBox.DisplayMember = "Measurement_Name";
            this.measurementName_comboBox.FormattingEnabled = true;
            this.measurementName_comboBox.Location = new System.Drawing.Point(148, 158);
            this.measurementName_comboBox.Name = "measurementName_comboBox";
            this.measurementName_comboBox.Size = new System.Drawing.Size(121, 21);
            this.measurementName_comboBox.TabIndex = 19;
            this.measurementName_comboBox.ValueMember = "Measurement_ID";
            // 
            // measurementsBindingSource
            // 
            this.measurementsBindingSource.DataMember = "Measurements";
            this.measurementsBindingSource.DataSource = this.chompoDexDatabaseDataSet1;
            // 
            // measurementsTableAdapter1
            // 
            this.measurementsTableAdapter1.ClearBeforeFill = true;
            // 
            // recipeOKButton
            // 
            this.recipeOKButton.Location = new System.Drawing.Point(425, 455);
            this.recipeOKButton.Name = "recipeOKButton";
            this.recipeOKButton.Size = new System.Drawing.Size(75, 23);
            this.recipeOKButton.TabIndex = 20;
            this.recipeOKButton.Text = "OK";
            this.recipeOKButton.UseVisualStyleBackColor = true;
            this.recipeOKButton.Click += new System.EventHandler(this.recipeOKButton_Click);
            // 
            // recipeCancelButton
            // 
            this.recipeCancelButton.Location = new System.Drawing.Point(118, 455);
            this.recipeCancelButton.Name = "recipeCancelButton";
            this.recipeCancelButton.Size = new System.Drawing.Size(75, 23);
            this.recipeCancelButton.TabIndex = 21;
            this.recipeCancelButton.Text = "Cancel";
            this.recipeCancelButton.UseVisualStyleBackColor = true;
            this.recipeCancelButton.Click += new System.EventHandler(this.recipeCancelButton_Click);
            // 
            // ingredientsTableAdapter1
            // 
            this.ingredientsTableAdapter1.ClearBeforeFill = true;
            // 
            // printRecipeButton
            // 
            this.printRecipeButton.Location = new System.Drawing.Point(473, 60);
            this.printRecipeButton.Name = "printRecipeButton";
            this.printRecipeButton.Size = new System.Drawing.Size(82, 23);
            this.printRecipeButton.TabIndex = 22;
            this.printRecipeButton.Text = "Print Recipe";
            this.printRecipeButton.UseVisualStyleBackColor = true;
            this.printRecipeButton.Click += new System.EventHandler(this.printRecipeButton_Click);
            // 
            // RecipeDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 495);
            this.Controls.Add(this.printRecipeButton);
            this.Controls.Add(this.recipeCancelButton);
            this.Controls.Add(this.recipeOKButton);
            this.Controls.Add(this.measurementName_comboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(measurement_NameLabel);
            this.Controls.Add(this.removeIngredientButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(ingredient_NameLabel);
            this.Controls.Add(this.ingredient_NameTextBox);
            this.Controls.Add(amountLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(recipe_NameLabel);
            this.Controls.Add(this.recipe_NameTextBox);
            this.Controls.Add(cooking_TimeLabel);
            this.Controls.Add(this.cooking_TimeTextBox);
            this.Controls.Add(instructionsLabel);
            this.Controls.Add(this.instructionsTextBox);
            this.Name = "RecipeDBForm";
            this.Text = "RecipeDBForm";
            this.Load += new System.EventHandler(this.RecipeDBForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chompoDexDatabaseDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chompoDexDatabaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chompoDexDatabaseDataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private ChompoDexDatabaseDataSet chompoDexDatabaseDataSet;
        private ChompoDexDatabaseDataSetTableAdapters.RecipesTableAdapter recipesTableAdapter;
        private ChompoDexDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private ChompoDexDatabaseDataSetTableAdapters.IngredientsTableAdapter ingredientsTableAdapter;
        private System.Windows.Forms.TextBox recipe_NameTextBox;
        private System.Windows.Forms.TextBox cooking_TimeTextBox;
        private System.Windows.Forms.TextBox instructionsTextBox;
        
        private System.Windows.Forms.TextBox ingredient_NameTextBox;
        private System.Windows.Forms.MaskedTextBox amountTextBox;
        private System.Windows.Forms.Button addIngredientButton;
        private System.Windows.Forms.Button removeIngredientButton;
        private ChompoDexDatabaseDataSetTableAdapters.MeasurementsTableAdapter measurementsTableAdapter;
        
        private System.Windows.Forms.BindingSource ingredientsBindingSource1;

        
        private System.Windows.Forms.BindingSource chompoDexDatabaseDataSet1BindingSource1;
        private ChompoDexDatabaseDataSet chompoDexDatabaseDataSet1;
        private System.Windows.Forms.BindingSource chompoDexDatabaseDataSet1BindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox measurementName_comboBox;
        private System.Windows.Forms.BindingSource measurementsBindingSource;
        private ChompoDexDatabaseDataSetTableAdapters.MeasurementsTableAdapter measurementsTableAdapter1;
        
        
        private System.Windows.Forms.Button recipeOKButton;
        private System.Windows.Forms.Button recipeCancelButton;
        private System.Windows.Forms.BindingSource ingredientsBindingSource;
        private ChompoDexDatabaseDataSetTableAdapters.IngredientsTableAdapter ingredientsTableAdapter1;
        private System.Windows.Forms.Button printRecipeButton;

        }
    }