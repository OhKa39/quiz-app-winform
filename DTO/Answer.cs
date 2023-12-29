using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Answer
    {
        private string answerDetail;
        private int answerID;
        private bool isTrue;

        public Answer() { }
        public Answer(DataRow dr)
        {
            AnswerDetail = dr["AnswerDetail"] as string;
            AnswerID = (int)dr["AnswerID"];
            IsTrue = (bool)dr["IsTrue"];
        }

        public string AnswerDetail { get => answerDetail; set => answerDetail = value; }
        public int AnswerID { get => answerID; set => answerID = value; }
        public bool IsTrue { get => isTrue; set => isTrue = value; }
    }
}
