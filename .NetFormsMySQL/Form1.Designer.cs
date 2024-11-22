namespace L2_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbDeleting = new System.Windows.Forms.RadioButton();
            this.rbUpdating = new System.Windows.Forms.RadioButton();
            this.rbAdding = new System.Windows.Forms.RadioButton();
            this.rbGetting = new System.Windows.Forms.RadioButton();
            this.cbID = new System.Windows.Forms.CheckBox();
            this.cbCategory = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textExperience = new System.Windows.Forms.TextBox();
            this.textMaxPlayers = new System.Windows.Forms.TextBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // rbDeleting
            // 
            this.rbDeleting.AutoSize = true;
            this.rbDeleting.Location = new System.Drawing.Point(12, 182);
            this.rbDeleting.Name = "rbDeleting";
            this.rbDeleting.Size = new System.Drawing.Size(100, 20);
            this.rbDeleting.TabIndex = 26;
            this.rbDeleting.TabStop = true;
            this.rbDeleting.Text = "Вилучення";
            this.rbDeleting.UseVisualStyleBackColor = true;
            // 
            // rbUpdating
            // 
            this.rbUpdating.AutoSize = true;
            this.rbUpdating.Location = new System.Drawing.Point(12, 156);
            this.rbUpdating.Name = "rbUpdating";
            this.rbUpdating.Size = new System.Drawing.Size(101, 20);
            this.rbUpdating.TabIndex = 25;
            this.rbUpdating.TabStop = true;
            this.rbUpdating.Text = "Оновлення";
            this.rbUpdating.UseVisualStyleBackColor = true;
            // 
            // rbAdding
            // 
            this.rbAdding.AutoSize = true;
            this.rbAdding.Location = new System.Drawing.Point(12, 130);
            this.rbAdding.Name = "rbAdding";
            this.rbAdding.Size = new System.Drawing.Size(100, 20);
            this.rbAdding.TabIndex = 24;
            this.rbAdding.TabStop = true;
            this.rbAdding.Text = "Додавання";
            this.rbAdding.UseVisualStyleBackColor = true;
            // 
            // rbGetting
            // 
            this.rbGetting.AutoSize = true;
            this.rbGetting.Location = new System.Drawing.Point(12, 104);
            this.rbGetting.Name = "rbGetting";
            this.rbGetting.Size = new System.Drawing.Size(101, 20);
            this.rbGetting.TabIndex = 23;
            this.rbGetting.TabStop = true;
            this.rbGetting.Text = "Отримання";
            this.rbGetting.UseVisualStyleBackColor = true;
            // 
            // cbID
            // 
            this.cbID.AutoSize = true;
            this.cbID.Location = new System.Drawing.Point(269, 104);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(62, 20);
            this.cbID.TabIndex = 22;
            this.cbID.Text = "За ID";
            this.cbID.UseVisualStyleBackColor = true;
            // 
            // cbCategory
            // 
            this.cbCategory.AutoSize = true;
            this.cbCategory.Location = new System.Drawing.Point(142, 104);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(122, 20);
            this.cbCategory.TabIndex = 21;
            this.cbCategory.Text = "За категорією";
            this.cbCategory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 29);
            this.label1.TabIndex = 20;
            this.label1.Text = "Gambling";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 22);
            this.label7.TabIndex = 38;
            this.label7.Text = "ID";
            // 
            // textID
            // 
            this.textID.AccessibleName = "";
            this.textID.Location = new System.Drawing.Point(9, 228);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 22);
            this.textID.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(670, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 22);
            this.label6.TabIndex = 36;
            this.label6.Text = "Категорія";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(540, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 22);
            this.label5.TabIndex = 35;
            this.label5.Text = "Досвід";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "Макс.Гравців";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 22);
            this.label3.TabIndex = 33;
            this.label3.Text = "Опис";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Назва";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "1. Карточна гра";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1. Карточна гра",
            "2. Автомати",
            "3. Рулетки"});
            this.comboBox1.Location = new System.Drawing.Point(674, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 31;
            this.comboBox1.Text = "1. Карточна гра";
            // 
            // textExperience
            // 
            this.textExperience.Location = new System.Drawing.Point(544, 228);
            this.textExperience.Name = "textExperience";
            this.textExperience.Size = new System.Drawing.Size(100, 22);
            this.textExperience.TabIndex = 30;
            // 
            // textMaxPlayers
            // 
            this.textMaxPlayers.Location = new System.Drawing.Point(406, 228);
            this.textMaxPlayers.Name = "textMaxPlayers";
            this.textMaxPlayers.Size = new System.Drawing.Size(100, 22);
            this.textMaxPlayers.TabIndex = 29;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(268, 228);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(100, 22);
            this.textDescription.TabIndex = 28;
            // 
            // textName
            // 
            this.textName.AccessibleName = "";
            this.textName.Location = new System.Drawing.Point(139, 228);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 22);
            this.textName.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-5, 354);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 185);
            this.dataGridView1.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 22);
            this.label8.TabIndex = 41;
            this.label8.Text = "Результат останнього запиту";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 25);
            this.button2.TabIndex = 40;
            this.button2.Text = "Категорії";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 25);
            this.button1.TabIndex = 39;
            this.button1.Text = "Виконати запит";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textExperience);
            this.Controls.Add(this.textMaxPlayers);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.rbDeleting);
            this.Controls.Add(this.rbUpdating);
            this.Controls.Add(this.rbAdding);
            this.Controls.Add(this.rbGetting);
            this.Controls.Add(this.cbID);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbDeleting;
        private System.Windows.Forms.RadioButton rbUpdating;
        private System.Windows.Forms.RadioButton rbAdding;
        private System.Windows.Forms.RadioButton rbGetting;
        private System.Windows.Forms.CheckBox cbID;
        private System.Windows.Forms.CheckBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textExperience;
        private System.Windows.Forms.TextBox textMaxPlayers;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

