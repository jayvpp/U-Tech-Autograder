using System.Collections.Generic;
using System.Linq;

namespace AutoGrader.Models.BasicTypes
{
    public class TestResult
    {
        public int TestId { get; set; }
        public ICollection<QuestionResponses> Responses { get; set; }


        public QuestionResponses Find(int id)
        {
            return Responses.ToList().FirstOrDefault(qr => qr.QuestionId == id);
        }
    }
}