using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        string dbconn = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.11.48)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=system;Password=123456;";
             
        protected void button1_Click(object sender, EventArgs e)
        {
            string name1 = txtName.Text.Trim();
            string age1 = txtAge.Text.Trim();
            string gender1 = txtGender.Text.Trim();
            string id1 = txtId.Text.Trim();
            string salary1=txtSalary.Text.Trim();    
            string work1=txtwork.Text.Trim();
            string date1 = txtDate.Text.Trim();

            using (OracleConnection conn = new OracleConnection(dbconn))
            {
                conn.Open();
                string sql = "insert into table1 values('"+name1+ "','"+age1+"','"+gender1+"','"+id1+"','"+salary1+"','"+work1+"','"+date1+"')";
                using (OracleCommand cmd=new OracleCommand(sql,conn))
                {
                    int flag = cmd.ExecuteNonQuery();
                    if (flag>0)
                    {
                        txtName.Text = string.Empty;
                        txtAge.Text = string.Empty;
                        txtGender.Text = string.Empty;
                        txtId.Text = string.Empty;
                        txtSalary.Text = string.Empty;
                        txtwork.Text = string.Empty;
                        txtDate.Text = string.Empty;
                        Response.Write("<script>alert('INSERT成功❣')</script>");
                    
                    }
                    else
                    {
                        Response.Write("<script>alert('INSERT失敗❣')</script>");
                    }
                }
            }


        }
    }
}