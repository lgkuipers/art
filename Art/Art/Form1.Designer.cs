namespace Art
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
            this.ivPbImage = new System.Windows.Forms.PictureBox();
            this.ivBtnDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ivPbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ivPbImage
            // 
            this.ivPbImage.Location = new System.Drawing.Point(44, 74);
            this.ivPbImage.Name = "ivPbImage";
            this.ivPbImage.Size = new System.Drawing.Size(645, 447);
            this.ivPbImage.TabIndex = 0;
            this.ivPbImage.TabStop = false;
            // 
            // ivBtnDraw
            // 
            this.ivBtnDraw.Location = new System.Drawing.Point(308, 39);
            this.ivBtnDraw.Name = "ivBtnDraw";
            this.ivBtnDraw.Size = new System.Drawing.Size(75, 23);
            this.ivBtnDraw.TabIndex = 1;
            this.ivBtnDraw.Text = "Draw";
            this.ivBtnDraw.UseVisualStyleBackColor = true;
            this.ivBtnDraw.Click += new System.EventHandler(this.ivBtnDraw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 592);
            this.Controls.Add(this.ivBtnDraw);
            this.Controls.Add(this.ivPbImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ivPbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ivPbImage;
        private System.Windows.Forms.Button ivBtnDraw;
    }
}

