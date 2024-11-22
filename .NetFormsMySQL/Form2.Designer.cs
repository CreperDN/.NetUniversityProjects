namespace L2_2
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbDeleting = new System.Windows.Forms.RadioButton();
            this.rbUpdating = new System.Windows.Forms.RadioButton();
            this.rbAdding = new System.Windows.Forms.RadioButton();
            this.rbGetting = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 398);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(778, 160);
            this.dataGridView1.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 22);
            this.label8.TabIndex = 48;
            this.label8.Text = "Результат останнього запиту";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 25);
            this.button2.TabIndex = 47;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 25);
            this.button1.TabIndex = 46;
            this.button1.Text = "Виконати запит";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 22);
            this.label7.TabIndex = 45;
            this.label7.Text = "ID";
            // 
            // textID
            // 
            this.textID.AccessibleName = "";
            this.textID.Location = new System.Drawing.Point(16, 268);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 22);
            this.textID.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 43;
            this.label2.Text = "Категорія";
            // 
            // textName
            // 
            this.textName.AccessibleName = "";
            this.textName.Location = new System.Drawing.Point(146, 268);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 22);
            this.textName.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 41;
            this.label1.Text = "Categories";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // rbDeleting
            // 
            this.rbDeleting.AutoSize = true;
            this.rbDeleting.Location = new System.Drawing.Point(24, 210);
            this.rbDeleting.Name = "rbDeleting";
            this.rbDeleting.Size = new System.Drawing.Size(100, 20);
            this.rbDeleting.TabIndex = 39;
            this.rbDeleting.TabStop = true;
            this.rbDeleting.Text = "Вилучення";
            this.rbDeleting.UseVisualStyleBackColor = true;
            // 
            // rbUpdating
            // 
            this.rbUpdating.AutoSize = true;
            this.rbUpdating.Location = new System.Drawing.Point(24, 184);
            this.rbUpdating.Name = "rbUpdating";
            this.rbUpdating.Size = new System.Drawing.Size(101, 20);
            this.rbUpdating.TabIndex = 38;
            this.rbUpdating.TabStop = true;
            this.rbUpdating.Text = "Оновлення";
            this.rbUpdating.UseVisualStyleBackColor = true;
            // 
            // rbAdding
            // 
            this.rbAdding.AutoSize = true;
            this.rbAdding.Location = new System.Drawing.Point(24, 158);
            this.rbAdding.Name = "rbAdding";
            this.rbAdding.Size = new System.Drawing.Size(100, 20);
            this.rbAdding.TabIndex = 37;
            this.rbAdding.TabStop = true;
            this.rbAdding.Text = "Додавання";
            this.rbAdding.UseVisualStyleBackColor = true;
            // 
            // rbGetting
            // 
            this.rbGetting.AutoSize = true;
            this.rbGetting.Location = new System.Drawing.Point(24, 132);
            this.rbGetting.Name = "rbGetting";
            this.rbGetting.Size = new System.Drawing.Size(101, 20);
            this.rbGetting.TabIndex = 36;
            this.rbGetting.TabStop = true;
            this.rbGetting.Text = "Отримання";
            this.rbGetting.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbDeleting);
            this.Controls.Add(this.rbUpdating);
            this.Controls.Add(this.rbAdding);
            this.Controls.Add(this.rbGetting);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbDeleting;
        private System.Windows.Forms.RadioButton rbUpdating;
        private System.Windows.Forms.RadioButton rbAdding;
        private System.Windows.Forms.RadioButton rbGetting;
    }
}