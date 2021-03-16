namespace WindowsFormsApp1
{
    partial class Graph
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GraphXYZ = new System.Windows.Forms.PictureBox();
            this.GraphSpeed = new System.Windows.Forms.PictureBox();
            this.Kutt = new System.Windows.Forms.Button();
            this.Eiler = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphXYZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphXYZ
            // 
            this.GraphXYZ.BackColor = System.Drawing.Color.White;
            this.GraphXYZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphXYZ.Location = new System.Drawing.Point(33, 12);
            this.GraphXYZ.Name = "GraphXYZ";
            this.GraphXYZ.Size = new System.Drawing.Size(909, 191);
            this.GraphXYZ.TabIndex = 0;
            this.GraphXYZ.TabStop = false;
            // 
            // GraphSpeed
            // 
            this.GraphSpeed.BackColor = System.Drawing.Color.White;
            this.GraphSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphSpeed.Location = new System.Drawing.Point(33, 225);
            this.GraphSpeed.Name = "GraphSpeed";
            this.GraphSpeed.Size = new System.Drawing.Size(909, 179);
            this.GraphSpeed.TabIndex = 1;
            this.GraphSpeed.TabStop = false;
            // 
            // Kutt
            // 
            this.Kutt.BackColor = System.Drawing.SystemColors.Info;
            this.Kutt.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold);
            this.Kutt.Location = new System.Drawing.Point(33, 429);
            this.Kutt.Name = "Kutt";
            this.Kutt.Size = new System.Drawing.Size(160, 38);
            this.Kutt.TabIndex = 2;
            this.Kutt.Text = "Рунге-Кутт";
            this.Kutt.UseVisualStyleBackColor = false;
            this.Kutt.Click += new System.EventHandler(this.Kutt_Click);
            // 
            // Eiler
            // 
            this.Eiler.BackColor = System.Drawing.SystemColors.Info;
            this.Eiler.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold);
            this.Eiler.Location = new System.Drawing.Point(212, 429);
            this.Eiler.Name = "Eiler";
            this.Eiler.Size = new System.Drawing.Size(160, 38);
            this.Eiler.TabIndex = 3;
            this.Eiler.Text = "Эйлер";
            this.Eiler.UseVisualStyleBackColor = false;
            this.Eiler.Click += new System.EventHandler(this.Eiler_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(781, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.image;
            this.ClientSize = new System.Drawing.Size(987, 504);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Eiler);
            this.Controls.Add(this.Kutt);
            this.Controls.Add(this.GraphSpeed);
            this.Controls.Add(this.GraphXYZ);
            this.Name = "Graph";
            this.Text = "Графики";
            ((System.ComponentModel.ISupportInitialize)(this.GraphXYZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphXYZ;
        private System.Windows.Forms.PictureBox GraphSpeed;
        private System.Windows.Forms.Button Kutt;
        private System.Windows.Forms.Button Eiler;
        private System.Windows.Forms.Button button1;
    }
}

