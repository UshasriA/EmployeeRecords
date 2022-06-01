using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Emp_Data.DataMappers
{
    public class HomePageDataMapper
    {
        private static HomePageDataMapper instance = null;
        public static HomePageDataMapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomePageDataMapper();
                }
                return instance;
            }
        }
        public DataTable MapHomePageData(DataTable employeeTable, string path)
        {
            try
            {
                string[] csvlines = File.ReadAllLines(path);

                var cols = csvlines.FirstOrDefault().Split(',').Select((val, i) => new { val, i }).Where(x => employeeTable.Columns.Cast<DataColumn>().Any(c => string.Equals(c.ColumnName.Trim(), x.val.Trim(), StringComparison.OrdinalIgnoreCase))).ToList();

                foreach (string row in csvlines.Skip(1))
                {
                    var line_values = row.Split(',').ToList();


                    List<object> Values = new List<object>();

                    foreach (var item in employeeTable.Columns.Cast<DataColumn>())
                    {

                        var l = line_values.Where(x => cols.Select(s => s.i).Contains(line_values.IndexOf(x))).FirstOrDefault(s => cols.Any(e => e.i == line_values.IndexOf(s) && e.val == item.ColumnName));
                        Values.Add(l);
                    }

                    if (Values != null && Values.Any())
                    {
                        employeeTable.Rows.Add(Values.ToArray());
                    }
                    var dt_values = line_values.Where(x => cols.Select(s => s.i).Contains(line_values.IndexOf(x))).ToList();

                }
                return employeeTable;
            }
            catch (Exception ex)
            {
                return default;
            }

        }
    }
}