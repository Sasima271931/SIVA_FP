using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace SIVA_FP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindData();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=KRISH;Initial Catalog=SS;Integrated Security=True");
                con.Open();
                SqlCommand c = new SqlCommand("insert into ssdb values('" + int.Parse(textBox4.Text) + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')", con);
                c.ExecuteNonQuery();
                MessageBox.Show("Succesfully Inserted...");
                con.Close();
                BindData();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;

            }
            
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=KRISH;Initial Catalog=SS;Integrated Security=True");
            con.Open();
            SqlCommand c = new SqlCommand("select * from ssdb", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource= dt;
        }
        void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KRISH;Initial Catalog=SS;Integrated Security=True");
            con.Open();
            SqlCommand c = new SqlCommand("update ssdb set NAME = '" + textBox1.Text + "', MOBILE ='" + textBox2.Text + "',EMAIL ='" + comboBox1.Text + "' where SNO='" + int.Parse(textBox4.Text) + "'", con);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Succesfully Updated...");
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source=KRISH;Initial Catalog=SS;Integrated Security=True");
                con.Open();
                SqlCommand c = new SqlCommand("delete ssdb where SNO='" + int.Parse(textBox4.Text) + "'", con);
                int rows = c.ExecuteNonQuery();
                con.Close();
                if(rows > 0)
                {
                    MessageBox.Show("Succesfully Deleted...");
                }
                else
                {
                    MessageBox.Show("No rows affected...");
                }
                BindData();
            }
            else
            {
                MessageBox.Show("Put SNO...");
            }
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedR = dataGridView1.SelectedRows;
            foreach (DataGridViewRow item in selectedR)
            {
                var sample = item.Cells[0].Value;
            }
        }
    }
}