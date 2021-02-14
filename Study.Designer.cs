
namespace StudyEnglishWord
{
    partial class frmStudy
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
            this.btnDictSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDictSearch
            // 
            this.btnDictSearch.Location = new System.Drawing.Point(263, 12);
            this.btnDictSearch.Name = "btnDictSearch";
            this.btnDictSearch.Size = new System.Drawing.Size(75, 23);
            this.btnDictSearch.TabIndex = 0;
            this.btnDictSearch.Text = "사전 검색";
            this.btnDictSearch.UseVisualStyleBackColor = true;
            this.btnDictSearch.Click += new System.EventHandler(this.btnDictSearch_Click);
            // 
            // frmStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(350, 535);
            this.ControlBox = false;
            this.Controls.Add(this.btnDictSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmStudy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDictSearch;
    }
}