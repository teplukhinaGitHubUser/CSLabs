using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laba2
{
    /// <summary>
    /// Interaction logic for UpdateLog.xaml
    /// </summary>
    public partial class UpdateLog : Window
    {
        public UpdateLog()
        {
            InitializeComponent();
            
        }

        private void Differences_Click(object sender, RoutedEventArgs e)
        {
            var logEntry = LogGrid.SelectedItem as LogEntry;
            
            if (logEntry != null )
            {
                if (logEntry.Before != null && logEntry.After != null)
                {
                    NameBefore.Text = logEntry.Before.Name;
                    DescriptionBefore.Text = logEntry.Before.Description;
                    SourceBefore.Text = logEntry.Before.Source;
                    TargetBefore.Text = logEntry.Before.Target;
                    ConfidBefore.IsChecked = logEntry.Before.Сonfidentiality;
                    IntegrityBefore.IsChecked = logEntry.Before.Integrity;
                    AvailabilityBefore.IsChecked = logEntry.Before.Availability;

                    NameAfter.Text = logEntry.After.Name;
                    DescriptionAfter.Text = logEntry.After.Description;
                    SourceAfter.Text = logEntry.After.Source;
                    TargetAfter.Text = logEntry.After.Target;
                    ConfidAfter.IsChecked = logEntry.After.Сonfidentiality;
                    IntegrityAfter.IsChecked = logEntry.After.Integrity;
                    AvailabilityAfter.IsChecked = logEntry.After.Availability;
                }
                else
                {
                    MessageBox.Show("Сравнение данных невозможно для удаленных и добавленных записей");
                }
            }
        }
    }
}
