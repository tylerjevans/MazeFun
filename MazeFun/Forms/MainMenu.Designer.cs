namespace MazeFun
{
    partial class MainMenu
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
            this.HeightText = new System.Windows.Forms.TextBox();
            this.HeightValue = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.WidthValue = new System.Windows.Forms.NumericUpDown();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.InteractiveModeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthValue)).BeginInit();
            this.SuspendLayout();
            // 
            // HeightText
            // 
            this.HeightText.Location = new System.Drawing.Point(70, 59);
            this.HeightText.Name = "HeightText";
            this.HeightText.ReadOnly = true;
            this.HeightText.Size = new System.Drawing.Size(40, 20);
            this.HeightText.TabIndex = 0;
            this.HeightText.Text = "Height:";
            // 
            // HeightValue
            // 
            this.HeightValue.Location = new System.Drawing.Point(117, 58);
            this.HeightValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HeightValue.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HeightValue.Name = "HeightValue";
            this.HeightValue.Size = new System.Drawing.Size(120, 20);
            this.HeightValue.TabIndex = 1;
            this.HeightValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Width:";
            // 
            // WidthValue
            // 
            this.WidthValue.Location = new System.Drawing.Point(117, 86);
            this.WidthValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthValue.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WidthValue.Name = "WidthValue";
            this.WidthValue.Size = new System.Drawing.Size(120, 20);
            this.WidthValue.TabIndex = 3;
            this.WidthValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(70, 113);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(167, 23);
            this.GenerateButton.TabIndex = 4;
            this.GenerateButton.Text = "Generate and Save";
            this.GenerateButton.UseVisualStyleBackColor = true;
            // 
            // InteractiveModeButton
            // 
            this.InteractiveModeButton.Location = new System.Drawing.Point(70, 143);
            this.InteractiveModeButton.Name = "InteractiveModeButton";
            this.InteractiveModeButton.Size = new System.Drawing.Size(167, 23);
            this.InteractiveModeButton.TabIndex = 5;
            this.InteractiveModeButton.Text = "Interactive Mode";
            this.InteractiveModeButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 220);
            this.Controls.Add(this.InteractiveModeButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.WidthValue);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.HeightValue);
            this.Controls.Add(this.HeightText);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Menu";
            ((System.ComponentModel.ISupportInitialize)(this.HeightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HeightText;
        private System.Windows.Forms.NumericUpDown HeightValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown WidthValue;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button InteractiveModeButton;
    }
}

