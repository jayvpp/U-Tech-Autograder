using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoGrader.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Score { get; set; }

    }


    public class QuestionBase
    {
        public int Id { get; set; }
        public string Stem { get; set; }

        public int Value { get; set; }
    }


    public class MultipleChoiceQuestion : QuestionBase
    {


    }

    public class SingleChoiceQuestion : QuestionBase
    {


    }

    public class TextEnteringQuestion : QuestionBase
    {

    }



}