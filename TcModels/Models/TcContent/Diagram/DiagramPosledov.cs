﻿namespace TcModels.Models.TcContent
{
	public class DiagramPosledov
    {
        public int Id { get; set; }

        public List<DiagramShag> ListDiagramShag { get; set; } = new List<DiagramShag>();

        public DiagramParalelno DiagramParalelno { get; set; }
        public int DiagramParalelnoId { get; set; }
        public int Order { get; set; }
    }
}
