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
using System.Data.SqlClient;

namespace AD2_TicketSystem
{
    /// <summary>
    /// Interaction logic for NewTicket.xaml
    /// </summary>
    public partial class NewTicket : Window
    {
        public NewTicket()
        {
            InitializeComponent();
            
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C7TQR79C;Initial Catalog=TicketDb;Integrated Security=True;Encrypt=False");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("loaded triggered");
            CbxDepartment.Items.Add("Finance");
            CbxDepartment.Items.Add("Accounts");
            CbxDepartment.Items.Add("HR");
            CbxDepartment.Items.Add("Administration");
            CbxDepartment.Items.Add("IT");
        }


        private void ClearFields()
        {
            CbxDepartment.SelectedValue = null;
            TbxSubject.Text = "";
            TbxRegDatePicker.SelectedDate = null;
            TbxMessageDetails.Text = "";
            

        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {
           
            if (TbxSubject.Text == string.Empty)
            {

                MessageBox.Show("Subject is Empty");
                return false;
            }
            if (CbxDepartment.SelectedValue == null)
            {

                MessageBox.Show("Department must be Selected");
                return false;
            }
            if (TbxRegDatePicker.Text == string.Empty)
            {

                MessageBox.Show("Date should be Entered");
                return false;
            }
            return true;
        }

        private void BtnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tickets (Department, Subject, RegDate, Details) VALUES (@department, @subject,  CONVERT(date, @regDate), @details);", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@department", CbxDepartment.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@subject", TbxSubject.Text);
                    cmd.Parameters.AddWithValue("@regDate", TbxRegDatePicker.SelectedDate);
                    cmd.Parameters.AddWithValue("@details", TbxMessageDetails.Text );
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Ticket Added");
                    ClearFields();

                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }
    }
}
