using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Print("Still responsive");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = await CallingAsync();
            Print(result);
        }

        private async Task<string> CallingAsync()
        {
            var httpClient = new HttpClient();
            var message = await httpClient.GetAsync("http://localhost:7071/api/Function1");
            var content = await message.Content.ReadAsStringAsync();
            return content;
        }

        private void Print(string value)
        {
            myTextBox.Text += value + Environment.NewLine;
        }
    }
}
