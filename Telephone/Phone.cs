using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Telephone
{
    public partial class Phone : Form
    {
        SqlConnection con = new SqlConnection("Data Source=TONEY\\SQLEXPRESS;Initial Catalog=PhoneBook;Integrated Security=True;Encrypt=False;");
        //  SqlConnection con = new SqlConnection("Data Source=TONEY\\SQLEXPRESS;Initial Catalog=PhoneBook;Integrated Security=True;Encrypt=False; Trust Server Certificate=TRUE");

      
      
      
        public Phone()
        {
            InitializeComponent();
         //   this.ActiveControl = textBox1;
         //   textBox1.Focus();
        }
     
        private void label1_Click(object sender, EventArgs e)
        {
        


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox5.Clear();
            textBox4.Text = "";
           textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
          
        }

      
        private void Phone_Load(object sender, EventArgs e)
        {
            Display();
        }
       
        private void button2_Click(object sender, EventArgs e)
            
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Mobileone (FirstName,LastName,MobileNumber,Email,Catagory)
           VALUES ('" + textBox1.Text +  "' , '" + textBox5.Text + " ' ,'" + textBox4.Text + " ' , ' " + textBox3.Text + " ' , ' " +comboBox1.Text + " '  ) ", con);
            cmd.ExecuteNonQuery();
            
            con.Close();
            MessageBox.Show("Successfully Completed");
           // Display();
        }
      public   void Display()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(" select * from Mobileone", con);
            DataTable dt = new DataTable();


            adapter.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows) {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Mobileone  WHERE  (MobileNumber = '" +textBox4.Text + " ')", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Delete Successfully");
            // Display();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // @ UPDATE Mobileone SET FirstName = '" +textBox1.Text + " ', LastName = '" +textBox5.Text + " ', MobileNumber = ' " +textBox4.Text + " ',
            // Email = '" + textBox3.Text + " ', Catagory = '" +comboBox1.Text + " '  WHERE(MobileNumber = ' " +textBox4.Text + " ')",con);


            /*

                            con.Open();
                        SqlCommand cmd = new SqlCommand(@" UPDATE Mobileone  SET  FirstName = '" +textBox1.Text + " ', LastName = '" +textBox5.Text + " ', MobileNumber = ' " +textBox4.Text + " ', Email = '" + textBox3.Text + " ', Catagory = '" +comboBox1.Text + " '  WHERE     (MobileNumber = ' " +textBox4.Text + " ')",con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("Update  Sucessfully.........."); */



         //   using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"
        UPDATE Mobileone 
        SET FirstName = @FirstName, 
            LastName = @LastName, 
            MobileNumber = @MobileNumber, 
            Email = @Email, 
            Catagory = @Catagory
        WHERE MobileNumber = @OldMobileNumber", con);

                // Define parameters
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox5.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Catagory", comboBox1.Text);
                cmd.Parameters.AddWithValue("@OldMobileNumber", textBox4.Text);

                // Execute the command
                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Update Successfully..........");
        } 

    }
}
