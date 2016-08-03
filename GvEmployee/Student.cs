using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Gridview.GvEmployee
{
    public class Student
    {
        private int? _StudentId;
        private string _FirstName;
        private string _LastName;
        private int _RollNo;
        private string _Branch;
        private string _EmailId;
        private string _Address;


        public int? StudentId
        {
            get { return _StudentId; }
            set { _StudentId = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public int RollNo
        {
            get { return _RollNo; }
            set { _RollNo = value; }
        }

        public string Branch
        {
            get { return _Branch; }
            set { _Branch = value; }
        }

        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
}