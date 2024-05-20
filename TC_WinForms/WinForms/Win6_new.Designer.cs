﻿namespace TC_WinForms.WinForms
{
    partial class Win6_new
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win6_new));
            toolStrip1 = new ToolStrip();
            toolStripButtonSaveChanges = new ToolStripButton();
            toolStripFile = new ToolStripSplitButton();
            SaveChangesToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            actionToolStripMenuItem = new ToolStripMenuItem();
            setDraftStatusToolStripMenuItem = new ToolStripMenuItem();
            setApprovedStatusToolStripMenuItem = new ToolStripMenuItem();
            setRemarksModeToolStripMenuItem = new ToolStripMenuItem();
            btnShowStaffs = new Button();
            btnShowComponents = new Button();
            btnShowMachines = new Button();
            btnShowProtections = new Button();
            btnShowTools = new Button();
            btnShowWorkSteps = new Button();
            pnlControls = new Panel();
            pnlDataViewer = new Panel();
            toolStrip1.SuspendLayout();
            pnlControls.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonSaveChanges, toolStripFile });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1363, 27);
            toolStrip1.TabIndex = 19;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSaveChanges
            // 
            toolStripButtonSaveChanges.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonSaveChanges.Image = (Image)resources.GetObject("toolStripButtonSaveChanges.Image");
            toolStripButtonSaveChanges.ImageTransparentColor = Color.Magenta;
            toolStripButtonSaveChanges.Name = "toolStripButtonSaveChanges";
            toolStripButtonSaveChanges.Size = new Size(87, 24);
            toolStripButtonSaveChanges.Text = "Сохранить";
            toolStripButtonSaveChanges.Visible = false;
            toolStripButtonSaveChanges.Click += toolStripButton4_Click;
            // 
            // toolStripFile
            // 
            toolStripFile.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripFile.DropDownItems.AddRange(new ToolStripItem[] { SaveChangesToolStripMenuItem, printToolStripMenuItem, updateToolStripMenuItem, actionToolStripMenuItem, setRemarksModeToolStripMenuItem });
            toolStripFile.Image = (Image)resources.GetObject("toolStripFile.Image");
            toolStripFile.ImageTransparentColor = Color.Magenta;
            toolStripFile.Name = "toolStripFile";
            toolStripFile.Size = new Size(84, 24);
            toolStripFile.Text = "Главная";
            // 
            // SaveChangesToolStripMenuItem
            // 
            SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem";
            SaveChangesToolStripMenuItem.Size = new Size(256, 26);
            SaveChangesToolStripMenuItem.Text = "Сохранить";
            SaveChangesToolStripMenuItem.Click += SaveChangesToolStripMenuItem_Click;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(256, 26);
            printToolStripMenuItem.Text = "Печать";
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(256, 26);
            updateToolStripMenuItem.Text = "Редактировать";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // actionToolStripMenuItem
            // 
            actionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setDraftStatusToolStripMenuItem, setApprovedStatusToolStripMenuItem });
            actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            actionToolStripMenuItem.Size = new Size(256, 26);
            actionToolStripMenuItem.Text = "Действия";
            // 
            // setDraftStatusToolStripMenuItem
            // 
            setDraftStatusToolStripMenuItem.Name = "setDraftStatusToolStripMenuItem";
            setDraftStatusToolStripMenuItem.Size = new Size(224, 26);
            setDraftStatusToolStripMenuItem.Text = "Выпустить ТК";
            setDraftStatusToolStripMenuItem.Click += setDraftStatusToolStripMenuItem_Click;
            // 
            // setApprovedStatusToolStripMenuItem
            // 
            setApprovedStatusToolStripMenuItem.Name = "setApprovedStatusToolStripMenuItem";
            setApprovedStatusToolStripMenuItem.Size = new Size(224, 26);
            setApprovedStatusToolStripMenuItem.Text = "Опубликовать ТК";
            setApprovedStatusToolStripMenuItem.Click += setApprovedStatusToolStripMenuItem_Click;
            // 
            // setRemarksModeToolStripMenuItem
            // 
            setRemarksModeToolStripMenuItem.Name = "setRemarksModeToolStripMenuItem";
            setRemarksModeToolStripMenuItem.Size = new Size(256, 26);
            setRemarksModeToolStripMenuItem.Text = "Показать комментарии";
            setRemarksModeToolStripMenuItem.Click += setRemarksModeToolStripMenuItem_Click;
            // 
            // btnShowStaffs
            // 
            btnShowStaffs.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowStaffs.Location = new Point(4, 0);
            btnShowStaffs.Name = "btnShowStaffs";
            btnShowStaffs.Size = new Size(224, 56);
            btnShowStaffs.TabIndex = 27;
            btnShowStaffs.Text = "Требования к составу бригады и квалификации";
            btnShowStaffs.UseVisualStyleBackColor = true;
            btnShowStaffs.Click += btnShowStaffs_Click;
            // 
            // btnShowComponents
            // 
            btnShowComponents.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowComponents.Location = new Point(4, 56);
            btnShowComponents.Name = "btnShowComponents";
            btnShowComponents.Size = new Size(224, 56);
            btnShowComponents.TabIndex = 28;
            btnShowComponents.Text = " Требования к материалам и комплектующим";
            btnShowComponents.UseVisualStyleBackColor = true;
            btnShowComponents.Click += btnShowComponents_Click;
            // 
            // btnShowMachines
            // 
            btnShowMachines.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowMachines.Location = new Point(4, 112);
            btnShowMachines.Name = "btnShowMachines";
            btnShowMachines.Size = new Size(224, 56);
            btnShowMachines.TabIndex = 29;
            btnShowMachines.Text = "Требования к механизмам";
            btnShowMachines.UseVisualStyleBackColor = true;
            btnShowMachines.Click += btnShowMachines_Click;
            // 
            // btnShowProtections
            // 
            btnShowProtections.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowProtections.Location = new Point(4, 168);
            btnShowProtections.Name = "btnShowProtections";
            btnShowProtections.Size = new Size(224, 56);
            btnShowProtections.TabIndex = 30;
            btnShowProtections.Text = "Требования к средствам защиты";
            btnShowProtections.UseVisualStyleBackColor = true;
            btnShowProtections.Click += btnShowProtections_Click;
            // 
            // btnShowTools
            // 
            btnShowTools.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowTools.Location = new Point(4, 224);
            btnShowTools.Name = "btnShowTools";
            btnShowTools.Size = new Size(224, 56);
            btnShowTools.TabIndex = 31;
            btnShowTools.Text = "Требования к инструментам и приспособлениям";
            btnShowTools.UseVisualStyleBackColor = true;
            btnShowTools.Click += btnShowTools_Click;
            // 
            // btnShowWorkSteps
            // 
            btnShowWorkSteps.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowWorkSteps.Location = new Point(4, 280);
            btnShowWorkSteps.Name = "btnShowWorkSteps";
            btnShowWorkSteps.Size = new Size(224, 56);
            btnShowWorkSteps.TabIndex = 32;
            btnShowWorkSteps.Text = "Ход работ";
            btnShowWorkSteps.UseVisualStyleBackColor = true;
            btnShowWorkSteps.Click += btnShowWorkSteps_Click;
            // 
            // pnlControls
            // 
            pnlControls.Controls.Add(btnShowWorkSteps);
            pnlControls.Controls.Add(btnShowTools);
            pnlControls.Controls.Add(btnShowProtections);
            pnlControls.Controls.Add(btnShowMachines);
            pnlControls.Controls.Add(btnShowComponents);
            pnlControls.Controls.Add(btnShowStaffs);
            pnlControls.Dock = DockStyle.Left;
            pnlControls.Location = new Point(0, 27);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(235, 426);
            pnlControls.TabIndex = 34;
            // 
            // pnlDataViewer
            // 
            pnlDataViewer.Dock = DockStyle.Fill;
            pnlDataViewer.Location = new Point(235, 27);
            pnlDataViewer.Name = "pnlDataViewer";
            pnlDataViewer.Size = new Size(1128, 426);
            pnlDataViewer.TabIndex = 35;
            // 
            // Win6_new
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1363, 453);
            Controls.Add(pnlDataViewer);
            Controls.Add(pnlControls);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(1380, 487);
            Name = "Win6_new";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Win6_new";
            WindowState = FormWindowState.Maximized;
            FormClosing += Win6_new_FormClosing;
            Load += Win6_new_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlControls.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private Button btnShowStaffs;
        private Button btnShowComponents;
        private Button btnShowMachines;
        private Button btnShowProtections;
        private Button btnShowTools;
        private Button btnShowWorkSteps;
        private Panel pnlControls;
        private Panel pnlDataViewer;
        private ToolStripButton toolStripButtonSaveChanges;
        private ToolStripSplitButton toolStripFile;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem SaveChangesToolStripMenuItem;
        private ToolStripMenuItem actionToolStripMenuItem;
        private ToolStripMenuItem выпуститьПроектToolStripMenuItem;
        private ToolStripMenuItem setApprovedStatusToolStripMenuItem;
        private ToolStripMenuItem setRemarksModeToolStripMenuItem;
        private ToolStripMenuItem setDraftStatusToolStripMenuItem;
    }
}