using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.PoliceStation
{
    public partial class SearchFile : System.Web.UI.Page
    {
        cryptography crypto = new cryptography();
        TranpdoorGenerator tranp = new TranpdoorGenerator();
        BloomFilterSearching bloom = new BloomFilterSearching();
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                username.Value = Session["user"].ToString();
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetKeywordSuggestions(string prefix)
        {

            // Read all keywords from a text file
            string[] keywords = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/PoliceStation/Documents/dataset/keywords.txt"));

            // Filter keywords that start with the input prefix
            return keywords.Where(k => k.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                //..........Tranpdoor Generation Searching...............
                string datasetpath = Server.MapPath("~/PoliceStation/Documents/dataset/keywords.txt");
                string[] keywordset = File.ReadAllLines(datasetpath);
                Dictionary<string, double> SearchResult = tranp.GenerateTrampdoor(TextBox1.Text, keywordset, username.Value);

                //...........BloomFilter Searching....................

                db.extnon("truncate table SearchResult");

                string[] keys = TextBox1.Text.Split(' ');
                List<string> keywordhash = new List<string>();
                foreach (string onekey in keys)
                {
                    keywordhash.Add(crypto.createhash_of_string(onekey.ToLower()));
                }

                foreach (KeyValuePair<string, double> OneResult in SearchResult)
                {
                    string hashpath = Server.MapPath("~/PoliceStation/Documents/sha1/" + OneResult.Key + ".txt");
                    List<string> DocumentKeywordHash = File.ReadAllLines(hashpath).ToList();
                    int Keycount = bloom.bloomSearch(DocumentKeywordHash, keywordhash);
                    if (Keycount != 0)
                    {
                        ds = db.discont1("select * from File_Info where fname='" + OneResult.Key + "'");
                        // var qry = db.File_Infos.FirstOrDefault(x => x.fname == OneResult.Key);
                        //SearchResult Sr = new global::SearchResult();
                        //Sr.searchfileid = qry.fid;
                        //Sr.rank = OneResult.Value;
                        //Sr.tcount = Keycount;
                        //db.SearchResults.InsertOnSubmit(Sr);
                        //db.SubmitChanges();
                        db.extnon("insert into SearchResult values('" + ds.Tables[0].Rows[0]["fid"].ToString() + "','" + Keycount + "','" + OneResult.Value + "')");
                    }
                }


                //......showing result..........
                ds.Clear();
                ds = db.discont("select * from SearchResultDetails order by rank desc");
                //  var searchingresult = db.SearchResultDetails(username.Value).OrderByDescending(x => x.tcount).ThenByDescending(x => x.rank); 
                //....searchresultdetails is the name of the stored procedure
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
            }
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["fid"] = GridView1.Rows[e.RowIndex].Cells[0].Text;
            load_CaseFile();
            MultiView1.ActiveViewIndex = 1;
        }
        public void load_CaseFile()
        {
            ds = db.discont("select * from File_Info where fid='" + Session["fid"] + "'");
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
            Response.Redirect("SearchFile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            ds = db.discont("select * from File_Info where fid='" + Session["fid"] + "'");
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["fid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string fname = ds.Tables[0].Rows[0]["fname"].ToString();
                string ekey = ds.Tables[0].Rows[0]["ekey"].ToString();


                string inputpath = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + fname + ".txt");
                string outputpath = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ".txt");
                try
                {

                    string name1 = fname + ".txt";
                    string s3FileName1 = @name1;
                //    AmazoneCloud am = new AmazoneCloud();
               //     am.DownloadFromCloud(inputpath, s3FileName1);
                    crypto.MultimediaDecrypt(inputpath, outputpath, ekey);

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
                    ClientScript.RegisterStartupScript(GetType(), "", "<script Language=JavaScript>alert('something Wents Wrong!!')</Script>");

                }


            }
        }
    }
}