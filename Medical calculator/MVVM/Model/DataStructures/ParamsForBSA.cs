namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class ParamsForBSA
    {
        private int _height = 0;
        private int _weight = 0;

        private string _heightStr;
        private string _weightStr;

        public int Height
        {
            get { return _height; }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public string HeightStr
        {
            get => _heightStr;
            set
            {
                if (int.TryParse(value, out int parseHeighte))
                {
                    _height = parseHeighte;
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
    }
}
