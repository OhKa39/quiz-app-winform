﻿using System.Data;

namespace DTO
{
    public class Question
    {
        private int questionID;
        private string? description;
        private string? subjectName;
        private string? answer1;
        private string? answer2;
        private string? answer3;
        private string? answer4;
        private int trueAnswer;
        private bool isOK;
        private bool questionType;

        public Question(DataRow data)
        {
            QuestionID = (int)data["QuestionID"];
            Description = data["Description"].ToString();
            SubjectName = data["SubjectName"] as string;
            Answer1 = data["Answer1"].ToString();
            Answer2 = data["Answer2"].ToString();
            Answer3 = data["Answer3"].ToString();
            Answer4 = data["Answer4"].ToString();
            TrueAnswer = (int)data["TrueAnswer"];
            IsOK = (bool)data["IsOK"];
            QuestionType = (bool)data["QuestionType"];
        }

        public int QuestionID { get => questionID; set => questionID = value; }
        public string Description { get => description; set => description = value; }
        public string SubjectName { get => subjectName; set => subjectName = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public string Answer4 { get => answer4; set => answer4 = value; }
        public int TrueAnswer { get => trueAnswer; set => trueAnswer = value; }
        public bool IsOK { get => isOK; set => isOK = value; }
        public bool QuestionType { get => questionType; set => questionType = value; }
    }
}