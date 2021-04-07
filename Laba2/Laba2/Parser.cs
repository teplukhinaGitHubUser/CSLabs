using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Parser
    {
        public static ObservableCollection<SecurityThreat> ParseFile(string path)
        {
            ObservableCollection<SecurityThreat> list = new ObservableCollection<SecurityThreat>();
            if (File.Exists(path))
            {
                var file = new FileInfo(path);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(file))
                {

                    var workSheet = package.Workbook.Worksheets[0];


                    for (int row = 3; row <= workSheet.Dimension.End.Row; row++)
                    {

                        SecurityThreat record = new SecurityThreat();

                        record.Id = "УБИ." + workSheet.Cells[row, 1].Value.ToString().Trim();
                        record.Name = workSheet.Cells[row, 2].Value.ToString().Trim();
                        record.Description = workSheet.Cells[row, 3].Value.ToString();
                        record.Source = workSheet.Cells[row, 4].Value.ToString();
                        record.Target = workSheet.Cells[row, 5].Value.ToString();
                        if (workSheet.Cells[row, 6].Value.ToString() == "1")
                            record.Сonfidentiality = true;
                        else
                            record.Сonfidentiality = false;
                        if (workSheet.Cells[row, 7].Value.ToString() == "1")
                            record.Integrity = true;
                        else
                            record.Integrity = false;
                        if (workSheet.Cells[row, 8].Value.ToString() == "1")
                            record.Availability = true;
                        else
                            record.Availability = false;



                        list.Add(record);
                    }


                }
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
