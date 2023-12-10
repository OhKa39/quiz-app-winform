using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Subject
    {
        private int SubjectID;
        private string SubjectName;

        public Subject(int _SubjectID, string _SubjectName)
        {
            SubjectID = _SubjectID;
            SubjectName = _SubjectName;
        }

        public Subject(DataRow data)
        {
            SubjectID = (int)data["SubjectID"];
            SubjectName = data["SubjectName"] as string;
        }

        public int SubjectID1 { get => SubjectID; set => SubjectID = value; }
        public string SubjectName1 { get => SubjectName; set => SubjectName = value; }
    }
}
