using Serilog;
using System.ComponentModel;
using System.Data;
using TC_WinForms.DataProcessing.Utilities;
using TC_WinForms.Interfaces;
using TC_WinForms.WinForms.Win6.Models;
using TcDbConnector;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;

namespace TC_WinForms.WinForms
{
	// при работе с дизайнером раскоментировать
	//[DesignerCategory("Form")]
	//public partial class Win6_Tool : Win6_Tool_Design
	public partial class Win6_Tool : BaseContentForm<DisplayedTool_TC, Tool_TC>, IFormWithObjectId
	{
		protected override DataGridView DgvMain => dgvMain;
		protected override Panel PnlControls => pnlControls;
		protected override IList<Tool_TC> TargetTable
			=> _tcViewState.TechnologicalCard.Tool_TCs;

		private MyDbContext context;

		private int _tcId;

		public Win6_Tool(int tcId, TcViewState tcViewState, MyDbContext context)// bool viewerMode = false)
		{
			_tcViewState = tcViewState;
			this.context = context;

			_tcId = tcId;

			_logger = Log.Logger
				.ForContext<Win6_Tool>()
				.ForContext("TcId", _tcId);

			_logger.Information("Инициализация формы.");

            InitializeComponent();
            dgvMain.CellEndEdit += DgvMain_CellEndEdit;
            InitializeDataGridViewEvents();

			this.FormClosed += (sender, e) => {
				_logger.Information("Форма закрыта");
				this.Dispose();
			};
		}

        private bool autoAdvance = false;

        private void DgvMain_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            base.dgvMain_CellEndEdit(sender, e);

            if (!autoAdvance) return;

            int currentRow = dgvMain.CurrentCell.RowIndex;
            int currentCol = dgvMain.CurrentCell.ColumnIndex;
            int nextRow = currentRow + 1;

            if (nextRow < dgvMain.Rows.Count)
            {
                this.BeginInvoke(new Action(() =>
                {
                    dgvMain.EndEdit();
                    autoAdvance = true;
                    dgvMain.CurrentCell = dgvMain.Rows[nextRow].Cells[currentCol];
                    dgvMain.BeginEdit(true);
                }));
            }

            autoAdvance = false;
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
            List<Tool> existedTool = new List<Tool>();

            foreach (var obj in newObjs)
            {
                if (_bindingList.Select(c => c.ChildId).Contains(obj.Id))
                {
                    existedTool.Add(obj);
                    continue;
                }

                var newObj_TC = CreateNewObject(obj, GetNewObjectOrder());
                var tool = context.Tools.Where(s => s.Id == newObj_TC.ChildId).First();

                context.Tools.Attach(tool);
                TargetTable.Add(newObj_TC);

                newObj_TC.Child = tool;
                newObj_TC.ChildId = tool.Id;

                var displayedObj_TC = new DisplayedTool_TC(newObj_TC);
                _bindingList.Add(displayedObj_TC);
            }

            dgvMain.Refresh();

            if (existedTool.Count > 0)
            {
                string elements = "";
                foreach (var tool in existedTool)
                {
                    elements += "Инструмент: " + tool.Name + " ID: " + tool.Id + ".\n";
                }

                MessageBox.Show("Часть объектов уже присутствовала в требованиях. Они не были внесены: \n" + elements, "Дублирование элементов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                var oldTool = TargetTable.Where(m => m.ChildId == oldObjects[i].ChildId).First();
				TargetTable.Remove(oldTool);
            }

			foreach (var newObj in newObjects)
			{
				TargetTable
					.Add(newObj);
			}

			_replacedObjects.Clear();
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
                Formula = dObj.Formula,
			};
        }
        private Tool_TC CreateNewObject(Tool obj, int order)
        {
            return new Tool_TC
            {
                ParentId = _tcId,
                ChildId = obj.Id,
                Child = obj,
                Order = order,
                Quantity = 0,
                Note = "",
            };
        }

        ///////////////////////////////////////////////////// * Events handlers * /////////////////////////////////////////////////////////////////////////////////
        private void btnAddNewObj_Click(object sender, EventArgs e)
		{
			LogUserAction("Добавление нового объекта");
			// load new form Win7 Tool as dictonary
			var newForm = new Win7_6_Tool(activateNewItemCreate: true, createdTCId: _tcId);
            newForm.WindowState = FormWindowState.Maximized;
            newForm.ShowDialog();
        }

        private void btnDeleteObj_Click(object sender, EventArgs e)
		{
			LogUserAction("Удаление выбранных объектов");

			DisplayedEntityHelper.DeleteSelectedObject(dgvMain,
                _bindingList, _newObjects, _deletedObjects);

            if (_deletedObjects.Count != 0)
            {
                foreach (var obj in _deletedObjects)
                {
                    foreach (var tecjOperationWork in _tcViewState.TechOperationWorksList)
                    {
                        var deletableObjWork = tecjOperationWork.ToolWorks.Where(m => m.toolId == obj.ChildId).FirstOrDefault();
                        if (deletableObjWork != null)
                        {
							_logger.Debug("Удаление ToolWork({Id}): TechOperationWorkID={TechOperationWorkId}, ChildObjectID={ChildObjectID}",
								deletableObjWork.Id, deletableObjWork.techOperationWorkId, deletableObjWork.toolId);

							tecjOperationWork.ToolWorks.Remove(deletableObjWork);
                        }

                    }
                    var deletedObj = _tcViewState.TechnologicalCard.Tool_TCs.Where(s => s.ChildId == obj.ChildId).FirstOrDefault();
                    if (deletedObj != null)
                    {
						_logger.Debug("Удаление объектов({ObjectType}}: {ObjectName} (ID={Id})",
							deletedObj.GetType(), deletedObj.Child.Name, deletedObj.ChildId);

						_tcViewState.TechnologicalCard.Tool_TCs.Remove(deletedObj);
					}
                }

				_logger.Information("Удалено объектов: {Count}", _deletedObjects.Count);
				_deletedObjects.Clear();
            }

            ReorderRows();
        }


        private void ReorderRows()
        {
            // Если у вас есть поле с порядком (например, Order или Sequence)
            int order = 1;
            foreach (var item in _bindingList)
            {
                // Предполагая, что у вашего объекта есть свойство Order
                // Если свойство называется иначе, измените соответственно
                item.Order = order++;

                // Если нужно обновить порядок и в TargetTable
                var targetItem = TargetTable.FirstOrDefault(t => t.ChildId == item.ChildId);
                if (targetItem != null)
                {
                    targetItem.Order = item.Order;
                }
            }

            // Обновляем отображение DataGridView
            _bindingList.ResetBindings();

            // Или можно использовать:
            // dgvMain.Refresh();
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

		public int GetObjectId()
		{
			return _tcId;
		}
	}

}
