namespace Milestone_1
{
    partial class ComplexityForm
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.LowComplexity = new System.Windows.Forms.RadioButton();
            this.MedComplexity = new System.Windows.Forms.RadioButton();
            this.HighComplexity = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PlayButton.Enabled = false;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.Location = new System.Drawing.Point(28, 187);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(175, 48);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play Game";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // LowComplexity
            // 
            this.LowComplexity.AutoSize = true;
            this.LowComplexity.Location = new System.Drawing.Point(85, 50);
            this.LowComplexity.Name = "LowComplexity";
            this.LowComplexity.Size = new System.Drawing.Size(45, 17);
            this.LowComplexity.TabIndex = 1;
            this.LowComplexity.TabStop = true;
            this.LowComplexity.Text = "Low";
            this.LowComplexity.UseVisualStyleBackColor = true;
            this.LowComplexity.CheckedChanged += new System.EventHandler(this.LowComplexity_CheckedChanged);
            // 
            // MedComplexity
            // 
            this.MedComplexity.AutoSize = true;
            this.MedComplexity.Location = new System.Drawing.Point(85, 89);
            this.MedComplexity.Name = "MedComplexity";
            this.MedComplexity.Size = new System.Drawing.Size(62, 17);
            this.MedComplexity.TabIndex = 1;
            this.MedComplexity.TabStop = true;
            this.MedComplexity.Text = "Medium";
            this.MedComplexity.UseVisualStyleBackColor = true;
            this.MedComplexity.CheckedChanged += new System.EventHandler(this.MedComplexity_CheckedChanged);
            // 
            // HighComplexity
            // 
            this.HighComplexity.AutoSize = true;
            this.HighComplexity.Location = new System.Drawing.Point(85, 124);
            this.HighComplexity.Name = "HighComplexity";
            this.HighComplexity.Size = new System.Drawing.Size(47, 17);
            this.HighComplexity.TabIndex = 1;
            this.HighComplexity.TabStop = true;
            this.HighComplexity.Text = "High";
            this.HighComplexity.UseVisualStyleBackColor = true;
            this.HighComplexity.CheckedChanged += new System.EventHandler(this.HighComplexity_CheckedChanged);
            // 
            // ComplexityForm
            // 
            this.AcceptButton = this.PlayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 257);
            this.Controls.Add(this.HighComplexity);
            this.Controls.Add(this.MedComplexity);
            this.Controls.Add(this.LowComplexity);
            this.Controls.Add(this.PlayButton);
            this.Name = "ComplexityForm";
            this.Text = "Difficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.RadioButton LowComplexity;
        private System.Windows.Forms.RadioButton MedComplexity;
        private System.Windows.Forms.RadioButton HighComplexity;
    }
}