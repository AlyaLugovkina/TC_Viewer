﻿using Serilog;
using System.ComponentModel;
using System.Data;
using TC_WinForms.DataProcessing;
using TC_WinForms.DataProcessing.Utilities;
using TC_WinForms.Interfaces;
using TcDbConnector;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;
using static TC_WinForms.WinForms.Win6_Tool;

namespace TC_WinForms.WinForms
{
	public partial class Win6_Tool : BaseContentFormWithFormula<DisplayedTool_TC, Tool_TC>, IViewModeable 
	{
		protected override DataGridView DgvMain => dgvMain;
		protected override Panel PnlControls => pnlControls;
		protected override IList<Tool_TC> TargetTable
			=> _tcViewState.TechnologicalCard.Tool_TCs;

		private MyDbContext context;

		private int _tcId;

		public Win6_Tool(int tcId, TcViewState tcViewState, MyDbContext context)// bool viewerMode = false)
		{
			_logger = Log.Logger
				.ForContext<Win6_Component>()
				.ForContext("TcId", _tcId);

			_logger.Information("Инициализация формы Win6_Tool TcId={TcId}");

			_tcViewState = tcViewState;
            this.context = context;

            _tcId = tcId;

            InitializeComponent();

            var dgvEventService = new DGVEvents(dgvMain);
            dgvEventService.SetRowsUpAndDownEvents(btnMoveUp, btnMoveDown, dgvMain);

            dgvMain.CellFormatting += dgvEventService.dgvMain_CellFormatting;
            dgvMain.CellValidating += dgvEventService.dgvMain_CellValidating;

            this.FormClosed += (sender, e) => this.Dispose();
        }

        protected override void LoadObjects()
        {
            var tcList = _tcViewState.TechnologicalCard.Tool_TCs.Where(obj => obj.ParentId == _tcId)
                                                                .OrderBy(o => o.Order).ToList()
                                                                .Select(obj => new DisplayedTool_TC(obj))
                                                                .ToList();
            _bindingList = new BindingList<DisplayedTool_TC>(tcList);
            _bindingList.ListChanged += BindingList_ListChanged;
            dgvMain.DataSource = _bindingList;

            InitializeDataGridViewColumns();
		}

		public void AddNewObjects(List<Tool> newObjs)
        {
            foreach (var obj in newObjs)
            {
                var newObj_TC = CreateNewObject(obj, _bindingList.Select(o => o.Order).Max() + 1);
                var tool = context.Tools.Where(s => s.Id == newObj_TC.ChildId).First();

                context.Tools.Attach(tool);
                _tcViewState.TechnologicalCard.Tool_TCs.Add(newObj_TC);

                newObj_TC.Child = tool;
                newObj_TC.ChildId = tool.Id;

                var displayedObj_TC = new DisplayedTool_TC(newObj_TC);
                _bindingList.Add(displayedObj_TC);
            }


            dgvMain.Refresh();
        }

        protected override void SaveReplacedObjects() // add to UpdateMode
        {
            if (_replacedObjects.Count == 0)
                return;

            var oldObjects = _replacedObjects.Select(dtc => CreateNewObject(dtc.Key)).ToList();
            var newObjects = _replacedObjects.Select(dtc => CreateNewObject(dtc.Value)).ToList();

            //Присваиваем компонент для обхода ошибки состояний
            foreach (var newObj in newObjects)
            {
                var tool = context.Tools.Where(m => m.Id == newObj.ChildId).First();
                newObj.Child = tool;
            }

            //Заменяем объект в ToolWorks в TechOperationWorksList, если он присутствует в списке компонентов тех операции
            foreach (var tecjOperationWork in _tcViewState.TechOperationWorksList)
            {
                for (int i = 0; i < oldObjects.Count; i++)
                {
                    var replaceableToolWork = tecjOperationWork.ToolWorks.Where(m => m.toolId == oldObjects[i].ChildId).FirstOrDefault();
                    if (replaceableToolWork != null)
                    {
                        replaceableToolWork.tool = newObjects[i].Child;
                        replaceableToolWork.toolId = newObjects[i].ChildId;
                    }
                }
            }

            //Удялем старые компоненты из ТехКарты
            for (int i = 0; i < oldObjects.Count; i++)
            {
                var oldTool = _tcViewState.TechnologicalCard.Tool_TCs.Where(m => m.ChildId == oldObjects[i].ChildId).First();
                _tcViewState.TechnologicalCard.Tool_TCs.Remove(oldTool);
            }

            _tcViewState.TechnologicalCard.Tool_TCs.AddRange(newObjects);

            _changedObjects.Clear();
        }
        protected override Tool_TC CreateNewObject(BaseDisplayedEntity dObj)
        {
            return new Tool_TC
            {
                ParentId = dObj.ParentId,
                ChildId = dObj.ChildId,
                Order = dObj.Order,
                Quantity = dObj.Quantity ?? 0,
                Note = dObj.Note,
            };
        }
        private Tool_TC CreateNewObject(Tool obj, int oreder)
        {
            return new Tool_TC
            {
                ParentId = _tcId,
                ChildId = obj.Id,
                Child = obj,
                Order = oreder,
                Quantity = 0,
                Note = "",
            };
        }

        ///////////////////////////////////////////////////// * Events handlers * /////////////////////////////////////////////////////////////////////////////////
        private void btnAddNewObj_Click(object sender, EventArgs e)
        {
            // load new form Win7 Tool as dictonary
            var newForm = new Win7_6_Tool(activateNewItemCreate: true, createdTCId: _tcId);
            newForm.WindowState = FormWindowState.Maximized;
            newForm.ShowDialog();
        }

        private void btnDeleteObj_Click(object sender, EventArgs e)
        {
            DisplayedEntityHelper.DeleteSelectedObject(dgvMain,
                _bindingList, _newObjects, _deletedObjects);

            if (_deletedObjects.Count != 0)
            {
                foreach (var obj in _deletedObjects)
                {
                    foreach (var tecjOperationWork in _tcViewState.TechOperationWorksList)
                    {
                        var deletableCompWork = tecjOperationWork.ToolWorks.Where(m => m.toolId == obj.ChildId).FirstOrDefault();
                        if (deletableCompWork != null)
                        {
                            tecjOperationWork.ToolWorks.Remove(deletableCompWork);
                        }

                    }
                    var deletedObj = _tcViewState.TechnologicalCard.Tool_TCs.Where(s => s.ChildId == obj.ChildId).FirstOrDefault();
                    if (deletedObj != null)
                        _tcViewState.TechnologicalCard.Tool_TCs.Remove(deletedObj);
                }

                _deletedObjects.Clear();
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            // Выделение объекта выбранной строки
            if (dgvMain.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку для редактирования");
                return;
            }

            // load new form Win7_3_Component as dictonary
            var newForm = new Win7_6_Tool(activateNewItemCreate: true, createdTCId: _tcId, isUpdateMode: true);

            newForm.WindowState = FormWindowState.Maximized;
            newForm.ShowDialog();

        }// add to UpdateMode
        public bool UpdateSelectedObject(Tool updatedObject)
        {
            if (dgvMain.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку для редактирования");
                return false;
            }

            var selectedRow = dgvMain.SelectedRows[0];
            //var displayedComponent = selectedRow.DataBoundItem as DisplayedTool_TC;

            if (selectedRow.DataBoundItem is DisplayedTool_TC dObj)
            {

                if (dObj.ChildId == updatedObject.Id)
                {
                    MessageBox.Show("Ошибка обновления объекта: ID объекта совпадает");
                    return false;
                }
                // проверка на наличие объекта в списке существующих объектов
                if (_bindingList.Any(obj => obj.ChildId == updatedObject.Id))
                {
                    MessageBox.Show("Ошибка обновления объекта: объект с таким ID уже существует");
                    return false;
                }
                var newItem = CreateNewObject(updatedObject, dObj.Order);
                newItem.Quantity = dObj.Quantity ?? 0;
                newItem.Note = dObj.Note;

                var newDisplayedComponent = new DisplayedTool_TC(newItem);


                // замена displayedComponent в dgvMain на newDisplayedComponent
                var index = _bindingList.IndexOf(dObj);
                _bindingList[index] = newDisplayedComponent;

                // проверяем наличие объекта в списке измененных объектов в значениях replacedObjects
                if (_replacedObjects.ContainsKey(dObj))
                {
                    _replacedObjects[dObj] = newDisplayedComponent;
                }
                else
                {
                    _replacedObjects.Add(dObj, newDisplayedComponent);
                }

                SaveReplacedObjects();

                return true;
            }

            return false;
        }// add to UpdateMode

		public class DisplayedTool_TC : BaseDisplayedEntity
		{
			public override Dictionary<string, string> GetPropertiesNames()
			{
				var baseDict = base.GetPropertiesNames();

				baseDict.Add(nameof(Category), "Категория");

				return baseDict;
			}

			public DisplayedTool_TC()
			{

			}
			public DisplayedTool_TC(Tool_TC obj)
			{
				ChildId = obj.ChildId;
				ParentId = obj.ParentId;
				Order = obj.Order;

				Name = obj.Child.Name;
				Type = obj.Child.Type;

				Unit = obj.Child.Unit;
				Quantity = obj.Quantity;
				//Formula = "123";
				Price = obj.Child.Price;
				Description = obj.Child.Description;
				Manufacturer = obj.Child.Manufacturer;
				Category = obj.Child.Categoty;
				ClassifierCode = obj.Child.ClassifierCode;
				Note = obj.Note;

				IsReleased = obj.Child.IsReleased;
			}
			public string Category { get; set; } = "Tool";
		}
	}

}
