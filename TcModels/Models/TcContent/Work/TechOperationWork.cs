﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TcModels.Models.TcContent
{
    public class TechOperationWork
    {
        public int Id { get; set; }

        public TechOperation techOperation { get; set; }
        public int techOperationId { get; set; }

        public TechnologicalCard technologicalCard { get; set; }
        public int TechnologicalCardId { get; set; }

        public  List<ToolWork> ToolWorks { get; set; } =new List<ToolWork>();

        public List<ComponentWork> ComponentWorks { get; set; } = new List<ComponentWork>();

        public ICollection<ExecutionWork> executionWorks { get; set; } = new List<ExecutionWork>();
        public string? ParallelIndex { get; set; }
        public List<DiagramParalelno> ListDiagramParalelno { get; set; } = new List<DiagramParalelno>();

        [NotMapped] public bool Delete { get; set; } = false;
        [NotMapped] public bool NewItem { get; set; } = false;
        
        public int Order { get; set; }
        public void ApplyUpdates(TechOperationWork source)
        {
            if (source is TechOperationWork sourceCard)
            {
                techOperation = sourceCard.techOperation;
                TechnologicalCardId = sourceCard.TechnologicalCardId;
                techOperationId = sourceCard.techOperationId;
                technologicalCard = sourceCard.technologicalCard;
                ToolWorks = sourceCard.ToolWorks;
                ComponentWorks = sourceCard.ComponentWorks;
                executionWorks = sourceCard.executionWorks;
                ParallelIndex = sourceCard.ParallelIndex;
                ListDiagramParalelno = sourceCard.ListDiagramParalelno;
            }
        }
        public override string ToString()
        {
            return techOperation.Name;
        }
    }
}
