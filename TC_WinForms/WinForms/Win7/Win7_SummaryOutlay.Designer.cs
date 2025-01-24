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
            pnlControls = new Panel();
            pnlDgv = new Panel();
            dgvMain = new DataGridView();
            txtSearch = new TextBox();
            cmbxUnit = new ComboBox();
            btnPrint = new Button();
            tbpnlMain.SuspendLayout();
            pnlControls.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // tbpnlMain
            // 
            tbpnlMain.ColumnCount = 1;
            tbpnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbpnlMain.Controls.Add(pnlControls, 0, 0);
            tbpnlMain.Controls.Add(pnlDgv, 0, 1);
            tbpnlMain.Dock = DockStyle.Fill;
            tbpnlMain.Location = new Point(0, 0);
            tbpnlMain.Name = "tbpnlMain";
            tbpnlMain.RowCount = 2;
            tbpnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10.662281F));
            tbpnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3377151F));
            tbpnlMain.Size = new Size(800, 450);
            tbpnlMain.TabIndex = 0;
            // 
            // pnlControls
            // 
            pnlControls.Controls.Add(btnPrint);
            pnlControls.Controls.Add(cmbxUnit);
            pnlControls.Controls.Add(txtSearch);
            pnlControls.Dock = DockStyle.Fill;
            pnlControls.Location = new Point(3, 3);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(794, 41);
            pnlControls.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvMain);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(3, 50);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(3, 4, 3, 4);
            pnlDgv.Size = new Size(794, 397);
            pnlDgv.TabIndex = 1;
            // 
            // dgvMain
            // 
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = DockStyle.Fill;
            dgvMain.Location = new Point(3, 4);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new Size(788, 389);
            dgvMain.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(9, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(228, 23);
            txtSearch.TabIndex = 0;
            // 
            // cmbxUnit
            // 
            cmbxUnit.FormattingEnabled = true;
            cmbxUnit.Location = new Point(243, 9);
            cmbxUnit.Name = "cmbxUnit";
            cmbxUnit.Size = new Size(121, 23);
            cmbxUnit.TabIndex = 1;
            cmbxUnit.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(655, 9);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(130, 23);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Печать";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += button1_Click;
            // 
            // Win7_SummaryOutlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbpnlMain);
            Name = "Win7_SummaryOutlay";
            Text = "Win7_SummaryOutlay";
            Load += Win7_SummaryOutlay_Load;
            tbpnlMain.ResumeLayout(false);
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
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
    }
}