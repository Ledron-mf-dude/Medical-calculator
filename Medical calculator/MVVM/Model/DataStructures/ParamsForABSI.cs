using System.Globalization;

namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class ParamsForABSI
    {
        private double _height = 0;
        private int _weight = 0;
        private double _waistCircumference = 0;

        private string _heightStr;
        private string _weightStr;
        private string _waistCircumferenceStr;

        public double Height
        {
            get { return _height; }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public double WaistCircumference
        {
            get { return _waistCircumference; }
        }

        public string HeightStr
        {
            get => _heightStr;
            set
            {
                if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double parseHeighte))
                {
                    _height = parseHeighte / 100;
                }
                _heightStr = value;
            }
        }

        public string WeightStr
        {
            get => _weightStr;
            set
            {
                if (int.TryParse(value, out int parseWeight))
                {
                    _weight = parseWeight;
                }
                _weightStr = value;
            }
        }

        public string WaistCircumferenceStr
        {
            get => _waistCircumferenceStr;
            set
            {
                if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double parseWaistCircumference))
                {
                    _waistCircumference = parseWaistCircumference / 100;
                }
                _waistCircumferenceStr = value;
            }

        }
    }
}
