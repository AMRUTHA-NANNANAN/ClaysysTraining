using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Login
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("ID should not be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!Regex.IsMatch(textBox7.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("ID must contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name should not be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (textBox1.Text.Length < 4 || textBox1.Text.Length > 20)
            {
                MessageBox.Show("Name should be between 4 to 20 charecters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            else if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Name contains only letters only letters and spaces", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Show();
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (textBox2.Text == "")
            {
                MessageBox.Show("Email should not be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!Regex.IsMatch(textBox2.Text, pattern))
            {
                MessageBox.Show("Invalid Email Address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Show();
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            if (textBox3.Text == "")
            {
                MessageBox.Show("Phone number should not be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!Regex.IsMatch(textBox3.Text, pattern))
            {
                MessageBox.Show("Enter a valid phone number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Show();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9_]+$";

            if (textBox4.Text == "")
            {
                MessageBox.Show("Username number should not be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (textBox4.Text.Length < 4 || textBox1.Text.Length > 20)
            {
                MessageBox.Show("Name should be between 4 to 20 charecters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!Regex.IsMatch(textBox4.Text, pattern))
            {
                MessageBox.Show(" Only allow letters, numbers, and underscores", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Show();
            }

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            
            if (textBox6.Text == "")
            {
                MessageBox.Show("Password should not be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            else if (textBox5.Text!= textBox6.Text)
            {
                MessageBox.Show("password and confirm password doesnot match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Show();
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=]).*$";
            if (!Regex.IsMatch(textBox5.Text, pattern))
            {
                MessageBox.Show("The password contains at least one uppercase letter, one lowercase letter , one digit, and one special character");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-MCVP1IJ\\SQLEXPRESS;Initial Catalog=\"REGISTRATION ASP\";Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into register values(@ID,@Name,@Phone,@Email,@Dateofbirth,@Username,@Password,@Cpassword)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox2.Text);
            cmd.Parameters.AddWithValue("@Dateofbirth",Convert.ToDateTime(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Username", textBox4.Text);
            cmd.Parameters.AddWithValue("@Password", textBox5.Text);
            cmd.Parameters.AddWithValue("@Cpassword", textBox6.Text);
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Register Successfully");
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
