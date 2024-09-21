using Medical_calculator.MVVM.Model.DataStructures;
using System;

namespace Medical_calculator.MVVM.Model
{
    public class GFRCalculator
    {
        private const double creatinineMr = 113.12;

        private readonly ParamsForGRF paramsForGRF;

        public GFRCalculator(ParamsForGRF paramsObject)
        {
            if (paramsObject == null) throw new ArgumentNullException(nameof(paramsObject));

            paramsForGRF = paramsObject;
        }

        public double GetGFRByCKD_EPI()
        {
            double ckd_epiResult = 0;

            if (paramsForGRF == null || paramsForGRF.Age == 0 || paramsForGRF.Creatinine == 0) return ckd_epiResult;

            double creatitineMgDl = GetCreatinineInMgDl();

            double k = paramsForGRF.isFemale ? 0.7 : 0.9;
            double a = paramsForGRF.isFemale ? -0.329 : -0.411;

            var minMaxValue = creatitineMgDl / k;
            double minValue = minMaxValue;
            double maxValue = minMaxValue;

            if (minMaxValue > 1)
            {
                minValue = 1;
            }
            if (minMaxValue < 1)
            {
                maxValue = 1;
            }
            var minValuePow = Math.Pow(minValue, a);
            var maxValuePow = Math.Pow(maxValue, -1.209);
            var agePow = Math.Pow(0.993, paramsForGRF.Age);

            ckd_epiResult = 141 * (minValuePow * maxValuePow * agePow);

            if (paramsForGRF.isFemale) ckd_epiResult = ckd_epiResult * 1.018;
            if (paramsForGRF.isAfrican) ckd_epiResult = ckd_epiResult * 1.159;

            return Math.Round(ckd_epiResult, 2);
        }

        public double GetGFRByMDRD()
        {
            double mdrdResult = 0;

            if (paramsForGRF == null || paramsForGRF.Age == 0 || paramsForGRF.Creatinine == 0) return mdrdResult;

            double creatitineMgDl = GetCreatinineInMgDl();

            double genderCoefficient = paramsForGRF.isFemale ? 0.742 : 1;
            double raseCoefficient = paramsForGRF.isAfrican ? 1.210 : 1;

            var creatitineMgDlPow = Math.Pow(creatitineMgDl, -1.154);
            var agePow = Math.Pow(paramsForGRF.Age, -0.203);

            mdrdResult = 186 * creatitineMgDlPow * agePow * genderCoefficient * raseCoefficient;

            return Math.Round(mdrdResult, 2);
        }

        public double GetGFRByCG()
        {
            double cg_Result = 0;

            if (paramsForGRF == null || paramsForGRF.Age == 0 || paramsForGRF.Creatinine == 0 || paramsForGRF.Weight == 0) return cg_Result;

            double creatitineMgDl = GetCreatinineInMgDl();

            double genderCoefficient = paramsForGRF.isFemale ? 0.85 : 1;

            cg_Result = ((140 - paramsForGRF.Age) * paramsForGRF.Weight * genderCoefficient) / (72 * creatitineMgDl);

            return Math.Round(cg_Result, 2);
        }

        public double GetGFRByCG_BSA(double cg_Result)
        {
            double cg_bsaResult = 0;

            if (paramsForGRF == null || paramsForGRF.Weight == 0 || paramsForGRF.Height == 0 || cg_Result == 0) return cg_bsaResult;

            BSACalculator bsaCalculator = new BSACalculator(paramsForGRF.Weight, paramsForGRF.Height);

            var bsaMostellera = bsaCalculator.GetBSAByMostellera();

            cg_bsaResult = 1.73 * cg_Result / bsaMostellera;

            return Math.Round(cg_bsaResult, 2);
        }

        private double GetCreatinineInMgDl()
        {
            double creatitineMgDl = paramsForGRF.Creatinine;
            if (paramsForGRF.isMkMolL)
            {
                creatitineMgDl = (creatitineMgDl * creatinineMr) / 10 * 0.001;
            }
            else if (paramsForGRF.isMMolL)
            {
                creatitineMgDl = (creatitineMgDl * creatinineMr) / 10;
            }
            return creatitineMgDl;
        }
    }
}
