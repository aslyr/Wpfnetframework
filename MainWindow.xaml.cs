using Microsoft.Win32;
using System.Windows;
using System.Management;
using System.IO;
using System.Windows.Markup;
using System.Windows.Controls;
using System;
namespace Wpfnetframework
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string xamlFile)
        {
            InitializeComponent();
            this.Title = "动态加载的xaml";
            object gys根元素;
            using (FileStream fs = new FileStream(xamlFile, FileMode.Open))
            {
                
                gys根元素 = XamlReader.Load(fs);
            }
            this.Content = gys根元素;
           
        }
        private void Button_Click(object sender,
                                  RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            //var filepath = openFileDialog.FileName;
            //var excelhelper = new ExcelHelper(filepath);
            //excelhelper.Sheet = 1;
            //excelhelper.Visilbe = false;
            //excelhelper.Cell = "i1";
            //textbox1.AppendText(excelhelper.Cell.Text);
            //SelectQuery query = new SelectQuery("Select * From PCI");
            //var search = new ManagementObjectSearcher(query);
            //foreach (var item in search.Get())
            //{
            //    textbox1.AppendText(item.ToString());
            //}



        }

        private void textbox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        
       

        private void mainWinow_Loaded(object sender, RoutedEventArgs e)
        {
            combobox1.Items.Clear();
            foreach (var item in Enum.GetValues(typeof( InkCanvasEditingMode)))
            {
                combobox1.Items.Add(item);
            }
            combobox1.SelectedIndex = 0;
        }

        private void combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inkcanvas.EditingMode = (InkCanvasEditingMode)combobox1.SelectedItem;
        }

        private void textbox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.Title = e.Key.ToString();
        }
    }
}
