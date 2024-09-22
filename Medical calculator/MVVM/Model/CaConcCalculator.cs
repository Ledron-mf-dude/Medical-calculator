using Medical_calculator.MVVM.Model.DataStructures;
using System;

namespace Medical_calculator.MVVM.Model
{
    public class CaConcCalculator
    {
        private readonly ParamsForCaConc caConcParams;

        public CaConcCalculator(ParamsForCaConc paramsObject)
        {
            if (paramsObject == null) throw new ArgumentNullException(nameof(paramsObject));

            caConcParams = paramsObject;
        }

        public double GetCaConcInDl()
        {
            if(caConcParams == null) return 0;

            double caConcInDl = 0;

            if(caConcParams.IsValueInDl == true)
            {
                caConcInDl = caConcParams.CaTotal + 0.8*(4 - caConcParams.Albumin);
            }
            else
            {
                caConcInDl = GetCaConcInDlFromL();
            }

            return Math.Round(caConcInDl, 2);
        }

        public double GetCaConcInMmol()
        {
            if (caConcParams == null) return 0;

            double caConcInMmol = 0;

            if (caConcParams.IsValueInDl == true)
            {
                caConcInMmol = (caConcParams.CaTotal + 0.8 * (4 - caConcParams.Albumin)) / 4;
            }
            else
            {
                caConcInMmol = caConcParams.CaTotal + 0.02 * (40 - caConcParams.Albumin);
            }

            return Math.Round(caConcInMmol, 2);
        }

        private double GetCaConcInDlFromL() 
        {
            double caConcInL = 0;

            caConcInL = caConcParams.CaTotal + 0.02 * (40 - caConcParams.Albumin);

            return Math.Round(caConcInL * 4, 2);
        }
    }
}
