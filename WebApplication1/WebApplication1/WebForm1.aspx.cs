using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Panel1.Visible = false;
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string swhere = "";
            string name1 = txtName.Text.Trim();
            string id1 = txtId.Text.Trim();
            string dbconn = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.11.48)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=system;Password=123456;";
            using (OracleConnection conn = new OracleConnection(dbconn)) 
            {
                conn.Open();
                swhere = " where 1=1 ";
                if (name1 != "")
                {
                    swhere += " and name like '%" + name1 + "%'";
                }

                if (id1 != "")
                {
                    swhere += " and id like '%" + id1 + "%'";
                }
                string sql = "select name,age,gender,id,salary,work,date1 from table1" + swhere;
                using (OracleCommand cmd=new OracleCommand(sql,conn))
                {
                    
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    DataTable dt = new DataTable();
                    adapter.Fill(dataSet);
                    dt=dataSet.Tables[0];
                    this.GridView1.DataSource=dt;
                    this.GridView1.DataBind();                    
                    this.Panel1.Visible = true;
                }            
            }        
        }
    }
}