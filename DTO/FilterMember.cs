using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTO
{
    public class FilterMember
    {
        private string difficultName = "--Độ khó--";
        private string subjectName = "--Chủ đề--";
        private string bookName = "--Sách--";
        private string isTest = "--Dạng--";
        private string isOK = "--Tình trạng--";
        private DateTime from = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        private DateTime to = DateTime.Today;
        private bool difficultNameSort = false; 
        private bool subjectSort = false;
        private bool isTestSort = false;
        private bool isOKSort = false;
        private bool UpdateTimeSort = false;

        public FilterMember() { }
        public FilterMember(FilterMember _filter)
        {
            DifficultName = _filter.DifficultName;
            DifficultNameSort = _filter.DifficultNameSort;
            SubjectName = _filter.SubjectName;
            SubjectSort = _filter.SubjectSort;
            IsTest = _filter.IsTest;
            IsTestSort = _filter.IsTestSort;
            IsOK = _filter.IsOK;
            IsOKSort = _filter.IsOKSort;
            From = _filter.From;
            To = _filter.To;
            UpdateTimeSort1 = _filter.UpdateTimeSort1;
    }

        public string DifficultName { get => difficultName; set => difficultName = value; }
        public bool DifficultNameSort { get => difficultNameSort; set => difficultNameSort = value; }
        public string SubjectName { get => subjectName; set => subjectName = value; }
        public bool SubjectSort { get => subjectSort; set => subjectSort = value; }
        public string IsTest { get => isTest; set => isTest = value; }
        public bool IsTestSort { get => isTestSort; set => isTestSort = value; }
        public string IsOK { get => isOK; set => isOK = value; }
        public bool IsOKSort { get => isOKSort; set => isOKSort = value; }
        public DateTime From { get => from; set => from = value; }
        public DateTime To { get => to; set => to = value; }
        public bool UpdateTimeSort1 { get => UpdateTimeSort; set => UpdateTimeSort = value; }
        public string BookName { get => bookName; set => bookName = value; }
    }
}
