namespace WinFormsApp1.Views
{
    partial class MainView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AuthorBtn = new System.Windows.Forms.Button();
            this.BookBtn = new System.Windows.Forms.Button();
            this.PublisherBtn = new System.Windows.Forms.Button();
            this.GenreBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.AuthorBtn);
            this.panel1.Controls.Add(this.BookBtn);
            this.panel1.Controls.Add(this.PublisherBtn);
            this.panel1.Controls.Add(this.GenreBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 552);
            this.panel1.TabIndex = 1;
            // 
            // AuthorBtn
            // 
            this.AuthorBtn.FlatAppearance.BorderSize = 0;
            this.AuthorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AuthorBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuthorBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AuthorBtn.Location = new System.Drawing.Point(6, 104);
            this.AuthorBtn.Name = "AuthorBtn";
            this.AuthorBtn.Size = new System.Drawing.Size(222, 40);
            this.AuthorBtn.TabIndex = 7;
            this.AuthorBtn.Text = "Авторы";
            this.AuthorBtn.UseVisualStyleBackColor = true;
            // 
            // BookBtn
            // 
            this.BookBtn.FlatAppearance.BorderSize = 0;
            this.BookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BookBtn.Location = new System.Drawing.Point(3, 242);
            this.BookBtn.Name = "BookBtn";
            this.BookBtn.Size = new System.Drawing.Size(222, 40);
            this.BookBtn.TabIndex = 3;
            this.BookBtn.Text = "Книги";
            this.BookBtn.UseVisualStyleBackColor = true;
            // 
            // PublisherBtn
            // 
            this.PublisherBtn.FlatAppearance.BorderSize = 0;
            this.PublisherBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PublisherBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PublisherBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PublisherBtn.Location = new System.Drawing.Point(3, 196);
            this.PublisherBtn.Name = "PublisherBtn";
            this.PublisherBtn.Size = new System.Drawing.Size(222, 40);
            this.PublisherBtn.TabIndex = 2;
            this.PublisherBtn.Text = "Издатели";
            this.PublisherBtn.UseVisualStyleBackColor = true;
            // 
            // GenreBtn
            // 
            this.GenreBtn.FlatAppearance.BorderSize = 0;
            this.GenreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenreBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GenreBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GenreBtn.Location = new System.Drawing.Point(3, 150);
            this.GenreBtn.Name = "GenreBtn";
            this.GenreBtn.Size = new System.Drawing.Size(222, 40);
            this.GenreBtn.TabIndex = 1;
            this.GenreBtn.Text = "Жанры";
            this.GenreBtn.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 552);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Text = "MainView";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button AuthorBtn;
        private Button BookBtn;
        private Button PublisherBtn;
        private Button GenreBtn;
    }
}