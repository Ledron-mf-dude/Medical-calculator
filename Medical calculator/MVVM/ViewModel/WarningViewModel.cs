using Medical_calculator.Core;

namespace Medical_calculator.MVVM.ViewModel
{
    class WarningViewModel : ObservableObject
    {
        private const string warningMessage = "     All calculations must be confirmed before use. " +
            "The suggested results are not a substitute for clinical judgment. " +
            "Neither developer nor any other party involved in the preparation or " +
            "publication of this app shall be liable for any special, consequential, or exemplary.";
        
        public string WarningMessage
        { 
            get { return warningMessage; }
        }
    }
}
