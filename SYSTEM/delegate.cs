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
    public partial class @delegate : Form
    {
        private string connectionstring = "Data Source = DESKTOP-S6LMGSE\\SQLEXPRESS;" + " Database = SYSTEM; " + " Integrated Security = True;";

        public @delegate()
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
            course course = new course();   
            course.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            teacher teacher = new teacher();
            teacher.Show(); 
            this.Hide();
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
            string insertQuery = "INSERT INTO DELEGATE(DELEGATE_ID, DELEGATE_Name, COURSE_ID, D_LEVEL) VALUES (@delegateid, @name, @courseid, @level)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = insertQuery;

            cmd.Parameters.AddWithValue("@delegateid", delegateid.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@level", level.Text);
            cmd.Parameters.AddWithValue("@courseid", courseid.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("created successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.Dispose();

            con.Close();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string updateQuery = "UPDATE DELEGATE SET  DELEGATE_ID = @delegateid, DELEGATE_Name = @name,  COURSE_ID = @courseid, D_LEVEL = @level WHERE DELEGATE_ID = @delegateid";
            SqlCommand cmd = new SqlCommand(updateQuery, con);

            cmd.Parameters.AddWithValue("@delegateid", delegateid.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@level", level.Text);
            cmd.Parameters.AddWithValue("@courseid", courseid.Text);
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
            string readQuery = "SELECT * FROM DELEGATE";
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
            string deleteQuery = "DELETE FROM  DELEGATE   WHERE DELEGATE_ID = @delegateid";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);

            cmd.Parameters.AddWithValue("@delegateid", delegateid.Text);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("DELETE Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delegate_Load(object sender, EventArgs e)
        {

        }
    }
}
