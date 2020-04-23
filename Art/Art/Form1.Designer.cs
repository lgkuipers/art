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
            this.ivPbImage.Location = new System.Drawing.Point(59, 91);
            this.ivPbImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ivPbImage.Name = "ivPbImage";
            this.ivPbImage.Size = new System.Drawing.Size(727, 647);
            this.ivPbImage.TabIndex = 0;
            this.ivPbImage.TabStop = false;
            // 
            // ivBtnDraw
            // 
            this.ivBtnDraw.Location = new System.Drawing.Point(411, 48);
            this.ivBtnDraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ivBtnDraw.Name = "ivBtnDraw";
            this.ivBtnDraw.Size = new System.Drawing.Size(100, 28);
            this.ivBtnDraw.TabIndex = 1;
            this.ivBtnDraw.Text = "Draw";
            this.ivBtnDraw.UseVisualStyleBackColor = true;
            this.ivBtnDraw.Click += new System.EventHandler(this.ivBtnDraw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 785);
            this.Controls.Add(this.ivBtnDraw);
            this.Controls.Add(this.ivPbImage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

