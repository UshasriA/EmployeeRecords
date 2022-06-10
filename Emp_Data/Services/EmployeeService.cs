using Emp_Data.Validations;
using Emp_ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace Emp_Data.Services
{
    public class EmployeeService
    {
        private static EmployeeService instance = null;
        public static EmployeeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return instance;
            }
        }
        public void SaveEmployee(DataTable EmployeeData, Label StatusLbl = null)
        {
            bool isDataValid = HomePageValidations.Instance.ValidateEmployeeData(EmployeeData, StatusLbl);

            if (isDataValid)
            {
                List<Employee_details> employeesToSave = (from DataRow dr in EmployeeData.Rows
                                                    select new Employee_details()
                                                    {
                                                        Serial_No = Convert.ToInt32(dr["Serial No"]),
                                                        Employee_ID = Convert.ToInt32(dr["Employee ID"]),
                                                        First_Name = dr["First Name"].ToString(),
                                                        Last_Name = dr["Last Name"].ToString(),
                                                        Date_of_Birth = DateTime.ParseExact(dr["Date of Birth"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                                        Date_of_Joining = DateTime.ParseExact(dr["Date of Joining"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                                        Address = dr["Address"].ToString(),
                                                        Department = dr["Department"].ToString()
                                                    }).ToList();

                using (var CSVdbcontext = new CSVEntities())
                {

                    var existingEmployees = CSVdbcontext.Employee_details.ToList().Where(a => employeesToSave.Any(e => e.Employee_ID == a.Employee_ID)).ToList();
                    if (existingEmployees == null || existingEmployees.Count == 0)
                    {

                        foreach (var item in employeesToSave)
                        {
                            CSVdbcontext.Employee_details.Add(item);
                            CSVdbcontext.SaveChanges();
                        }

                        StatusLbl.Text = "DATA INSERTED SUCESSFULLY.";
                    }
                    else
                    {

                        StatusLbl.Text = "Employee Id is already exisiting in db" + string.Join(",", existingEmployees.Select(e => e.Employee_ID).ToList()) + "Please try with different emplyoee Id's";
                    }
                }
            }
        }
    }
}