using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Student_RecordSystem
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
        }

        private void GetStudentRecord()
        {
            LoadData();
        }

        private void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JKF19U6;Initial Catalog=StudenRecord;persist security info=True;Integrated Security=SSPI;");
            SqlCommand cmd = new SqlCommand("Select * from StudentTb", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-JKF19U6;Initial Catalog=StudenRecord;persist security info=True;Integrated Security=SSPI;"))
            {
                try
                {
                    conn.Open();
                    string sql = "insert into [StudentTb] values (@StudentName,@StudentNumber,@StudentAddress);";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@StudentName", textBoxStName.Text); 
                        cmd.Parameters.AddWithValue("@StudentNumber", textBoxNum.Text); 
                        cmd.Parameters.AddWithValue("@StudentAddress", textBoxAddress.Text); 
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        textBoxStName.Text = "";
                        textBoxNum.Text = "";
                        textBoxAddress.Text = "";
                        MessageBox.Show("Student Data successfully", "Success");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxStName.Text = "";
            textBoxNum.Text = "";
            textBoxAddress.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-JKF19U6;Initial Catalog=StudenRecord;persist security info=True;Integrated Security=SSPI;"))
            {
                try
                {
                    conn.Open();
                    string sql = "update StudentTb set StudentName=@StudentName, StudentNumber=@StudentNumber , StudentAddress=@StudentAddress where StudentID=@StudentID";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", Convert.ToInt32(textBoxID.Text));       
                        cmd.Parameters.AddWithValue("@StudentName", textBoxStName.Text); 
                        cmd.Parameters.AddWithValue("@StudentNumber", textBoxNum.Text); 
                        cmd.Parameters.AddWithValue("@StudentAddress", textBoxAddress.Text); 
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        textBoxID.Text = "";
                        textBoxStName.Text = "";
                        textBoxNum.Text = "";
                        textBoxAddress.Text = "";
                        MessageBox.Show("Student Data Updated Thanks", "Success");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-JKF19U6;Initial Catalog=StudenRecord;persist security info=True;Integrated Security=SSPI;"))
            {
                try
                {
                    conn.Open();
                    string sql = "delete StudentTb where StudentID=@StudentID";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", Convert.ToInt32(textBoxID.Text));                        
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        textBoxID.Text = "";
                        textBoxStName.Text = "";
                        textBoxNum.Text = "";
                        textBoxAddress.Text = "";
                        MessageBox.Show("Student Data Delete Record", "Success");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private void StudentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxID.Text = StudentGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxStName.Text = StudentGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxNum.Text = StudentGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxAddress.Text = StudentGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            

        }
    }
}
