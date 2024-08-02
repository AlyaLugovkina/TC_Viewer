﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TcModels.Models.TcContent;

namespace TC_WinForms.WinForms.Diagram
{
    /// <summary>
    /// Логика взаимодействия для WpfTo.xaml
    /// </summary>
    public partial class WpfTo : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        private WpfMainControl _wpfMainControl;
        private string? parallelIndex;

        public event PropertyChangedEventHandler? PropertyChanged;
        public bool IsCommentViewMode => Win6_new.IsCommentViewMode;
        public bool IsViewMode => Win6_new.IsViewMode;
        public bool IsHiddenInViewMode => !IsViewMode;
        private void OnViewModeChanged()
        {
            OnPropertyChanged(nameof(IsHiddenInViewMode));
            OnPropertyChanged(nameof(IsViewMode));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<WpfControlTO> Children { get; set; } = new List<WpfControlTO>();
        public WpfTo()
        {
            InitializeComponent();
        }
        public WpfTo(WpfMainControl wpfMainControl,
            DiagamToWork? _diagramToWork = null, 
            bool addDiagram = true)
        {
            InitializeComponent();
            DataContext = this;

            _wpfMainControl = wpfMainControl;

            ListTOParalelno.Children.Clear();
            Children.Clear();

            if(addDiagram)
                AddWpfControlTO(wpfMainControl, _diagramToWork);
            
            Win6_new.ViewModeChanged += OnViewModeChanged;

            // Обновление привязки
            OnPropertyChanged(nameof(IsViewMode));
            OnPropertyChanged(nameof(IsHiddenInViewMode));
        }

        public void AddParallelTO(DiagamToWork? diagamToWork)
        {
            AddWpfControlTO(_wpfMainControl, diagamToWork);

            if (diagamToWork != null)
            {
                if (diagamToWork.ParallelIndex != null)
                    parallelIndex = diagamToWork.ParallelIndex;
                else SetParallelIndex(diagamToWork);
            }
        }

        private void SetParallelIndex(DiagamToWork diagamToWork)
        {
            if (diagamToWork.ParallelIndex == null)
            {
                if (Children.Count > 0)
                {
                    if (parallelIndex == null)
                        parallelIndex = new Random().Next(10000).ToString();

                    diagamToWork.ParallelIndex = parallelIndex;

                    _wpfMainControl.diagramForm.HasChanges = true;

                    //установить индекс параллельности для всех дочерних элементов
                    foreach (var child in Children)
                    {
                        child.diagamToWork.ParallelIndex = parallelIndex;
                        child.ParallelButtonsVisibility(true);
                    }
                }
            }
        }

        private void btnAddTOParallel_Click(object sender, RoutedEventArgs e)
        {
            if (_wpfMainControl.CheckIfTOIsAvailable())
            {
                AddWpfControlTO(_wpfMainControl);

                _wpfMainControl.diagramForm.HasChanges = true;
                _wpfMainControl.Nomeraciya();
            }
        }
        private void AddWpfControlTO(WpfMainControl wpfMainControl,
            DiagamToWork? diagamToWork = null)
        {
            if (diagamToWork == null)
                diagamToWork = new DiagamToWork(); SetParallelIndex(diagamToWork);

            var wpfControlTO = new WpfControlTO(wpfMainControl, diagamToWork);
            wpfControlTO.VerticalAlignment = VerticalAlignment.Top;
            wpfControlTO.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            ListTOParalelno.Children.Add(wpfControlTO);
            Children.Add(wpfControlTO);
        }

        public void DeleteWpfControlTO(WpfControlTO wpfControlTO)
        {
            ListTOParalelno.Children.Remove(wpfControlTO);
            Children.Remove(wpfControlTO);
        }

    }
}
