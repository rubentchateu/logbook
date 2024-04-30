using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYSTEM
{
    public partial class course : Form
    {
        private string connectionstring = "Data Source = DESKTOP-S6LMGSE\\SQLEXPRESS;" + " Database = SYSTEM; " + " Integrated Security = True;";

        public course()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            administration administration = new administration();
            administration.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            teacher teacher = new teacher();
            teacher.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            @delegate @delegate = new @delegate();
            @delegate.Show();
            @delegate.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            logbook logbook = new logbook();
            logbook.Show();
            this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string insertQuery = "INSERT INTO COURSE(COURSE_ID, COURSE_Name, TEACHER_ID, HOURS_SCHEDULE) VALUES (@courseid, @name, @teachername, @hs)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = insertQuery;

            cmd.Parameters.AddWithValue("@courseid", courseid.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@teacherid", teacherid.Text);
            cmd.Parameters.AddWithValue("@hs", hs.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("created successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.Dispose();

            con.Close();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string updateQuery = "UPDATE COURSE SET  COURSE_ID = @courseid, COURSE_Name = @name, TEACHER_ID = @teacherid, HOURS_SCHEDULE = @hs WHERE COURSE_ID = @courseid";
            SqlCommand cmd = new SqlCommand(updateQuery, con);

            cmd.Parameters.AddWithValue("@courseid", courseid.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@teacherid", teacherid.Text);
            cmd.Parameters.AddWithValue("@hs", hs.Text);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Updated Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void readbtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionstring);

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Visible = false;
                }
                else if (control is NumericUpDown)
                {
                    control.Visible = false;
                }
                else if (control is Label)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }

            }
            // SqlConnection con = new SqlConnection("Data Source=YOUR-CONNECTING-STRING);
            string readQuery = "SELECT * FROM COURSE";
            SqlDataAdapter sda = new SqlDataAdapter(readQuery, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string deleteQuery = "DELETE FROM  COURSE   WHERE COURSE_ID = @courseid";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@courseid", courseid.Text);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("DELETE Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void course_Load(object sender, EventArgs e)
        {
            

        }
    }
}
