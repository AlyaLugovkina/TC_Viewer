using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using TC_WinForms.DataProcessing;
using TC_WinForms.Interfaces;
using TC_WinForms.Services;
using TC_WinForms.WinForms.Win7.Work;
using TC_WinForms.WinForms.Work;
using TcDbConnector;
using TcModels.Models.TcContent;
using static TC_WinForms.DataProcessing.AuthorizationService;
using static TcModels.Models.TcContent.Outlay;

namespace TC_WinForms.WinForms.Win7
{
    public partial class Win7_SummaryOutlay : Form, ILoadDataAsyncForm //IPaginationControl,
    {
        private readonly User.Role _accessLevel;
        private readonly int _minRowHeight = 20;

        private DbConnector dbCon = new DbConnector();

        private List<SummaryOutlayDataGridItem> _displayedObjects = new();
        private List<Outlay> _displayedObject = new();

        private List<SummaryOutlayDataGridItem> SummaryOutlayDataGridItems = new List<SummaryOutlayDataGridItem>();

        public bool _isDataLoaded = false;


        PaginationControlService<SummaryOutlayDataGridItem> paginationService;
        public event EventHandler<PageInfoEventArgs> PageInfoChanged;
        public PageInfoEventArgs? PageInfo { get; set; }

        public Win7_SummaryOutlay(User.Role accessLevel)
        {
            _accessLevel = accessLevel;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void Win7_SummaryOutlay_Load(object sender, EventArgs e)
        {
            Enabled = false;
            dgvMain.Visible = false;

            if (!_isDataLoaded)
                await LoadDataAsync();

            InitializeDataGrid();
            PopulateDataGrid();


            Enabled = true;
            dgvMain.Visible = true;

            SetDGVColumnsSettings();
            //SetupCategoryComboBox();

        }

        private void InitializeDataGrid()
        {
            dgvMain.Rows.Clear();
            SummaryOutlayDataGridItems.Clear();

            while (dgvMain.Columns.Count > 0)
            {
                dgvMain.Columns.RemoveAt(0);
            }

            dgvMain.Columns.Add("TcName", "Наименование ТК");

            foreach (var staff in _displayedObject.Where(s => s.Type == OutlayType.Staff).Select(x => x.Name).Distinct())
            {
                var staffSymbol = staff.Split(" ")[0];

                if (dgvMain.Columns.Contains($"Staff{staffSymbol}"))
                    continue;

                dgvMain.Columns.Add($"Staff{staffSymbol}", $"{staffSymbol}");
            }

            dgvMain.Columns.Add("ComponentOutlay", "Материалы");

            foreach (var machine in _displayedObject.Where(s => s.Type == OutlayType.Mechine).Select(x => x.Name).Distinct())
            {
                dgvMain.Columns.Add($"Machine{machine}", $"{machine}");
            }

            dgvMain.Columns.Add("SummaryOutlay", "Общее время выполнения работ");
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }
        private void PopulateDataGrid()
        {
            var groupedOutlays = _displayedObject.GroupBy(x => x.TcID).ToList();
            foreach (var outlay in groupedOutlays)
            {
                var tcId = outlay.Key;
                var outlayData = outlay.ToList();

                var machineList = outlayData.Where(x => x.Type == OutlayType.Mechine).ToList();
                List<(string MachineName, double MachineOutlay)> listMachStr = new List<(string MachineName, double MachineOutlay)>();

                foreach (var machine in machineList)
                {
                    listMachStr.Add((machine.Name, machine.OutlayValue));
                }

                var staffList = outlayData.Where(x => x.Type == OutlayType.Staff).ToList();
                List<(string StaffName, double StaffOutlay)> listStaffStr = new List<(string StaffName, double StaffOutlay)>();

                foreach (var staff in staffList)
                {
                    listStaffStr.Add((staff.Name.Split(" ")[0], staff.OutlayValue));
                }

                SummaryOutlayDataGridItems.Add (new SummaryOutlayDataGridItem
                {
                    TcId = tcId,
                    TcName = string.Empty,
                    listStaffStr = listStaffStr,
                    listMachStr = listMachStr,
                    ComponentOutlay = outlayData.Where(s => s.Type == OutlayType.Components).Select(s => s.OutlayValue).First(),
                    SummaryOutlay = outlayData.Where(s => s.Type == OutlayType.SummaryTimeOutlay).Select(s => s.OutlayValue).First(),
                });
            }

            using (MyDbContext context = new MyDbContext())
            {
                SummaryOutlayDataGridItems.ForEach
                    (
                        x => 
                        {
                            var techCard = context.TechnologicalCards.Where(t => t.Id == x.TcId).FirstOrDefault();
                            if (techCard != null)
                                x.TcName = techCard.Article;
                        }
                    );
            }

            AddRowsToGrid();
        }
        public async Task LoadDataAsync()
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    _displayedObject = await Task.Run(() => dbCon.GetObjectList<Outlay>());
                }
            }
            catch (Exception ex) { }
        }
        private void AddRowsToGrid()
        {
            int rowCount = 0;
            foreach (var summaryOutlayDataGridItem in SummaryOutlayDataGridItems)
            {
                dgvMain.Rows.Add();

                dgvMain.Rows[rowCount].Cells["TcName"].Value = summaryOutlayDataGridItem.TcName;
                dgvMain.Rows[rowCount].Cells["ComponentOutlay"].Value = summaryOutlayDataGridItem.ComponentOutlay;
                dgvMain.Rows[rowCount].Cells["SummaryOutlay"].Value = summaryOutlayDataGridItem.SummaryOutlay;

                foreach(DataGridViewColumn column in dgvMain.Columns)
                {
                    foreach(var staff in summaryOutlayDataGridItem.listStaffStr)
                    {
                        if (column.Name.Contains(staff.StaffName))
                        {
                            var value = dgvMain.Rows[rowCount].Cells[column.Index].Value == null || dgvMain.Rows[rowCount].Cells[column.Index].Value == " - "
                                ? 0 
                                : (double)dgvMain.Rows[rowCount].Cells[column.Index].Value;
                            dgvMain.Rows[rowCount].Cells[column.Index].Value = value + staff.StaffOutlay;
                        }
                    }

                    foreach (var machine in summaryOutlayDataGridItem.listMachStr)
                    {
                        if (column.Name.Contains(machine.MachineName))
                        {
                            dgvMain.Rows[rowCount].Cells[column.Index].Value = machine.MachineOutlay;
                        }
                    }

                    if (dgvMain.Rows[rowCount].Cells[column.Index].Value == null)
                    {
                        dgvMain.Rows[rowCount].Cells[column.Index].Value = " - ";
                    }

                }

                rowCount++;
            }
        }
        void SetDGVColumnsSettings()
        {
            // автоподбор ширины столбцов под ширину таблицы
            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.RowHeadersWidth = 25;

            //// автоперенос в ячейках
            dgvMain.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }
    }
}
