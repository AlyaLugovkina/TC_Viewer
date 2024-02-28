﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent.Work;

namespace TcModels.Models.TcContent
{
    public class ExecutionWork
    {
        public int Id { get; set; }
        public TechOperationWork techOperationWork { get; set; }
        public int techOperationWorkId { get; set; }

        public TechTransition? techTransition { get; set; }
        public int? techTransitionId { get; set; }

        public List<Staff_TC> Staffs { get; set; } = new List<Staff_TC>();

        public List<Protection_TC> Protections { get; set; } = new List<Protection_TC>();

        public List<Machine_TC> Machines { get; set; } = new List<Machine_TC>();

        public ExecutionWorkRepeat? executionWorkRepeat { get; set; }

        public Guid? sumEw { get; set; }
        public Guid? maxEw { get; set; }

        public double Value { get; set; }

        [NotMapped] public bool NewItem { get; set; }
       [NotMapped] public bool Delete { get; set; }
       [NotMapped] public Guid IdGuid { get; set; }
        
       public int Order { get; set; }
       [NotMapped] public string Etap { get; set; } = "";
       [NotMapped] public string Posled { get; set; } = "";
       [NotMapped] public double TempTimeExecution { get; set; }

       public override string ToString()
       {
           if (techTransition != null)
           {
               return techTransition.Name;
           }
           else
           {
               return base.ToString();
           }
       }
    }
}
