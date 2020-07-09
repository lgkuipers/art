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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ivTbUp = new System.Windows.Forms.TextBox();
            this.ivTbDown = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ivTbOffsetX = new System.Windows.Forms.TextBox();
            this.ivTbOffsetY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ivPbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ivPbImage
            // 
            this.ivPbImage.Location = new System.Drawing.Point(59, 91);
            this.ivPbImage.Margin = new System.Windows.Forms.Padding(4);
            this.ivPbImage.Name = "ivPbImage";
            this.ivPbImage.Size = new System.Drawing.Size(727, 647);
            this.ivPbImage.TabIndex = 0;
            this.ivPbImage.TabStop = false;
            // 
            // ivBtnDraw
            // 
            this.ivBtnDraw.Location = new System.Drawing.Point(411, 48);
            this.ivBtnDraw.Margin = new System.Windows.Forms.Padding(4);
            this.ivBtnDraw.Name = "ivBtnDraw";
            this.ivBtnDraw.Size = new System.Drawing.Size(100, 28);
            this.ivBtnDraw.TabIndex = 1;
            this.ivBtnDraw.Text = "Draw";
            this.ivBtnDraw.UseVisualStyleBackColor = true;
            this.ivBtnDraw.Click += new System.EventHandler(this.ivBtnDraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(828, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Up";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(828, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Down";
            // 
            // ivTbUp
            // 
            this.ivTbUp.Location = new System.Drawing.Point(921, 199);
            this.ivTbUp.Name = "ivTbUp";
            this.ivTbUp.Size = new System.Drawing.Size(100, 22);
            this.ivTbUp.TabIndex = 4;
            this.ivTbUp.Text = "100";
            // 
            // ivTbDown
            // 
            this.ivTbDown.Location = new System.Drawing.Point(921, 315);
            this.ivTbDown.Name = "ivTbDown";
            this.ivTbDown.Size = new System.Drawing.Size(100, 22);
            this.ivTbDown.TabIndex = 5;
            this.ivTbDown.Text = "800";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(862, 746);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output in art.cnc na draw";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(828, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 504);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(862, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "x";
            // 
            // ivTbOffsetX
            // 
            this.ivTbOffsetX.Location = new System.Drawing.Point(921, 458);
            this.ivTbOffsetX.Name = "ivTbOffsetX";
            this.ivTbOffsetX.Size = new System.Drawing.Size(100, 22);
            this.ivTbOffsetX.TabIndex = 10;
            this.ivTbOffsetX.Text = "2.1";
            // 
            // ivTbOffsetY
            // 
            this.ivTbOffsetY.Location = new System.Drawing.Point(921, 501);
            this.ivTbOffsetY.Name = "ivTbOffsetY";
            this.ivTbOffsetY.Size = new System.Drawing.Size(100, 22);
            this.ivTbOffsetY.TabIndex = 11;
            this.ivTbOffsetY.Text = "2.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 785);
            this.Controls.Add(this.ivTbOffsetY);
            this.Controls.Add(this.ivTbOffsetX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ivTbDown);
            this.Controls.Add(this.ivTbUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ivBtnDraw);
            this.Controls.Add(this.ivPbImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ivPbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ivPbImage;
        private System.Windows.Forms.Button ivBtnDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ivTbUp;
        private System.Windows.Forms.TextBox ivTbDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ivTbOffsetX;
        private System.Windows.Forms.TextBox ivTbOffsetY;
    }
}

