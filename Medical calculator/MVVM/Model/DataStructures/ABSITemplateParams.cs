namespace Medical_calculator.MVVM.Model.DataStructures
{
    public class ABSITemplateParams
    {
        public readonly double absiResult;

        public readonly double bmiResult;

        public ABSITemplateParams(double absiResult, double bmiResult)
        {
            this.absiResult = absiResult;
            this.bmiResult = bmiResult;
        }
    }
}
