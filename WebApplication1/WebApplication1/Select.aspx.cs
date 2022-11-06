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
        string dbconn = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.11.48)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=system;Password=123456;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Panel1.Visible = false;
            }
        }

        protected void Table1()
        {
            string sql = "select name,age,gender,id,salary,work,date1 from table1";
            OracleConnection conn = new OracleConnection(dbconn);
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.GridView1.DataSource = dataSet;
            this.GridView1.DataBind();

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string swhere = "";
            string name1 = txtName.Text.Trim();
            string id1 = txtId.Text.Trim();
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
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    // DataTable dt = new DataTable();
                    adapter.Fill(dataSet);
                    // dt = dataSet.Tables[0];
                    this.GridView1.DataSource = dataSet;
                    this.GridView1.DataBind();
                    this.Panel1.Visible = true;
                }
            }
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string name2 = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
            string age2 = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            string gender2 = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            string salary2 = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            string work2 = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
            string date2 = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
            string id = GridView1.DataKeys[e.RowIndex]["id"].ToString();
            using (OracleConnection conn = new OracleConnection(dbconn))
            {
                conn.Open();
                string sql = "update table1 set name='" + name2 + "',age='" + age2 + "',gender='" + gender2 + "',salary='" + salary2 + "',work='" + work2 + "',date1='" + date2 + "' where id='" + id + "'";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    int flag = cmd.ExecuteNonQuery();
                    if (flag > 0)
                    {
                        Table1();
                        Response.Write("<script>alert('UPDATE成功❣')</script>");
                        GridView1.EditIndex = -1;

                    }
                    else
                    {
                        Response.Write("<script>alert('UPDATE失敗❣')</script>");
                    }
                }
            }

        }

        protected void GridVew_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // 把当前编辑的索引 赋值给控件的编辑索引(让编辑的行显示出来)
            GridView1.EditIndex = e.NewEditIndex;
            // 绑定
            Table1();
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 取出当前操作行的ID
            string id = GridView1.DataKeys[e.RowIndex]["id"].ToString();
            using (OracleConnection conn = new OracleConnection(dbconn))
            {
                conn.Open();
                string sql = "delete from table1 where id='" + id + "'";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    int flag = cmd.ExecuteNonQuery();
                    if (flag > 0)
                    {
                        Table1();
                        Response.Write("<script>alert('DELETE成功')</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('DELETE失敗')</script>");
                    }
                }
            }
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // 让编辑行的索引退回去
            GridView1.EditIndex = -1;
            // 绑定
            Table1();
        }



        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}