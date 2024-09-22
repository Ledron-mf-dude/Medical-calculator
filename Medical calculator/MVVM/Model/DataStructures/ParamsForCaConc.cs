using System.Globalization;

namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class ParamsForCaConc
    {
        private double _caTotal = 0;
        private double _albumin = 0;
        private bool _isValueInDl;

        private string _caTotalStr;
        private string _albuminStr;

        public bool IsValueInDl
        {
            set { _isValueInDl = value; }
            get { return _isValueInDl; }
        }

        public double CaTotal
        {
            get { return _caTotal; }
        }

        public double Albumin
        {
            get { return _albumin; }
        }

        public string CaTotalStr
        {
            get => _caTotalStr;
            set
            {
                if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double parseCaTotal))
                {
                    _caTotal = parseCaTotal;
                }
                _caTotalStr = value;
            }
        }

        public string AlbuminStr
        {
            get => _albuminStr;
            set
            {
                if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double parseAlbumin))
                {
                    _albumin = parseAlbumin;
                }
                _albuminStr = value;
            }
        }
    }
}
