using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_calculator.MVVM.Model
{
    public class ParamsForGRF
    {
        private int _age = 0;
        private int _height = 0;
        private int _weight = 0;
        private double _creatinine = 0;

        private string _ageStr;
        private string _heightStr;
        private string _weightStr;
        private string _creatinineStr;

        public bool isMkMolL;
        public bool isMMolL;
        public bool isMgDl;
        
        public bool isFemale;

        public bool isAfrican;

        public int Age
        {
            get { return _age; }
        }

        public int Height
        { 
            get { return _height; }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public double Creatinine
        {
            get { return _creatinine; }
        }

        public string AgeStr
        {
            get { return _ageStr; }
            set
            {
                if(int.TryParse(value, out int parseAge))
                {
                    _age = parseAge;
                }
                _ageStr = value;
            }
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

        public string CreatinineStr
        {
            get => _creatinineStr;
            set
            {
                if (double.TryParse(value, out double parseCreatinine))
                {
                    _creatinine = parseCreatinine;
                }
                _creatinineStr = value;
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
