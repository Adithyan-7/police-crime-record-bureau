using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DbConnect
/// </summary>
/// 
namespace PoliceCrimeRecordBureau
{
    public class DbConnect
    {
         SqlConnection con = new SqlConnection("server=.;uid=sa;pwd=admin123;database=PCR_Bureau");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader rd;
        DataSet mainds = new DataSet();

        public bool extnon(string str)
        {
            con.Close();
            try
            {
                cmd = new SqlCommand(str, con);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public SqlDataReader extread(string str)
        {
            con.Close();
            cmd = new SqlCommand(str, con);
            con.Open();
            rd = cmd.ExecuteReader();
            return rd;

        }
        public string extscalr(string str)
        {
            string name = "";
            con.Close();
            cmd = new SqlCommand(str, con);
            con.Open();
            try
            {

                name = cmd.ExecuteScalar().ToString();
                return name;
            }
            catch (Exception ex)
            {
                return name;
            }

        }

        public int intextscalr(string str)
        {
            int name = 0;
            con.Close();
            cmd = new SqlCommand(str, con);
            con.Open();
            try
            {

                name = int.Parse(cmd.ExecuteScalar().ToString());
                return name;
            }
            catch (Exception ex)
            {
                return name;
            }

        }
        public DataSet discont(string str)
        {
            mainds.Clear();
            adp = new SqlDataAdapter(str, con);
            adp.Fill(mainds);
            return mainds;
        }
        DataSet mainds1 = new DataSet();
        public DataSet discont1(string str)
        {
            mainds1.Clear();
            adp = new SqlDataAdapter(str, con);
            adp.Fill(mainds1);
            return mainds1;
        }
        DataSet mainds2 = new DataSet();
        public DataSet discont2(string str)
        {
            mainds2.Clear();
            adp = new SqlDataAdapter(str, con);
            adp.Fill(mainds2);
            return mainds2;
        }
        DataTable dt = new DataTable();
        public DataTable discont3(string str)
        {
            dt.Clear();
            adp = new SqlDataAdapter(str, con);
            adp.Fill(dt);
            return dt;
        }

        public string MakePwd(int pl)
        {
            string possibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] passwords = new char[pl];
            Random rd = new Random();
            for (int i = 0; i < pl; i++)
            {
                passwords[i] = possibles[rd.Next(0, possibles.Length)];

            }
            return new string(passwords);


        }
        public string Capital_MakePwd(int pl)
        {
            string possibles = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] passwords = new char[pl];
            Random rd = new Random();
            for (int i = 0; i < pl; i++)
            {
                passwords[i] = possibles[rd.Next(0, possibles.Length)];

            }
            return new string(passwords);


        }
        public string numpassword(int pl)
        {
            {
                string possibles = "1234567890";
                char[] passwords = new char[pl];
                Random rd = new Random();
                for (int i = 0; i < pl; i++)
                {
                    passwords[i] = possibles[rd.Next(0, possibles.Length)];

                }
                return new string(passwords);
            }
        }
    }
}