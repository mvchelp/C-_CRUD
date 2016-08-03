using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gridview.gvpaging
{
    public class employees
    {
        //private int _RowNumber;
        private int _EmpId;
        private string _FirstName;
        private string _LastName;
        private string _GenderName;
        private string _CountryName;
        private string _StateName;
        private string _CityName;
        private string _Language;
        private string _Email;

        //public int RowNumber
        //{
        //    get { return _RowNumber; }
        //    set { _RowNumber = value; }
        //}

        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
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

        public string GenderName
        {
            get { return _GenderName; }
            set { _GenderName = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}