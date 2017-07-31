namespace AutoGrader.Models.BasicTypes
{
    public interface IGrader
    {
        ITestGraded Grade(TestResult test);
    }
}
