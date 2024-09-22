using Medical_calculator.MVVM.Model.DataStructures;

namespace Medical_calculator.MVVM.Model
{
    public static class TemplateGenerator
    {
        private const string CKD_EPI_ResponsePattern = "GFR ( CKD-EPI formula ): {0} ml/min/1.73m2\n";
        private const string MDRD_ResponsePattern = "GFR ( MDRD4 formula ): {0} ml/min/1.73m2\n";
        private const string CG_ResponsePattern = "GFR ( CG (Cockcroft−Gault) ): {0} ml/min\n";
        private const string CG_BSA_ResponsePattern = "GFR ( CG - BSA (Mostellera) ): {0} ml/min/1.73m2\n";

        private const string BSA_Mostellera_ResponsePattern = "BSA ( Mostellera ): {0} m2\n";
        private const string BSA_DuBois_ResponsePattern = "BSA ( Du Bois ): {0} m2\n";
        private const string BSA_Haycock_ResponsePattern = "BSA ( Haycock ): {0} m2\n";
        private const string BSA_GehanGeorge_ResponsePattern = "BSA ( Gehan and George ): {0} m2\n";

        private const string ABSI_ResponsePattern = "ABSI: {0}\n";
        private const string BMI_ResponsePattern = "BMI: {0}\n";

        private const string CaConcInDl_ResponsePattern = "Corrected Calcium: {0} mg/dL\n";
        private const string CaConcInMmol_ResponsePattern = "Corrected Calcium: {0} mmol/L\n";

        public static string GetGFRResponseTemplate(GFRTemplateParams gfrTemplateParams)
        {
            string result = "";

            if (gfrTemplateParams.ckd_epiResult > 0)
            {
                result += string.Format(CKD_EPI_ResponsePattern, gfrTemplateParams.ckd_epiResult);
            }

            if (gfrTemplateParams.mdrdResult > 0)
            {
                result += string.Format(MDRD_ResponsePattern, gfrTemplateParams.mdrdResult);
            }

            if (gfrTemplateParams.cg_Result > 0)
            {
                result += string.Format(CG_ResponsePattern, gfrTemplateParams.cg_Result);
            }

            if (gfrTemplateParams.cg_bsa_Result > 0)
            {
                result += string.Format(CG_BSA_ResponsePattern, gfrTemplateParams.cg_bsa_Result);
            }

            return result;
        }

        public static string GetBSAResponseTemplate(BSATemplateParams bsaTemplateParams)
        {
            string result = "";

            if (bsaTemplateParams.bsaMostellera > 0)
            {
                result += string.Format(BSA_Mostellera_ResponsePattern, bsaTemplateParams.bsaMostellera);
            }

            if (bsaTemplateParams.bsaDuBois > 0)
            {
                result += string.Format(BSA_DuBois_ResponsePattern, bsaTemplateParams.bsaDuBois);
            }

            if (bsaTemplateParams.bsaHaycock > 0)
            {
                result += string.Format(BSA_Haycock_ResponsePattern, bsaTemplateParams.bsaHaycock);
            }

            if (bsaTemplateParams.bsaGehanGeorge > 0)
            {
                result += string.Format(BSA_GehanGeorge_ResponsePattern, bsaTemplateParams.bsaGehanGeorge);
            }

            return result;
        }

        public static string GetABSIResponseTemplate(ABSITemplateParams absiTemplateParams)
        {
            string result = "";

            if (absiTemplateParams.absiResult > 0)
            {
                result += string.Format(ABSI_ResponsePattern, absiTemplateParams.absiResult);
            }

            if (absiTemplateParams.bmiResult > 0)
            {
                result += string.Format(BMI_ResponsePattern, absiTemplateParams.bmiResult);
            }

            return result;
        }

        public static string GetCaConcResponseTemplate(CaConcTemplateParams caConcTemplateParams)
        {
            string result = "";

            if (caConcTemplateParams.caConcInDl > 0)
            {
                result += string.Format(CaConcInDl_ResponsePattern, caConcTemplateParams.caConcInDl);
            }
            if(caConcTemplateParams.caConcInMmol > 0)
            {
                result += string.Format(CaConcInMmol_ResponsePattern, caConcTemplateParams.caConcInMmol);
            }

            return result;
        }
    }
}
