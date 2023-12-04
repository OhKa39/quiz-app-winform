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
        private string createAt;
        private int accountID;
        private int isOK;
        private int questionType;

        public int QuestionID { get => questionID; set => questionID = value; }
        public string Description { get => description; set => description = value; }
        public int SubjectID { get => subjectID; set => subjectID = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public string Answer4 { get => answer4; set => answer4 = value; }
        public int TrueAnswer { get => trueAnswer; set => trueAnswer = value; }
        public string CreateAt { get => createAt; set => createAt = value; }
        public int AccountID { get => accountID; set => accountID = value; }
        public int IsOK { get => isOK; set => isOK = value; }
        public int QuestionType { get => questionType; set => questionType = value; }
    }
}