﻿using TcModels.Models.Interfaces;
using TcModels.Models.TcContent;

namespace TcModels.Models.IntermediateTables
{
    public class Component_TC : IStructIntermediateTable<TechnologicalCard, Component>
    {
        public int ChildId { get; set; }
        public Component Child { get; set; }

        public int ParentId { get; set; }
        public TechnologicalCard Parent { get; set; }

        public int Order { get; set; }
        public double Quantity { get; set; }
        public string? Note { get; set; }
        public override string ToString()
        {
            return $"{Order}.{Child.Name} (id: {ChildId}) {Quantity}";
        }
    }
}
