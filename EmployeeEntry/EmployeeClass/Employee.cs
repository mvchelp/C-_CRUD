using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeEntry.EmployeeClass
{
    public class Employee
    {
        private int _EmployeeId;
        private string _FirstName;
        private string _Lastname;
        private string _Gender;
        private string _City;
        private string _DepartmentName;
        private int _Salary;

        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }


    }
}