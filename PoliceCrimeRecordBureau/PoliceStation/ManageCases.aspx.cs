using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.PoliceStation
{
    public partial class ManageCases : System.Web.UI.Page
    {

     
      
        IndexGeneration indexes = new IndexGeneration();

        cryptography crypto = new cryptography();
 
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["user"] = "vivek";
            if (!IsPostBack)
            {

                string p_code = db.extscalr("select StationCode from [PoliceStation] where username='" + Session["user"] + "'");
                TextBox1.Text = p_code;
                string pname = db.extscalr("select StationName from [PoliceStation] where username='" + Session["user"] + "'");
                TextBox2.Text = pname;
                show_category();
                show_case();
                filter_drp();
            }
        }

        public void show_category()
        {
            ds = db.discont("select * from CaseCategory");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Category";
                DropDownList1.DataValueField = "c_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Case Type");
            }
        }
        public void filter_drp()
        {
            ds = db.discont("select * from CaseCategory");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "Category";
                DropDownList2.DataValueField = "c_id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "Filter Case Type");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if ((FileUpload1.HasFile) && (FileUpload2.HasFile))
            {
                string imagepath = "~/PoliceStation/Documents/CulpritImage/" + FileUpload2.FileName;
                FileUpload2.SaveAs(MapPath(imagepath));
                DataSet ds2 = new DataSet();
                ds2 = db.discont("select fname from File_Info where fname='" + TextBox4.Text + "'");

                if (ds2.Tables[0].Rows.Count == 0)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);

                    string path = "~/PoliceStation/Documents/Orginal/" + TextBox4.Text + ext;
                    FileUpload1.SaveAs(MapPath(path));
                  
                    string filenames = TextBox4.Text + ".txt";

                   
                



                    ////.........document Preprocessing................
 
           


                    string resultstopwordpath = Server.MapPath("~/PoliceStation/Documents/StopwordRemove_Result/" + filenames);
                    string[] keywordDataset = new string[3];
                    if (TextBox6.Text!="")
                    {
                        keywordDataset[0] = TextBox6.Text;
                    }
                    if (TextBox7.Text != "")
                    {
                        keywordDataset[1] = TextBox7.Text;
                    }
                    if (TextBox8.Text != "")
                    {
                        keywordDataset[2] = TextBox8.Text;
                    }
                    File.WriteAllLines(resultstopwordpath, keywordDataset);
                   


                    //......Knn Index Generation Steps........                      

                    string[] CleanResults = File.ReadAllLines(Server.MapPath("~/PoliceStation/Documents/StopwordRemove_Result/" + filenames));
                    var distinctWord = CleanResults.Distinct().ToArray();
                    int totalkeyword = distinctWord.Count();
                    string Hashpath = Server.MapPath("~/PoliceStation/Documents/Sha1/" + filenames);
                    string encrypted_Document_vector = indexes.Index_Generation(CleanResults, distinctWord, totalkeyword, Hashpath);


                    //.......Document Encryption............

                    string encryptionkey = db.MakePwd(TextBox4.Text.Length);
                    string inputpath = Server.MapPath("~/PoliceStation/Documents/Orginal/" + TextBox4.Text + ext);
                    string outpupth = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + TextBox4.Text + ext);


                    crypto.MultimediaEncrypt(inputpath, outpupth, encryptionkey);



                    //aws fileupload

                 //   AmazoneCloud aws = new AmazoneCloud();
                 //   aws.UploadToCloud(TextBox4.Text + ext, outpupth);



                    //...........adding keywords to datasets.........

                    string datasetpath = Server.MapPath("~/PoliceStation/Documents/dataset/keywords.txt");
                    StreamWriter log;
                    log = File.AppendText(datasetpath);
                    foreach (string onekey in CleanResults)
                    {
                        log.WriteLine(onekey.ToLower());
                    }
                    log.Close();


                    //.......Adding to database............

                    string did = db.extscalr("select District_Id from [PoliceStation] where Username='" + Session["user"] + "'");
                    string pcode = db.extscalr("select stationCode from [PoliceStation] where Username='" + Session["user"] + "'");
                    bool b = db.extnon("insert into File_Info values('" + did + "','" + pcode + "','" + DropDownList1.SelectedValue + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + imagepath + "','" + TextBox3.Text + "','" + ext + "','" + encryptionkey + "','" + encrypted_Document_vector + "','" + DateTime.Now.ToString() + "','"+radioactive.SelectedValue+"')");
                    if (b == true)
                    {
                        TextBox4.Text = TextBox3.Text = "";
                        show_case();
                        ClientScript.RegisterStartupScript(GetType(), "", "<script Language=JavaScript>alert('Successfully Added')</Script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "<script Language=JavaScript>alert('Sorry Filename Already Occured')</Script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script Language=JavaScript>alert('Upload Neccessary Files')</Script>");

            }
        }


        public void show_case()
        {
            string stcode = db.extscalr("select [stationCode] from [PoliceStation] where Username='" + Session["user"] + "' ");
            ds = db.discont("select * from [File_Info] where p_code='" + stcode + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex != 0)
            {

                string stcode = db.extscalr("select [stationCode] from [PoliceStation] where Username='" + Session["user"] + "' ");
                ds = db.discont("select * from [File_Info] where p_code='" + stcode + "' and  category='" + DropDownList2.SelectedValue + "' and isActive='"+DropDownList3.SelectedValue+"'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.Visible = false;
                    DataList2.Visible = true;

                    DataList2.DataSource = ds;
                    DataList2.DataBind();
                }
                else
                 {
                    DataList2.DataSource = null;
                    DataList2.DataBind();
                }
            }
            else
            {
                string stcode = db.extscalr("select [stationCode] from [PoliceStation] where Username='" + Session["user"] + "' ");
                ds = db.discont("select * from [File_Info] where p_code='" + stcode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.Visible = true;
                    DataList2.Visible = false;
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
                else
                {
                    DataList1.DataSource = null;
                    DataList1.DataBind();
                }
            }

            
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            Session["caseid"] = ((Label)e.Item.FindControl("Label2")).Text;
            load_CaseFile();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            Session["caseid"] = ((Label)e.Item.FindControl("Label2")).Text;
            load_CaseFile();
            MultiView1.ActiveViewIndex = 1;
        }

        public void load_CaseFile()
        {
            ds = db.discont("select * from File_Info where fid='" + Session["caseid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = db.extscalr("select Category from CaseCategory where c_id='" + ds.Tables[0].Rows[0]["category"] + "'");
                Image2.ImageUrl = ds.Tables[0].Rows[0]["CulpritImage"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["CulpritName"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["des"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["udate"].ToString();

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PoliceStation/ManageCases.aspx");
        }
        //download report
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["caseid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string fname = ds.Tables[0].Rows[0]["fname"].ToString();
                string ekey = ds.Tables[0].Rows[0]["ekey"].ToString();
                string ext = ds.Tables[0].Rows[0]["ext"].ToString();

                string outputpath = "";

                try
                {

                    if (ext == ".txt")
                    {
                        string inputpath = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + fname + ext);
                        string outputpathdemo = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ext);
                        // AmazoneCloud aws = new AmazoneCloud();
                        // aws.DownloadFromCloud(inputpath, fname + ext);
                        crypto.MultimediaDecrypt(inputpath, outputpathdemo, ekey);
                        outputpath = outputpathdemo;
                    }


                    else if ((ext == ".doc") || (ext == ".docx"))
                    {
                        //string fileName = @"F:\My projects\CrimeRecord_Bureau\CrimeRecord_Bureau\PoliceStation\Documents\down\"+fname+".docs";

                        //var doc = DocX.Create(fileName);
                        //doc.Save();


                        string inputpath = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + fname + ext);
                        string outputpathdemo = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ext);

                        //   AmazoneCloud aws = new AmazoneCloud();
                        //  aws.DownloadFromCloud(inputpath, fname + ext);
                        crypto.MultimediaDecrypt(inputpath, outputpathdemo, ekey);
                        string content = File.ReadAllText(outputpathdemo);
                        string output = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ext);
                        File.WriteAllText(output, content);
                        outputpath = output;
                    }


                    else if (ext == ".pdf")
                    {
                        string inputpath = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + fname + ext);
                        string outputpathdemo = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ext);
                        string output = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ext);
                        //AmazoneCloud aws = new AmazoneCloud();
                        // aws.DownloadFromCloud(inputpath, fname + ext);

                        crypto.MultimediaDecrypt(inputpath, outputpathdemo, ekey);

                        // string content = File.ReadAllText(outputpathdemo);
                        // Document doc = new Document();
                        // //Create PDF Table   PdfPTable tableLayout = new PdfPTable(4);
                        // //Create a PDF file in specific path  
                        // PdfWriter.GetInstance(doc, new FileStream(output, FileMode.Create));

                        //// string content = File.ReadAllText(outputpathdemo);


                        // //Open the PDF document  
                        // doc.Open();
                        // //Add Content to PDF  
                        // doc.Add(new Paragraph(content));
                        // // Closing the document  
                        // doc.Close();
                        outputpath = output;
                    }
                    try
                    {
                        WebClient req = new WebClient();
                        HttpResponse response = HttpContext.Current.Response;
                        response.Clear();
                        response.ClearContent();
                        response.ClearHeaders();
                        response.Buffer = true;
                        response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(outputpath));
                        Response.WriteFile(outputpath);

                        Response.Flush();
                        response.End();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "<script Language=JavaScript>alert('somethig Wents Wrong!!')</Script>");

                }


            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["caseid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {

                string image = ds.Tables[0].Rows[0]["culpritImage"].ToString();

                try
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(image));
                    Response.WriteFile(image);

                    Response.Flush();
                    response.End();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}