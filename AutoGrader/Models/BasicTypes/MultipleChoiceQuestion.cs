namespace AutoGrader.Models.BasicTypes
{
    public class MultipleChoiceQuestion : Question
    {
        public string[] PosibleAnswers { get; set; }
        public string[] CorrectAnswers { get; set; }
    }

}