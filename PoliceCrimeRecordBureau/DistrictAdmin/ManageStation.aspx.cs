using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.DistrictAdmin
{
    public partial class ManageStation : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string district = db.extscalr("select DistrictName from Districts where DistrictId in (select [District_id] from [districtAdmin] where username='" + Session["user"] + "')");
                Label3.Text = "Registered Stations in " + district;
                show();
            }
        }
        public void show()
        {
            string district = db.extscalr("select [District_id] from [districtAdmin] where username='" + Session["user"] + "'");

            ds = db.discont("select * from PoliceStation where District_Id='" + district + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string path = "~/DistrictAdmin/P_pic/" + FileUpload1.FileName;
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                if ((ext==".jpg")||(ext==".png")||(ext==".gif")||(ext==".PNG")||(ext==".GIF")||(ext==".JPG"))
                {


                    FileUpload1.SaveAs(MapPath(path));

                    ds = db.discont("select username,stationCode from PoliceStation where username='" + TextBox6.Text + "' or stationCode='" + TextBox1.Text + "' ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Station Already Exist!!Please Try Another ')</script>");
                    }
                    else
                    {
                        string district = db.extscalr("select [District_id] from [districtAdmin] where username='" + Session["user"] + "'");
                        bool a = db.extnon("insert into PoliceStation values('" + district + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + path + "','" + TextBox6.Text + "')");
                        bool b = db.extnon("insert into Login values('" + TextBox6.Text + "','" + TextBox7.Text + "','" + '2' + "')");
                        if (a == true && b == true)
                        {
                            show();
                            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text = TextBox7.Text = "";
                            ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Station Registered')</script>");

                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Invalid Photo  ')</script>");

                }


            }


        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("Label4")).Text;
            string username = ((Label)e.Item.FindControl("Label5")).Text;
            db.extnon("delete from [PoliceStation] where station_id='" + id + "'");
            db.extnon("delete from Login where username='" + username + "'");
            show();
        }

        public bool CHECK(string input)
        {
            Label6.Visible = false;

            if ((input.Length < 8) || (input.Length > 10))
            {
                Label6.Visible = true;
                return false;


            }
            else if (!input.Contains('A') && !input.Contains('B') && !input.Contains('C') && !input.Contains('D') && !input.Contains('E') && !input.Contains('F') && !input.Contains('G') && !input.Contains('H') && !input.Contains('I') && !input.Contains('J') && !input.Contains('K') && !input.Contains('L') && !input.Contains('M') && !input.Contains('N') && !input.Contains('O') && !input.Contains('P') && !input.Contains('Q') && !input.Contains('R') && !input.Contains('S') && !input.Contains('T') && !input.Contains('U') && !input.Contains('V') && !input.Contains('W') && !input.Contains('X') && !input.Contains('Y') && !input.Contains('Z'))
            {
                Label6.Visible = true;
                return false;
            }
            else if (!input.Contains('a') && !input.Contains('b') && !input.Contains('c') && !input.Contains('d') && !input.Contains('e') && !input.Contains('f') && !input.Contains('g') && !input.Contains('h') && !input.Contains('i') && !input.Contains('j') && !input.Contains('k') && !input.Contains('l') && !input.Contains('m') && !input.Contains('n') && !input.Contains('o') && !input.Contains('p') && !input.Contains('q') && !input.Contains('r') && !input.Contains('s') && !input.Contains('t') && !input.Contains('u') && !input.Contains('v') && !input.Contains('w') && !input.Contains('x') && !input.Contains('y') && !input.Contains('z'))
            {
                Label6.Visible = true;
                return false;
            }
            else if (!input.Contains('1') && !input.Contains('2') && !input.Contains('3') && !input.Contains('4') && !input.Contains('5') && !input.Contains('6') && !input.Contains('7') && !input.Contains('8') && !input.Contains('9') && !input.Contains('0'))
            {
                Label6.Visible = true;
                return false;
            }
            else if (!input.Contains('!') && !input.Contains('~') && !input.Contains('@') && !input.Contains('#') && !input.Contains('%') && !input.Contains('$') && !input.Contains('^') && !input.Contains('&') && !input.Contains('*') && !input.Contains('(') && !input.Contains(')') && !input.Contains('_'))
            {
                Label6.Visible = true;
                return false;
            }
            else
            {
                return true;
            }

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            Label6.Visible = false;
            bool b = CHECK(TextBox7.Text);
            if (b == false)
            {
                Label6.Visible = true;
                // TextBox5.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
               
            }
        }
    }
}