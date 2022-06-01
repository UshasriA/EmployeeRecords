using Emp_Data.DataMappers;
using Emp_Data.DataTables;
using Emp_Data.Services;
using Emp_ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Emp_Data
{
    public partial class HomePage : System.Web.UI.Page
    {
        private static DataTable EmployeeData;

        protected void Import_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~//") + Path.GetFileName(CSVFileUpload.PostedFile.FileName);
            CSVFileUpload.SaveAs(filePath);
            DataTable employeeTable = EmployeeDataTable.Instance.CreateEmployeeTable();
            EmployeeData = HomePageDataMapper.Instance.MapHomePageData(employeeTable, filePath);
            EmployeeGrid.DataSource = EmployeeData;
            EmployeeGrid.DataBind();
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            OnSaveClick();
        }

        public void OnSaveClick()
        {
            try
            {
                EmployeeService.Instance.SaveEmployee(EmployeeData, StatusLbl);
            }
            catch (Exception ex)
            {
                StatusLbl.Text = "Unable to process your request. Please try after sometime. " + ex.ToString();
            }
        }

    }
}