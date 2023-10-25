using Infragistics.Documents.Excel;
using Infragistics.Windows.DataPresenter.ExcelExporter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamDataGrid_Excel
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TestData> testData = null;
        public MainWindow()
        {
            InitializeComponent();

            testData = new ObservableCollection<TestData>();

            testData.Add(new TestData { Id = 1, Test1 = 35200, Test2 = "Test1" });
            testData.Add(new TestData { Id = 2, Test1 = 34000, Test2 = "Test2" });
            testData.Add(new TestData { Id = 3, Test1 = 36300, Test2 = "Test3" });
            testData.Add(new TestData { Id = 4, Test1 = 34600, Test2 = "Test4" });

            this.DataContext = testData;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataPresenterExcelExporter exporter = new DataPresenterExcelExporter();

            Workbook wb = Workbook.Load(@"..\..\Excel\template.xlsx");

            Worksheet ws = wb.Worksheets.Add("newSheet");
            wb.WindowOptions.SelectedWorksheet = ws;

            exporter.Export(this.xamDataGrid1, ws);

            wb.Save(@"..\..\Excel\out.xlsx");
        }
    }

    public class TestData : INotifyPropertyChanged
    {
        private int m_id;
        public int Id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private int m_test1;
        public int Test1
        {
            get { return m_test1; }
            set
            {
                m_test1 = value;
                NotifyPropertyChanged("Test1");
            }
        }

        private String m_test2;
        public String Test2
        {
            get { return m_test2; }
            set
            {
                m_test2 = value;
                NotifyPropertyChanged("Test2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
