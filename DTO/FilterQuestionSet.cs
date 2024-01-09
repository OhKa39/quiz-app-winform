using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FilterQuestionSet
    {
        private string questionSetName = "";
        private string time = "--Thời gian--";
        private DateTime from = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        private DateTime to = DateTime.Today;
        private string isTest = "--Dạng--";
        private string isOK = "--Tình trạng--";
        private string totalQuestion = "--Số câu hỏi--";

        public FilterQuestionSet() { }
        public FilterQuestionSet(FilterQuestionSet _filter)
        {
            QuestionSetName = _filter.QuestionSetName;
            Time = _filter.Time;
            From = _filter.From;
            To = _filter.To;
            IsTest = _filter.IsTest;
            IsOK = _filter.IsOK;
            TotalQuestion = _filter.TotalQuestion;
        }

        public string QuestionSetName { get => questionSetName; set => questionSetName = value; }
        public string Time { get => time; set => time = value; }
        public DateTime From { get => from; set => from = value; }
        public DateTime To { get => to; set => to = value; }
        public string IsTest { get => isTest; set => isTest = value; }
        public string IsOK { get => isOK; set => isOK = value; }
        public string TotalQuestion { get => totalQuestion; set => totalQuestion = value; }
    }
}
