namespace TC_WinForms.WinForms.Win7
{
    partial class Win7_SummaryOutlay
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
            tbpnlMain = new TableLayoutPanel();
            pnlDgv = new Panel();
            pnlControls = new Panel();
            btnPrint = new Button();
            cmbxUnit = new ComboBox();
            txtSearch = new TextBox();
            dgvMain = new DataGridView();
            pnlButtons = new Panel();
            tbpnlMain.SuspendLayout();
            pnlDgv.SuspendLayout();
            pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tbpnlMain
            // 
            tbpnlMain.ColumnCount = 1;
            tbpnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbpnlMain.Controls.Add(pnlDgv, 0, 1);
            tbpnlMain.Controls.Add(pnlControls, 0, 0);
            tbpnlMain.Dock = DockStyle.Fill;
            tbpnlMain.Location = new Point(0, 0);
            tbpnlMain.Name = "tbpnlMain";
            tbpnlMain.RowCount = 2;
            tbpnlMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tbpnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbpnlMain.Size = new Size(1021, 504);
            tbpnlMain.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvMain);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(3, 65);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(3, 4, 3, 4);
            pnlDgv.Size = new Size(1015, 436);
            pnlDgv.TabIndex = 1;
            // 
            // pnlControls
            // 
            pnlControls.AutoSize = true;
            pnlControls.Controls.Add(pnlButtons);
            pnlControls.Controls.Add(cmbxUnit);
            pnlControls.Controls.Add(txtSearch);
            pnlControls.Dock = DockStyle.Fill;
            pnlControls.Location = new Point(3, 3);
            pnlControls.Name = "pnlControls";
            pnlControls.Padding = new Padding(3);
            pnlControls.Size = new Size(1015, 56);
            pnlControls.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(68, 6);
            btnPrint.Margin = new Padding(10);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(122, 39);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Печать";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += button1_Click;
            // 
            // cmbxUnit
            // 
            cmbxUnit.FormattingEnabled = true;
            cmbxUnit.Location = new Point(243, 18);
            cmbxUnit.Name = "cmbxUnit";
            cmbxUnit.Size = new Size(129, 23);
            cmbxUnit.TabIndex = 1;
            cmbxUnit.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(9, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(228, 23);
            txtSearch.TabIndex = 0;
            // 
            // dgvMain
            // 
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = DockStyle.Fill;
            dgvMain.Location = new Point(3, 4);
            dgvMain.Name = "dgvMain";
            dgvMain.ReadOnly = true;
            dgvMain.Size = new Size(1009, 428);
            dgvMain.TabIndex = 0;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnPrint);
            pnlButtons.Dock = DockStyle.Right;
            pnlButtons.Location = new Point(812, 3);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(200, 50);
            pnlButtons.TabIndex = 0;
            // 
            // Win7_SummaryOutlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 504);
            Controls.Add(tbpnlMain);
            Name = "Win7_SummaryOutlay";
            Text = "Win7_SummaryOutlay";
            Load += Win7_SummaryOutlay_Load;
            tbpnlMain.ResumeLayout(false);
            tbpnlMain.PerformLayout();
            pnlDgv.ResumeLayout(false);
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbpnlMain;
        private Panel pnlControls;
        private ComboBox comboBox2;
        private ComboBox cmbxUnit;
        private TextBox txtSearch;
        private Panel pnlDgv;
        private DataGridView dgvMain;
        private Button btnPrint;
        private Panel panel1;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Panel pnlButtons;
    }
}