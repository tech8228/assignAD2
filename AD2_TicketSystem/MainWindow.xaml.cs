using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace AD2_TicketSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C7TQR79C;Initial Catalog=TicketDb;Integrated Security=True;Encrypt=False");
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Tickets", conn);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            dt.Load(dataReader);
            conn.Close();
            DgTickets.ItemsSource = dt.DefaultView;
        }

        private void BtnFrmRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            NewTicket addTicket = new NewTicket();
            addTicket.ShowDialog();
        }
    }
}
