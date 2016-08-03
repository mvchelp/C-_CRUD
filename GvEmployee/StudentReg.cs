using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gridview.GvEmployee
{
    public class StudentReg
    {
        private int _StudentId;
        private string _FirstName;
        private string _LastName;
        private string _gender;
        private string _Language;
        private string _EmailId;

        public int StudentId
        {
            get { return StudentId; }
            set { StudentId = value; }
        }

        public int FirstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public int LastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public int Gender
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public int Language
        {
            get { return Language; }
            set { Language = value; }
        }

        public int EmailId
        {
            get { return EmailId; }
            set { EmailId = value; }
        }
    }
}