using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<SecurityThreat> currentList;
        private ObservableCollection<LogEntry> log = new ObservableCollection<LogEntry>();
        private int currectPage;
        const int numberOfRecordsPerPage=15;
        private int countUpdated;
        public MainWindow()
        {
            
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            currentList = Parser.ParseFile(@"D:\thrlist.xlsx");
            if (currentList != null)
            {
                securityTreats.ItemsSource = currentList.Take(numberOfRecordsPerPage);
            }
            else
            {
                NoDataLabel.Visibility = Visibility.Visible;
            }
            currectPage = 1;
            PreviousButton.IsEnabled = false;

        }

        private void ShowRecord_Click(object sender, RoutedEventArgs e)
        {
            var rec = securityTreats.SelectedItem as SecurityThreat;

            Record record = new Record();
            if (rec != null)
            {
                record.Show();
            
                record.TextId.Text = rec.Id.ToString();
                record.TextName.Text = rec.Name;
                record.TextDescription.Text = rec.Description;
                record.TextSource.Text = rec.Source;
                record.TextTarget.Text = rec.Target;
                record.Confid.IsChecked = rec.Сonfidentiality;
                record.Integrity.IsChecked = rec.Integrity;
                record.Availability.IsChecked = rec.Availability;
            }

        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {

            securityTreats.ItemsSource = MoveToPrev(currentList);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            securityTreats.ItemsSource = MoveToNext(currentList);
        }

        private ObservableCollection<SecurityThreat> MoveToNext(ObservableCollection<SecurityThreat> lst)
        {
            ObservableCollection<SecurityThreat> pageList = new ObservableCollection<SecurityThreat>();
            for (int i = currectPage*numberOfRecordsPerPage; i < (currectPage+1)*numberOfRecordsPerPage; i++)
            {
                if (i == lst.Count)
                {
                    break;
                }
                pageList.Add(lst[i]);
            }
            currectPage++;
            if (currectPage == lst.Count / numberOfRecordsPerPage + 1)
                NextButton.IsEnabled = false;
            if (currectPage > 1)
                PreviousButton.IsEnabled = true;
            return pageList;

        }

        private ObservableCollection<SecurityThreat> MoveToPrev(ObservableCollection<SecurityThreat> lst)
        {
            ObservableCollection<SecurityThreat> pageList = new ObservableCollection<SecurityThreat>();
            for (int i = (currectPage-2) * numberOfRecordsPerPage; i < (currectPage-1) * numberOfRecordsPerPage; i++)
            {
                pageList.Add(lst[i]);
            }
            if (currectPage == 2)
                PreviousButton.IsEnabled = false;
            if (currectPage < lst.Count / numberOfRecordsPerPage +2)
                NextButton.IsEnabled = true;
            currectPage--;
            
            return pageList;

        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentList == null)
            {
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile("https://bdu.fstec.ru/files/documents/thrlist.xlsx", @"D:\thrlist.xlsx");
                currentList = Parser.ParseFile(@"D:\thrlist.xlsx");
                securityTreats.ItemsSource = currentList.Take(numberOfRecordsPerPage);
            }
            else
            {
                var updatedList= Parser.ParseFile(@"D:\thrlist.xlsx");
                if (updatedList == null)
                {
                    MessageBox.Show("Файл не найден");
                }
                else
                {
                    Compare(currentList, updatedList);
                    currentList = updatedList;
                    currectPage = 1;
                    NextButton.IsEnabled = true;
                    PreviousButton.IsEnabled = false;
                    securityTreats.ItemsSource = currentList.Take(numberOfRecordsPerPage);
                    
                    MessageBox.Show($"Данные успешно загружены!\nОбновлено {log.Count-countUpdated}");
                    countUpdated = log.Count;
                }

            }

            if (currentList != null)
            {
                NoDataLabel.Visibility = Visibility.Hidden;
            }
        }

        private void Compare(ObservableCollection<SecurityThreat> baseList, ObservableCollection<SecurityThreat> newList)
        {

            foreach (var item in newList)
            {
                var existingItem=baseList.FirstOrDefault(x=>x.Id==item.Id);
                if (existingItem != null)
                {
                    if (!existingItem.Equals(item))
                    {
                        log.Add(new LogEntry() { Before = existingItem, After = item });
                    }
                }
                else
                {
                    log.Add(new LogEntry() { Before =null, After = item });
                }
            
            }
            foreach (var item in baseList)
            {
                if (!newList.Any(c => c.Id == item.Id))
                {
                    log.Add(new LogEntry() { Before = item, After = null });
                }
            }

        }

        private void UpdateLog_Click(object sender, RoutedEventArgs e)
        {
            UpdateLog logModal = new UpdateLog();
            logModal.Show();
            if (log != null)
            {
                logModal.LogGrid.ItemsSource = log;
                
            }
            
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            string fileName = @"D:\SecutiryThreats";
            int k = 1;
            string fileExtension = ".xlsx";
            string availableFileName = fileName;
            while (File.Exists(availableFileName + fileExtension))
            {
                availableFileName = fileName + k;
                k++;
            }
            FileInfo file = new FileInfo(availableFileName + fileExtension);
            
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Data1");
             
                
            
                worksheet.Cells[1, 1].Value = "Идентификатор";
                worksheet.Cells[1, 2].Value = "Наименование";
                worksheet.Cells[1, 3].Value = "Описание";
                worksheet.Cells[1, 4].Value = "Источник";
                worksheet.Cells[1, 5].Value = "Объект воздействия";
                worksheet.Cells[1, 6].Value = "Нарушение конфиденциальности";
                worksheet.Cells[1, 7].Value = "Нарушение целостности";
                worksheet.Cells[1, 8].Value = "Нарушение доступности";

                for (int i = 0; i < currentList.Count; i++)
                {
                    worksheet.Cells[i+2, 1].Value = currentList[i].Id;
                    worksheet.Cells[i+2, 2].Value = currentList[i].Name;
                    worksheet.Cells[i+2, 3].Value = currentList[i].Description;
                    worksheet.Cells[i+2, 4].Value = currentList[i].Source;
                    worksheet.Cells[i+2, 5].Value = currentList[i].Target;
                    worksheet.Cells[i+2, 6].Value = currentList[i].Сonfidentiality;
                    worksheet.Cells[i+2, 7].Value = currentList[i].Integrity;
                    worksheet.Cells[i+2, 8].Value = currentList[i].Availability;
                }

                excelPackage.SaveAs(file);
            }
        }
    }

}
