using System.Data;

namespace DTO
{
    public class Question
    {
        private int questionID;
        private string questionDetail;
        private string difficultName;
        private string subjectName; 
        private DateTime updateAt;
        private bool isTest;
        private bool isOK;

        public Question() { }

        public Question(DataRow data)
        {
            QuestionID = (int)data["QuestionID"];
            SubjectName = data["SubjectName"] as string;
            QuestionDetail = data["QuestionDetail"] as string;
            DifficultName = data["DifficultName"] as string;
            UpdateAt = (DateTime)data["updateAt"];
            IsTest = (bool)data["IsTest"];
            IsOK = (bool)data["IsOK"];
        }

        public Question(Question _question)
        {
            QuestionID = _question.QuestionID;
            SubjectName = _question.SubjectName;
            QuestionDetail = _question.QuestionDetail;
            DifficultName = _question.DifficultName;
            UpdateAt = _question.UpdateAt;
            IsTest = _question.IsTest;
            IsOK = _question.IsOK;
        }

        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionDetail { get => questionDetail; set => questionDetail = value; }
        public string DifficultName { get => difficultName; set => difficultName = value; }
        public string SubjectName { get => subjectName; set => subjectName = value; }
        public DateTime UpdateAt { get => updateAt; set => updateAt = value; }
        public bool IsTest { get => isTest; set => isTest = value; }
        public bool IsOK { get => isOK; set => isOK = value; }
    }
}