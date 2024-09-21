using Medical_calculator.MVVM.Model.DataStructures;
using System;

namespace Medical_calculator.MVVM.Model
{
    public class BSACalculator
    {
        private readonly int weight;
        private readonly int height;

        public BSACalculator(ParamsForBSA paramsForBSA)
        {
            if (paramsForBSA == null) throw new ArgumentNullException(nameof(paramsForBSA));

            this.weight = paramsForBSA.Weight;
            this.height = paramsForBSA.Height;
        }

        public BSACalculator(int weight, int height)
        {
            this.weight = weight;
            this.height = height;
        }

        public double GetBSAByMostellera()
        {
            var bsa = 0.0167 * Math.Pow(weight, 0.5) * Math.Pow(height, 0.5);
            return Math.Round(bsa, 2);
        }

        public double GetBSAByDuBois()
        {
            var bsa = 0.007184 * Math.Pow(weight, 0.425) * Math.Pow(height, 0.725);
            return Math.Round(bsa, 2);
        }

        public double GetBSAByHaycock()
        {
            var bsa = 0.024265 * Math.Pow(weight, 0.5378) * Math.Pow(height, 0.3964);
            return Math.Round(bsa, 2);
        }

        public double GetBSAByGehanGeorge()
        {
            var bsa = 0.0235 * Math.Pow(weight, 0.51456) * Math.Pow(height, 0.42246);
            return Math.Round(bsa, 2);
        }
    }
}
