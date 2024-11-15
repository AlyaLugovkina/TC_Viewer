﻿namespace TC_WinForms.WinForms
{
    partial class Win7_1_TCs_Window
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
            label1 = new Label();
            txtArticle = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtTechProcessType = new TextBox();
            label4 = new Label();
            txtTechProcess = new TextBox();
            label5 = new Label();
            txtParametr = new TextBox();
            label6 = new Label();
            txtFinalProduct = new TextBox();
            label7 = new Label();
            txtApplicability = new TextBox();
            label8 = new Label();
            txtNote = new TextBox();
            label9 = new Label();
            label10 = new Label();
            chbxIsCompleted = new CheckBox();
            cbxType = new ComboBox();
            cbxNetworkVoltage = new ComboBox();
            btnSaveAndOpen = new Button();
            btnSave = new Button();
            btnExportExcel = new Button();
            txtName = new TextBox();
            lblName = new Label();
            cbxStatus = new ComboBox();
            lblStatus = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(23, 54);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Артикул";
            // 
            // txtArticle
            // 
            txtArticle.Location = new Point(214, 51);
            txtArticle.Name = "txtArticle";
            txtArticle.Size = new Size(503, 27);
            txtArticle.TabIndex = 2;
            txtArticle.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 97);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 2;
            label2.Text = "Тип карты";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 141);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 4;
            label3.Text = "Сеть, кВ";
            // 
            // txtTechProcessType
            // 
            txtTechProcessType.Location = new Point(214, 181);
            txtTechProcessType.Name = "txtTechProcessType";
            txtTechProcessType.Size = new Size(503, 27);
            txtTechProcessType.TabIndex = 5;
            txtTechProcessType.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 184);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 6;
            label4.Text = "Тип тех. процесса";
            // 
            // txtTechProcess
            // 
            txtTechProcess.Location = new Point(214, 226);
            txtTechProcess.Name = "txtTechProcess";
            txtTechProcess.Size = new Size(503, 27);
            txtTechProcess.TabIndex = 6;
            txtTechProcess.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 229);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 8;
            label5.Text = "Тех. процесс";
            // 
            // txtParametr
            // 
            txtParametr.Location = new Point(214, 271);
            txtParametr.Name = "txtParametr";
            txtParametr.Size = new Size(503, 27);
            txtParametr.TabIndex = 7;
            txtParametr.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 274);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 10;
            label6.Text = "Параметр";
            // 
            // txtFinalProduct
            // 
            txtFinalProduct.Location = new Point(214, 317);
            txtFinalProduct.Name = "txtFinalProduct";
            txtFinalProduct.Size = new Size(503, 27);
            txtFinalProduct.TabIndex = 8;
            txtFinalProduct.TextChanged += textBox1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 320);
            label7.Name = "label7";
            label7.Size = new Size(140, 20);
            label7.TabIndex = 12;
            label7.Text = "Конечный продукт";
            // 
            // txtApplicability
            // 
            txtApplicability.Location = new Point(214, 360);
            txtApplicability.Name = "txtApplicability";
            txtApplicability.Size = new Size(503, 27);
            txtApplicability.TabIndex = 9;
            txtApplicability.TextChanged += textBox1_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 363);
            label8.Name = "label8";
            label8.Size = new Size(189, 20);
            label8.TabIndex = 14;
            label8.Text = "Применимость тех. карты";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(214, 406);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(503, 27);
            txtNote.TabIndex = 10;
            txtNote.TextChanged += textBox1_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 409);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 16;
            label9.Text = "Примечания";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(610, 459);
            label10.Name = "label10";
            label10.Size = new Size(70, 20);
            label10.TabIndex = 18;
            label10.Text = "Наличие";
            label10.Visible = false;
            // 
            // chbxIsCompleted
            // 
            chbxIsCompleted.AutoSize = true;
            chbxIsCompleted.Location = new Point(696, 459);
            chbxIsCompleted.Name = "chbxIsCompleted";
            chbxIsCompleted.Size = new Size(18, 17);
            chbxIsCompleted.TabIndex = 19;
            chbxIsCompleted.UseVisualStyleBackColor = true;
            chbxIsCompleted.Visible = false;
            // 
            // cbxType
            // 
            cbxType.FormattingEnabled = true;
            cbxType.Location = new Point(214, 94);
            cbxType.Name = "cbxType";
            cbxType.Size = new Size(256, 28);
            cbxType.TabIndex = 3;
            cbxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
            // 
            // cbxNetworkVoltage
            // 
            cbxNetworkVoltage.FormattingEnabled = true;
            cbxNetworkVoltage.Location = new Point(214, 138);
            cbxNetworkVoltage.Name = "cbxNetworkVoltage";
            cbxNetworkVoltage.Size = new Size(256, 28);
            cbxNetworkVoltage.TabIndex = 4;
            cbxNetworkVoltage.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
            // 
            // btnSaveAndOpen
            // 
            btnSaveAndOpen.Location = new Point(23, 500);
            btnSaveAndOpen.Name = "btnSaveAndOpen";
            btnSaveAndOpen.Size = new Size(209, 63);
            btnSaveAndOpen.TabIndex = 22;
            btnSaveAndOpen.Text = "Открыть";
            btnSaveAndOpen.UseVisualStyleBackColor = true;
            btnSaveAndOpen.Click += btnSaveAndOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(248, 500);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(221, 63);
            btnSave.TabIndex = 23;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(590, 500);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(126, 63);
            btnExportExcel.TabIndex = 24;
            btnExportExcel.Text = "Печать";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(214, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(503, 27);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(23, 15);
            lblName.Name = "lblName";
            lblName.Size = new Size(116, 20);
            lblName.TabIndex = 25;
            lblName.Text = "Наименование";
            // 
            // cbxStatus
            // 
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Location = new Point(214, 451);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(256, 28);
            cbxStatus.TabIndex = 11;
            cbxStatus.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(23, 454);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 27;
            lblStatus.Text = "Статус";
            lblStatus.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(cbxStatus);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(txtArticle);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnExportExcel);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(txtTechProcessType);
            panel1.Controls.Add(btnSaveAndOpen);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbxNetworkVoltage);
            panel1.Controls.Add(txtTechProcess);
            panel1.Controls.Add(cbxType);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(chbxIsCompleted);
            panel1.Controls.Add(txtParametr);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(txtFinalProduct);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtApplicability);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 632);
            panel1.TabIndex = 28;
            // 
            // Win7_1_TCs_Window
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 632);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimumSize = new Size(780, 518);
            Name = "Win7_1_TCs_Window";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Win7_1_TCs_Window";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtArticle;
        private Label label2;
        private Label label3;
        private TextBox txtTechProcessType;
        private Label label4;
        private TextBox txtTechProcess;
        private Label label5;
        private TextBox txtParametr;
        private Label label6;
        private TextBox txtFinalProduct;
        private Label label7;
        private TextBox txtApplicability;
        private Label label8;
        private TextBox txtNote;
        private Label label9;
        private Label label10;
        private CheckBox chbxIsCompleted;
        private ComboBox cbxType;
        private ComboBox cbxNetworkVoltage;
        private Button btnSaveAndOpen;
        private Button button2;
        private Button btnExportExcel;
        private Button btnSave;
        private TextBox txtName;
        private Label lblName;
        private ComboBox cbxStatus;
        private Label lblStatus;
        private Panel panel1;
    }
}