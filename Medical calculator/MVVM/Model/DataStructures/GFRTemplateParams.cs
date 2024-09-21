namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class GFRTemplateParams
    {
        public readonly double ckd_epiResult;
        public readonly double mdrdResult;
        public readonly double cg_Result;
        public readonly double cg_bsa_Result;

        public GFRTemplateParams(double ckd_epiResult, double mdrdResult, double cg_Result, double cg_bsa_Result)
        {
            this.ckd_epiResult = ckd_epiResult;
            this.mdrdResult = mdrdResult;
            this.cg_Result = cg_Result;
            this.cg_bsa_Result = cg_bsa_Result;
        }
    }
}
