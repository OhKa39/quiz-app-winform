using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PairQuestion
    {
        private int questionID;
        private string questionName;

        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionName 
        { 
            get => questionName; set => questionName = value.Replace("@@@", "\n"); 
        }

        public PairQuestion(int _questionID, string _questionName)
        {
            QuestionID = _questionID;
            QuestionName = _questionName.Replace("@@@", "\n");
        }

        public PairQuestion(DataRow data)
        {
            QuestionID = (int)data["QuestionID"];
            QuestionName = (data["QuestionDetail"] as string).Replace("@@@", "\n");
        }

        
    }
}
