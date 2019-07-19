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

namespace ConnectOIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnDB_Click(object sender, EventArgs e)
        {
            string strSQL = textBoxSQL.Text.ToString();
            SqlConnection con = new SqlConnection("database=SIPLACEOIS;Password=Siplace%Sa.1.Pwd;User ID=sa;server="+strSQL+"");
            SqlCommand cm = new SqlCommand();
            cm.Connection = con;
            cm.CommandText = "select * from BOARD";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            DataSet ds = new DataSet();
            da.Fill(ds, "lPanel");
            dataGridView1.DataSource = ds.Tables["lPanel"];
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("database=SIPLACEOIS;Password=Siplace%Sa.1.Pwd;User ID=sa;server=DESKTOP-99L3CJR\\SIPLACE_2012EX");
            SqlCommand cm = new SqlCommand();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            cm.Connection = con;
            cm.CommandText = "SELECT strRecipe as Panel,sum (lPanel)as Product_Panel_Quantity FROM[SiplaceOIS].[dbo].[BOARD] Where dtTime between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by strRecipe";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            DataSet ds = new DataSet();
            da.Fill(ds, "strRecipe as Panel,sum (lPanel)as Product_Panel_Quantity");
            dataGridView1.DataSource = ds.Tables["strRecipe as Panel,sum (lPanel)as Product_Panel_Quantity"];
        }
    }
}
