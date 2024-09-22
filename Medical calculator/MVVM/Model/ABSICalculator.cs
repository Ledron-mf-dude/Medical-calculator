using Medical_calculator.MVVM.Model.DataStructures;
using System;

namespace Medical_calculator.MVVM.Model
{
    public class ABSICalculator
    {
        private readonly int weight;
        private readonly double height;
        private readonly double waistCircumference;

        public ABSICalculator(ParamsForABSI paramsForABSI)
        {
            if (paramsForABSI == null) throw new ArgumentNullException(nameof(paramsForABSI));

            weight = paramsForABSI.Weight;
            height = paramsForABSI.Height;
            waistCircumference = paramsForABSI.WaistCircumference;
        }
        

        public double GetABSI()
        {
            if(height == 0 || weight == 0 || waistCircumference == 0) return 0;

            var bmi = GetBMI();
            var absi = waistCircumference / (Math.Pow(bmi, 2/3) * Math.Pow(height, 0.5));
            return Math.Round(absi, 5);
        }

        public double GetBMI()
        {
            if (height == 0 || weight == 0) return 0;

            var bmi = weight / Math.Pow(height, 2);
            return Math.Round(bmi, 5);
        }
    }
}
