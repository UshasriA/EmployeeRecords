using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Emp_Data.DataTables
{
    public class EmployeeDataTable
    {
        private static EmployeeDataTable instance = null;
        public static EmployeeDataTable Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDataTable();
                }
                return instance;
            }
        }
        public DataTable CreateEmployeeTable()
        {
            DataTable empTable = new DataTable();
            empTable.Columns.AddRange(new DataColumn[8]
            {
                new DataColumn("Serial No", typeof(int)),
                 new DataColumn("Employee ID", typeof(int)),
                 new DataColumn("First Name", typeof(string)),
                 new DataColumn("Last Name", typeof(string)),
                 new DataColumn("Date of Birth", typeof(string)),
                 new DataColumn("Date of Joining",typeof(string)),
                 new DataColumn("Address", typeof(string)),
                 new DataColumn("Department", typeof(string))
            });
            return empTable;
        }

    }
}