using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuestionTest
    {
        private int questionID;
        private string? description;
        private string? answer1;
        private string? answer2;
        private string? answer3;
        private string? answer4;
        private int trueAnswer;

        public QuestionTest(DataRow data)
        {
            QuestionID = (int)data["QuestionID"];
            Description = data["Description"].ToString();
            Answer1 = data["Answer1"].ToString();
            Answer2 = data["Answer2"].ToString();
            Answer3 = data["Answer3"].ToString();
            Answer4 = data["Answer4"].ToString();
            TrueAnswer = (int)data["TrueAnswer"];  
        }

        public int QuestionID { get => questionID; set => questionID = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Description { get => description; set => description = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public string Answer4 { get => answer4; set => answer4 = value; }
        public int TrueAnswer { get => trueAnswer; set => trueAnswer = value; }
    }
}
