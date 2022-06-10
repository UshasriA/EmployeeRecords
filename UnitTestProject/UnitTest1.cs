using Emp_Data.DataMappers;
using Emp_Data.DataTables;
using Emp_Data.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.UI.WebControls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeeDataTableTest()
        {
            int ActualColumns = 8;
            var emptable = EmployeeDataTable.Instance.CreateEmployeeTable();
            int ExpectedColumns = emptable.Columns.Count;
            Assert.AreEqual(ActualColumns, ExpectedColumns);
        }
        [TestMethod]
        public void EmployeeColNameTest()
        {
            string ActualColName = "Employee ID";
            var emptable = EmployeeDataTable.Instance.CreateEmployeeTable();
            string ExpectedColName = emptable.Columns[1].ColumnName;
            Assert.AreEqual(ActualColName, ExpectedColName);
        }

        [TestMethod]
        public void MapDataTest()
        {
            var emptable = EmployeeDataTable.Instance.CreateEmployeeTable();
            string path = @"D:\Tasks\Emp_Data\Emp_Data\csvfile.csv";
            var empdatatable = HomePageDataMapper.Instance.MapHomePageData(emptable, path);

            Assert.IsTrue(empdatatable.Rows.Count > 0);
        }

        [TestMethod]
        public void ValidateDataTest()
        {
            var emptable = EmployeeDataTable.Instance.CreateEmployeeTable();
            string path = @"D:\Tasks\Emp_Data\Emp_Data\csvfile.csv";
            var empdatatable = HomePageDataMapper.Instance.MapHomePageData(emptable, path);
            var lbl = new Label();
            bool result = HomePageValidations.Instance.ValidateEmployeeData(empdatatable, lbl);
            Assert.IsTrue(result);
        }

    }
}
