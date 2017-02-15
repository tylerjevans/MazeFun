namespace MazeFun.Forms
{
    partial class Interactive
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
            this.BigGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BigGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BigGridView
            // 
            this.BigGridView.AllowUserToAddRows = false;
            this.BigGridView.AllowUserToDeleteRows = false;
            this.BigGridView.AllowUserToResizeColumns = false;
            this.BigGridView.AllowUserToResizeRows = false;
            this.BigGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BigGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BigGridView.Location = new System.Drawing.Point(0, 0);
            this.BigGridView.Name = "BigGridView";
            this.BigGridView.Size = new System.Drawing.Size(472, 339);
            this.BigGridView.TabIndex = 0;
            this.BigGridView.VirtualMode = true;
            // 
            // Interactive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 335);
            this.Controls.Add(this.BigGridView);
            this.Name = "Interactive";
            this.Text = "Interactive";
            ((System.ComponentModel.ISupportInitialize)(this.BigGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BigGridView;
    }
}