
namespace Project_Z_Creator
{
    partial class Form1
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
            this.lbChosenTraits = new System.Windows.Forms.ListBox();
            this.cbOccupations = new System.Windows.Forms.ComboBox();
            this.lbSkills = new System.Windows.Forms.ListBox();
            this.cbPosTraits = new System.Windows.Forms.ComboBox();
            this.cbNegTraits = new System.Windows.Forms.ComboBox();
            this.lbPoints = new System.Windows.Forms.Label();
            this.tbCharacterName = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbChosenTraits
            // 
            this.lbChosenTraits.FormattingEnabled = true;
            this.lbChosenTraits.ItemHeight = 16;
            this.lbChosenTraits.Location = new System.Drawing.Point(572, 77);
            this.lbChosenTraits.Name = "lbChosenTraits";
            this.lbChosenTraits.Size = new System.Drawing.Size(168, 132);
            this.lbChosenTraits.TabIndex = 0;
            this.lbChosenTraits.DoubleClick += new System.EventHandler(this.lbChosenTraits_DoubleClick);
            // 
            // cbOccupations
            // 
            this.cbOccupations.FormattingEnabled = true;
            this.cbOccupations.Location = new System.Drawing.Point(71, 46);
            this.cbOccupations.Name = "cbOccupations";
            this.cbOccupations.Size = new System.Drawing.Size(104, 24);
            this.cbOccupations.TabIndex = 1;
            this.cbOccupations.SelectedIndexChanged += new System.EventHandler(this.cbOccupations_SelectedIndexChanged);
            // 
            // lbSkills
            // 
            this.lbSkills.FormattingEnabled = true;
            this.lbSkills.ItemHeight = 16;
            this.lbSkills.Location = new System.Drawing.Point(572, 215);
            this.lbSkills.Name = "lbSkills";
            this.lbSkills.Size = new System.Drawing.Size(168, 132);
            this.lbSkills.TabIndex = 2;
            // 
            // cbPosTraits
            // 
            this.cbPosTraits.FormattingEnabled = true;
            this.cbPosTraits.Location = new System.Drawing.Point(317, 46);
            this.cbPosTraits.Name = "cbPosTraits";
            this.cbPosTraits.Size = new System.Drawing.Size(104, 24);
            this.cbPosTraits.TabIndex = 3;
            this.cbPosTraits.SelectedIndexChanged += new System.EventHandler(this.cbPosTraits_SelectedIndexChanged);
            // 
            // cbNegTraits
            // 
            this.cbNegTraits.FormattingEnabled = true;
            this.cbNegTraits.Location = new System.Drawing.Point(317, 272);
            this.cbNegTraits.Name = "cbNegTraits";
            this.cbNegTraits.Size = new System.Drawing.Size(104, 24);
            this.cbNegTraits.TabIndex = 4;
            this.cbNegTraits.SelectedIndexChanged += new System.EventHandler(this.cbNegTraits_SelectedIndexChanged);
            // 
            // lbPoints
            // 
            this.lbPoints.AutoSize = true;
            this.lbPoints.Location = new System.Drawing.Point(656, 356);
            this.lbPoints.Name = "lbPoints";
            this.lbPoints.Size = new System.Drawing.Size(44, 16);
            this.lbPoints.TabIndex = 5;
            this.lbPoints.Text = "Points";
            // 
            // tbCharacterName
            // 
            this.tbCharacterName.Location = new System.Drawing.Point(572, 415);
            this.tbCharacterName.Name = "tbCharacterName";
            this.tbCharacterName.Size = new System.Drawing.Size(78, 22);
            this.tbCharacterName.TabIndex = 6;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(665, 415);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 7;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(706, 353);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(34, 22);
            this.tbCost.TabIndex = 8;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(662, 54);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(0, 16);
            this.lblOccupation.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(569, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 16);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "No Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbCharacterName);
            this.Controls.Add(this.lbPoints);
            this.Controls.Add(this.cbNegTraits);
            this.Controls.Add(this.cbPosTraits);
            this.Controls.Add(this.lbSkills);
            this.Controls.Add(this.cbOccupations);
            this.Controls.Add(this.lbChosenTraits);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbChosenTraits;
        private System.Windows.Forms.ComboBox cbOccupations;
        private System.Windows.Forms.ListBox lbSkills;
        private System.Windows.Forms.ComboBox cbPosTraits;
        private System.Windows.Forms.ComboBox cbNegTraits;
        private System.Windows.Forms.Label lbPoints;
        private System.Windows.Forms.TextBox tbCharacterName;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label lblName;
    }
}

