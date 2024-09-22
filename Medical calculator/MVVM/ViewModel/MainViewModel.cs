using Medical_calculator.Core;

namespace Medical_calculator.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public RelayCommand BSAViewCommand { get; set; }
        public RelayCommand GFRViewCommand { get; set; }
        public RelayCommand ABSIViewCommand { get; set; }
        public RelayCommand CaConcViewCommand {  get; set; }

        public GFRCalcViewModel GFRCalcVM { get; set; }
        public BSACalcViewModel BSACalcVM { get; set; }
        public ABSICalcViewModel ABSICalcVM { get; set; }
        public CaConcCalcViewModel CaConcCalcVM { get; set; }

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
            ABSICalcVM = new ABSICalcViewModel();
            CaConcCalcVM = new CaConcCalcViewModel();

            CurrentView = GFRCalcVM;

            GFRViewCommand = new RelayCommand(o =>
            {
                CurrentView = GFRCalcVM;
            });

            BSAViewCommand = new RelayCommand(o =>
            {
                CurrentView = BSACalcVM;
            });

            ABSIViewCommand = new RelayCommand(o =>
            {
                CurrentView = ABSICalcVM;
            });

            CaConcViewCommand = new RelayCommand(o =>
            {
                CurrentView = CaConcCalcVM;
            });
        }
    }
}
