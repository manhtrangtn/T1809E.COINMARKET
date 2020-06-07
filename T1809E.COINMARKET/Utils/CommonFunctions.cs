using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace T1809E.COINMARKET.Utils
{
  public class CommonFunctions
  {
    public DataTable ReadCsvFile(string filePath)
    {
      DataTable dataTable = new DataTable();
      // var context = HttpContext.Current;
      // string fp = context.Server.MapPath(filePath);
      using (StreamReader streamReader = new StreamReader(filePath))
      {
        while (!streamReader.EndOfStream)
        {
          string fullRow = streamReader.ReadToEnd().ToString();
          string[] rows = fullRow.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

          for (int i = 0; i < rows.Count() - 1; i++)
          {
            string[] rowValues = rows[i].Split(',');
            {
              if (i == 0)
              {
                for (int j = 0; j < rowValues.Count(); j++)
                {
                  dataTable.Columns.Add(rowValues[j]);
                }
              }
              else
              {
                DataRow dataRow = dataTable.NewRow();

                for (int k = 0; k < rowValues.Count(); k++)
                {
                  dataRow[k] = rowValues[k].ToString();
                }

                dataTable.Rows.Add(dataRow);
              }
            }
          }
        }
      }

      return dataTable;
    }
  }
}