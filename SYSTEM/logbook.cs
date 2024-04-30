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
    public partial class logbook : Form
    {
        private string connectionstring = "Data Source = DESKTOP-S6LMGSE\\SQLEXPRESS;" + " Database = SYSTEM; " + " Integrated Security = True;";

        public logbook()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void teacherid_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string deleteQuery = "DELETE FROM  LOGBOOK   WHERE LOGBOOK_ID = @logbook";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@logbookid ", logbookid.Text);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("DELETE Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            @delegate @delegate = new @delegate();
            @delegate.Show();
            this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string insertQuery = "INSERT INTO LOGBOOK(LOGBOOK_ID, TEACHER_ID, COURSE_ID, DELEGATE_ID, DATE,HOURS_SPENT,WORKDONE, STATU) VALUES ( @logbookid,@teacherid, @courseid, @delegateid, @date, @hp,@wd, @statu)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = insertQuery;

            cmd.Parameters.AddWithValue("@logbookid", logbookid.Text);
            cmd.Parameters.AddWithValue("@teacherid", teacherid.Text);
            cmd.Parameters.AddWithValue("@courseid", courseid.Text);
            cmd.Parameters.AddWithValue("@delegateid", delegateid.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);


            cmd.Parameters.AddWithValue("@hp", hs);
            cmd.Parameters.AddWithValue("@wd", wd.Text);
            cmd.Parameters.AddWithValue("@statu", comboBox1.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("created successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.Dispose();

            con.Close();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string updateQuery = "UPDATE LOGBOOK SET  LOGBOOK_ID = @logbookid, TEARCHER__ID = @teacherid, COURSE__ID = courseid, DELEGATE__ID = @delegateid, DATE = @date,HOURS_SPENT=@hp, WORKDONE = @wd ,STATU=@statu  WHERE LOGBOOK_ID = @logbookid";
            SqlCommand cmd = new SqlCommand(updateQuery, con);

            cmd.Parameters.AddWithValue("@logbookid", logbookid.Text);
            cmd.Parameters.AddWithValue("@teacherid", teacherid.Text);
            cmd.Parameters.AddWithValue("@courseid", courseid.Text);
            cmd.Parameters.AddWithValue("@delegateid", delegateid.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);


            cmd.Parameters.AddWithValue("@hp", hs);
            cmd.Parameters.AddWithValue("@wd", wd.Text);
            cmd.Parameters.AddWithValue("@statu", comboBox1.Text);
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
            string readQuery = "SELECT * FROM LOGBOOK";
            SqlDataAdapter sda = new SqlDataAdapter(readQuery, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void logbook_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'sYSTEMDataSet.LOGBOOK'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.lOGBOOKTableAdapter.Fill(this.sYSTEMDataSet.LOGBOOK);

        }
    }
}
