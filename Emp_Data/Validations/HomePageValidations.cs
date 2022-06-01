using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Emp_Data.Validations
{
    public class HomePageValidations
    {
        private static HomePageValidations instance = null;
        public static HomePageValidations Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomePageValidations();
                }
                return instance;
            }
        }
        public bool ValidateEmployeeData(DataTable EmployeeData, Label StatusLbl)
        {
            try
            {
                DateTime dt = new DateTime();
                foreach (DataRow item in EmployeeData.Rows)
                {
                    if (item["Serial No"] == null || !(item["Serial No"] is int))
                    {
                        StatusLbl.Text = "Please enter valid Serial No at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                    else if (item["Employee ID"] == null || !(item["Employee ID"] is int))
                    {
                        StatusLbl.Text = "Please enter valid Employee ID at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                    else if (item["First Name"] == null || string.IsNullOrEmpty(item["First Name"].ToString()))
                    {
                        StatusLbl.Text = "Please enter valid First Name at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                    else if (!DateTime.TryParseExact(item["Date of Birth"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        StatusLbl.Text = "Please enter valid Date of Birth at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                    else if (!DateTime.TryParseExact(item["Date of Joining"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        StatusLbl.Text = "Please enter valid Date of Joining at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(item["Address"]?.ToString()))
                    {
                        StatusLbl.Text = "Please enter valid Address at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(item["Department"]?.ToString()))
                    {
                        StatusLbl.Text = "Please enter valid Department at " + EmployeeData.Rows.IndexOf(item);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                StatusLbl.Text = "Please enter valid Data";
                return false;
            }
        }

    }
}