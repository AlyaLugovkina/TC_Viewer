using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcModels.Models.TcContent;
using static TcModels.Models.TcContent.Outlay;

namespace TC_WinForms.WinForms.Win7.Work
{
    public class SummaryOutlayDataGridItem
    {
        public int TcId {  get; set; }
        public string TcName { get; set; }

        public List<(string StaffName, double StaffOutlay)> listStaffStr = new List<(string StaffName, double StaffOutlay)>();
        public List<(string MachineName, double MachineOutlay)> listMachStr = new List<(string MachineName, double MachineOutlay)>();

        public double ComponentOutlay {  get; set; }
        public double SummaryOutlay {  get; set; }
        //public UnitType UnitType { get; set; }


        //ТК имя
        //Стафф
        //Компоненты
        //Механизмы
        //Суммарное

        //Todo: добавить форомульные колонки
        //Ниже формульное
        //Ед изм затрат
        //Затраты
    }
}
