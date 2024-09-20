using Medical_calculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_calculator.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public RelayCommand BSAViewCommand { get; set; }

        public RelayCommand GFRViewCommand { get; set; }

        public GFRCalcViewModel GFRCalcVM { get; set; }

        public BSACalcViewModel BSACalcVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            BSACalcVM = new BSACalcViewModel();
            GFRCalcVM = new GFRCalcViewModel();

            CurrentView = GFRCalcVM;

            GFRViewCommand = new RelayCommand(o =>
            {
                CurrentView = GFRCalcVM;
            });

            BSAViewCommand = new RelayCommand(o =>
            {
                CurrentView = BSACalcVM;
            });
        }
    }
}
