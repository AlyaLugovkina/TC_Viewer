﻿using Microsoft.VisualBasic.Devices;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TC_WinForms.DataProcessing;
using TC_WinForms.WinForms.Work;
using TcModels.Models;
using TcModels.Models.Interfaces;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TC_WinForms.WinForms
{
    public partial class Win6_new : Form
    {
        Win6_Staff win6_Staff;
        Win6_Component win6_Component;
        Win6_Machine win6_Machine;
        Win6_Protection win6_Protection;
        Win6_Tool win6_Tool;
        //Win6_WorkStep win6_WorkStep;

        TechOperationForm techOperationForm;

        EModelType? activeModelType = null;

        Form activeForm = null;

        TechnologicalCard _tc;
        int _tcId;

        DbConnector db = new DbConnector();

        public Win6_new(int tcId)
        {
            _tcId = tcId;
            InitializeComponent();

            // download TC from db
            var TC = db.GetObject<TechnologicalCard>(tcId);// Task.Run(()=>db.GetObject<TechnologicalCard>(tcId));

            btnShowStaffs_Click(null, null);
            _tc = TC; //TC.Result; // todo - ??? why it is working longer with Task.Run ???
        }

        private void LoadFormInPanel(Form form)
        {
            // hide all forms in panel
            foreach (Form frm in pnlDataViewer.Controls)
            {
                frm.Hide();
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            this.pnlDataViewer.Controls.Add(form);
            form.Show();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            WinProcessing.BackFormBtn(this);
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
        }

        private void Win6_new_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close all inner forms
            foreach (Form frm in pnlDataViewer.Controls) // todo - move to WinProcessing and run it asynch
            {
                frm.Close();
            }
            this.Dispose();
            // todo - if there are some changes - ask user if he wants to save them
        }

        private void cmbTechCardName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Add new rows to Table typeof DataGridView from obj
        /// </summary>
        /// <typeparam name="T">It is intermediate table type</typeparam>
        /// <typeparam name="C">It is Child model that is implemented in intermediate table</typeparam>
        /// <param name="obj"></param>
        /// <param name="DGV"></param>


        private void btnShowStaffs_Click(object sender, EventArgs e)
        {
            if(activeForm is Win6_Staff) return;
            if(win6_Staff == null)
                win6_Staff = new Win6_Staff(_tcId);
            activeForm = win6_Staff;
            LoadFormInPanel(activeForm); //new Win6_Staff_3(_tcId)); //LoadFormInPanel(new Win6_Staff_2(_tcId)); //
            if (sender is Button)
                WinProcessing.ColorizeOnlyChosenButton(sender as Button, pnlControls);
        }

        private void btnShowComponents_Click(object sender, EventArgs e)
        {
            if (activeForm is Win6_Component) return;
            if (win6_Component == null)
                win6_Component = new Win6_Component(_tcId);
            activeForm = win6_Component;
            LoadFormInPanel(activeForm);
            if (sender is Button)
                WinProcessing.ColorizeOnlyChosenButton(sender as Button, pnlControls);
        }

        private void btnShowMachines_Click(object sender, EventArgs e)
        {
            if (activeForm is Win6_Machine) return;
            if (win6_Machine == null)
                win6_Machine = new Win6_Machine(_tcId);
            activeForm = win6_Machine;
            LoadFormInPanel(activeForm);
            if (sender is Button)
                WinProcessing.ColorizeOnlyChosenButton(sender as Button, pnlControls);
        }

        private void btnShowProtections_Click(object sender, EventArgs e)
        {
            if (activeForm is Win6_Protection) return;
            if (win6_Protection == null)
                win6_Protection = new Win6_Protection(_tcId);
            activeForm = win6_Protection;
            LoadFormInPanel(activeForm);
            if (sender is Button)
                WinProcessing.ColorizeOnlyChosenButton(sender as Button, pnlControls);
        }

        private void btnShowTools_Click(object sender, EventArgs e)
        {
            if (activeForm is Win6_Tool) return;
            if (win6_Tool == null)
                win6_Tool = new Win6_Tool(_tcId);
            activeForm = win6_Tool;
            LoadFormInPanel(activeForm);
            if (sender is Button)
                WinProcessing.ColorizeOnlyChosenButton(sender as Button, pnlControls);
        }

        private void btnShowWorkSteps_Click(object sender, EventArgs e)
        {
            if (activeForm is TechOperationForm) return;
            if (techOperationForm == null)
                techOperationForm = new TechOperationForm(_tcId);
            activeForm = techOperationForm;
            LoadFormInPanel(activeForm);


            //if (activeModelType == EModelType.WorkStep) return;
            ////SaveDataFromDGV(activeModelType);
            //DGVNewStructure(EModelType.WorkStep);
            //activeModelType = EModelType.WorkStep;
            //if (sender is Button)
            //    WinProcessing.ColorizeOnlyChosenButton(sender as Button, pnlControls);
        } // todo - make it work


        private void SaveDataFromDGV(EModelType? ModelType) // todo - ??? mb better catch changes and save them in Program.CurrentTc
        {


        }


        private void DGVStructure(Dictionary<string, string> columnNames)
        {

        }
        /// <summary>
        /// Add new columns to dgvTcObjects and set activeModelType
        /// </summary>
        /// <param name="modelType"> Enum that represents models of TC tables structure (Staff, Tool, etc)</param>
        private void DGVNewStructure(EModelType modelType)
        {

        }

        private void dgvTcObjects_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvTcObjects_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // get indexes of removed rows

            // !!! rows are removing one by one !!!


            //int index = e.RowIndex - 1;

            //int id = (int)dgvTcObjects.Rows[index].Cells["Id"].Value;
            //int order = (int)dgvTcObjects.Rows[index].Cells["Num"].Value;

            //MessageBox.Show($"RowRemoved: {string.Join(", ", index)}");
        }

        private void Win6_new_Load(object sender, EventArgs e)
        {
            // change form title
            this.Text = $"{_tc.Name} ({_tc.Article})";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // activate save button from all inner forms
            // get all inner forms
            foreach (Form frm in pnlDataViewer.Controls)
            {
                // is form is ISaveEventForm
                if (frm is ISaveEventForm)
                {
                    // call save method
                    (frm as ISaveEventForm).SaveChanges();
                }
            }
        }
    }

}
