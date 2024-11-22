namespace UDP_client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBoxLondonTime = new CheckBox();
            textBoxServerIP = new TextBox();
            buttonSyncTime = new Button();
            dataGridViewTimes = new DataGridView();
            buttonShowTable = new Button();
            buttonClose = new Button();
            label1 = new Label();
            labelTime = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimes).BeginInit();
            SuspendLayout();
            // 
            // checkBoxLondonTime
            // 
            checkBoxLondonTime.AutoSize = true;
            checkBoxLondonTime.Location = new Point(177, 166);
            checkBoxLondonTime.Name = "checkBoxLondonTime";
            checkBoxLondonTime.Size = new Size(118, 24);
            checkBoxLondonTime.TabIndex = 0;
            checkBoxLondonTime.Text = "London Time";
            checkBoxLondonTime.UseVisualStyleBackColor = true;
            // 
            // textBoxServerIP
            // 
            textBoxServerIP.Font = new Font("Segoe UI", 14F);
            textBoxServerIP.Location = new Point(42, 48);
            textBoxServerIP.Name = "textBoxServerIP";
            textBoxServerIP.Size = new Size(202, 39);
            textBoxServerIP.TabIndex = 1;
            // 
            // buttonSyncTime
            // 
            buttonSyncTime.Location = new Point(43, 152);
            buttonSyncTime.Name = "buttonSyncTime";
            buttonSyncTime.Size = new Size(128, 50);
            buttonSyncTime.TabIndex = 2;
            buttonSyncTime.Text = "Синхронізувати час";
            buttonSyncTime.UseVisualStyleBackColor = true;
            buttonSyncTime.Click += buttonSyncTime_Click_1;
            // 
            // dataGridViewTimes
            // 
            dataGridViewTimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTimes.Location = new Point(337, 85);
            dataGridViewTimes.Name = "dataGridViewTimes";
            dataGridViewTimes.RowHeadersWidth = 51;
            dataGridViewTimes.Size = new Size(384, 175);
            dataGridViewTimes.TabIndex = 3;
            // 
            // buttonShowTable
            // 
            buttonShowTable.Location = new Point(43, 208);
            buttonShowTable.Name = "buttonShowTable";
            buttonShowTable.Size = new Size(128, 52);
            buttonShowTable.TabIndex = 4;
            buttonShowTable.Text = "Вивести таблицю";
            buttonShowTable.UseVisualStyleBackColor = true;
            buttonShowTable.Click += buttonShowTable_Click_1;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(42, 266);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(128, 49);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Закрити програму";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(3, 51);
            label1.Name = "label1";
            label1.Size = new Size(38, 32);
            label1.TabIndex = 6;
            label1.Text = "IP:";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(12, 318);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(70, 20);
            labelTime.TabIndex = 7;
            labelTime.Text = "Вивід тут";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelTime);
            Controls.Add(label1);
            Controls.Add(buttonClose);
            Controls.Add(buttonShowTable);
            Controls.Add(dataGridViewTimes);
            Controls.Add(buttonSyncTime);
            Controls.Add(textBoxServerIP);
            Controls.Add(checkBoxLondonTime);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxLondonTime;
        private TextBox textBoxServerIP;
        private Button buttonSyncTime;
        private DataGridView dataGridViewTimes;
        private Button buttonShowTable;
        private Button buttonClose;
        private Label label1;
        private Label labelTime;
    }
}
