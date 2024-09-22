namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class CaConcTemplateParams
    {
        public readonly double caConcInDl;
        public readonly double caConcInMmol;

        public CaConcTemplateParams(double caConcInDl, double caConcInMmol)
        {
            this.caConcInDl = caConcInDl;
            this.caConcInMmol = caConcInMmol;
        }
    }
}
