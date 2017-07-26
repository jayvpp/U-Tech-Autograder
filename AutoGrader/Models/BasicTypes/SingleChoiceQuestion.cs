namespace AutoGrader.Models.BasicTypes
{
    public class SingleChoiceQuestion : Question
    {
        public string[] PosibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}