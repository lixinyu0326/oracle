using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OracleText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //连接数据库文字列
            string sqlstr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.11.48)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=system;Password=123456;";
            //连接
            using (OracleConnection conn = new OracleConnection(sqlstr)) {
                conn.Open();
                Console.WriteLine("データベース:");
                Console.WriteLine("Connection State:" + conn.State);
                Console.WriteLine();
                //SQL文
                String sql = "select name,age,salary from table1";
                //查询 执行数据库
                using (OracleCommand cmd=new OracleCommand(sql,conn)) { 
                    OracleDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("name\tage\tsalary");
                    while (dr.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", dr[0], dr[1], dr[2]); 
                    }
                    Console.WriteLine("select成功");
                    Console.WriteLine();
                    Console.ReadKey();
                
                }

                //添加 执行数据库
                string sqlIn = "insert into table1 values('劉',35,'女','004','2000','teacher','20210908')";
                using (OracleCommand cmdIn=new OracleCommand(sqlIn,conn)) {
                    int count = cmdIn.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine("insert成功");
                        Console.ReadKey();
                    
                    }
                    else
                    {
                        Console.WriteLine("insert失敗");
                    }

                    

                }

                string sqlDelete = "delete table1 where name='劉'";
                using (OracleCommand cmdIn = new OracleCommand(sqlDelete, conn))
                {
                    int count = cmdIn.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine("delete成功");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("delete失敗");
                    }

                    

                }

                string sqlUpdate = "Update table1 set name='趙',age=20,salary=3000 where name='李'";
                using (OracleCommand cmdIn = new OracleCommand(sqlUpdate, conn))
                {
                    int count = cmdIn.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine("Update成功");
                        Console.ReadKey();


                    }
                    else
                    {
                        Console.WriteLine("Update失敗");
                    }
                 

                }
            }
                

        }
    }
}
