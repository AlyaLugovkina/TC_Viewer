using System.Data;
using TC_WinForms.DataProcessing;
using TC_WinForms.Interfaces;
using TC_WinForms.Services;
using TC_WinForms.WinForms.Win7.Work;
using TC_WinForms.WinForms.Work;
using TcModels.Models.TcContent;
using static TC_WinForms.DataProcessing.AuthorizationService;
using static TcModels.Models.TcContent.Outlay;

namespace TC_WinForms.WinForms.Win7
{
    public partial class Win7_SummaryOutlay : Form, ILoadDataAsyncForm, IPaginationControl,
    {
        private readonly User.Role _accessLevel;
        private readonly int _minRowHeight = 20;

        private DbConnector dbCon = new DbConnector();

        private List<SummaryOutlayDataGridItem> _displayedObjects = new();
        private List<Outlay> _displayedObject = new();

        private List<SummaryOutlayDataGridItem> SummaryOutlayDataGridItem = new List<SummaryOutlayDataGridItem>();

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

            SetDGVColumnsSettings();
            SetupCategoryComboBox();

        }

        private void InitializeDataGrid()
        {
            dgvMain.Rows.Clear();
            SummaryOutlayDataGridItem.Clear();

            while (dgvMain.Columns.Count > 0)
            {
                dgvMain.Columns.RemoveAt(0);
            }

            dgvMain.Columns.Add("TcName", "Наименование ТК");

            foreach (var staff in _displayedObject.Where(s => s.Type == OutlayType.Staff).Select(x => x.Name).Distinct())
            {
                var staffSymbol = staff.Split(" ")[0];
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

                SummaryOutlayDataGridItem.Add (new SummaryOutlayDataGridItem
                {
                    TcId = tcId,
                    TcName = techOperationWork,
                    TechOperation = $"№{techOperationWork.Order} {techOperationWork.techOperation.Name}",
                    IdTO = techOperationWork.techOperation.Id
                });
            }
        }
        public async Task LoadDataAsync()
        {
            _displayedObject = await Task.Run(() => dbCon.GetObjectList<Outlay>());

            paginationService = new PaginationControlService<SummaryOutlayDataGridItem>(40, _displayedObjects);

            FilteringObjects();

            _isDataLoaded = true;
        }
    }
}
