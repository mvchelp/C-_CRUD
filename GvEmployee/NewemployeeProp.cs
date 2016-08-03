using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gridview.GvEmployee
{
    public class NewemployeeProp
    {
        private int _EmpId;
        protected string _FirstName;
        protected string _LastName;
        protected int _Gender;
        protected string _DepartmentName;
        protected int _Salary;

        protected int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }
        protected string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        protected string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        protected int Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        protected string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        protected int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
    }
}