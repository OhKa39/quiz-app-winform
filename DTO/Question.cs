using System.Data;

namespace DTO
{
    public class Question
    {
        private int questionID;
        private string description;
        private int subjectID;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;
        private int trueAnswer;
        private DateTime createAt;
        private int accountID;
        private int isOK;
        private int questionType;

        public Question(DataRow data)
        {
            QuestionID = (int)data["QuestionID"];
            Description = data["Description"].ToString();
            SubjectID = (int)data["SubjectID"];
            Answer1 = data["Answer1"].ToString();
            Answer2 = data["Answer2"].ToString();
            Answer3 = data["Answer3"].ToString();
            Answer4 = data["Answer4"].ToString();
            TrueAnswer = (int)data["TrueAnswer"];
            CreateAt = (DateTime)data["CreateAt"];
            AccountID = (int)data["AccountID"];
            IsOK = (int)data["IsOK"];
            QuestionType = (int)data["QuestionType"];
        }

        public int QuestionID { get => questionID; set => questionID = value; }
        public string Description { get => description; set => description = value; }
        public int SubjectID { get => subjectID; set => subjectID = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public string Answer4 { get => answer4; set => answer4 = value; }
        public int TrueAnswer { get => trueAnswer; set => trueAnswer = value; }
        public DateTime CreateAt { get => createAt; set => createAt = value; }
        public int AccountID { get => accountID; set => accountID = value; }
        public int IsOK { get => isOK; set => isOK = value; }
        public int QuestionType { get => questionType; set => questionType = value; }
    }
}