namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class BSATemplateParams
    {
        public readonly double bsaMostellera;
        public readonly double bsaDuBois;
        public readonly double bsaHaycock;
        public readonly double bsaGehanGeorge;

        public BSATemplateParams(double bsaMostellera, double bsaDuBois, double bsaHaycock, double bsaGehanGeorge)
        {
            this.bsaMostellera = bsaMostellera;
            this.bsaDuBois = bsaDuBois;
            this.bsaHaycock = bsaHaycock;
            this.bsaGehanGeorge = bsaGehanGeorge;
        }
    }
}
