using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TranpdoorGenerator
/// </summary>
/// 
namespace PoliceCrimeRecordBureau
{
    public class TranpdoorGenerator
    {
        MatricCreation matrixes = new MatricCreation();
        //DataConnectivity_With_LinqDataContext db = new DataConnectivity_With_LinqDataContext();


        public Dictionary<string, double> GenerateTrampdoor(string Keyword, string[] keywordset, string username)
        {
            Dictionary<string, double> SearchResult = new Dictionary<string, double>();
            //......Spliting Keywords...
            List<int> keywordvector = new List<int>();

            string[] keywords = Keyword.Split(' ');
            int keycount = 0;
            foreach (string onekey in keywords)
            {
                if (keywordset.Contains(onekey, StringComparer.OrdinalIgnoreCase))
                {
                    keywordvector.Add(1);
                    keycount++;
                }
                else
                {
                    keywordvector.Add(0);
                }
            }

            //........checking keyword present in keyword set........

            if (keycount != 0)
            {
                //..........creating split search vector.................

                string splitkey = vector_key(keywordvector.Count);
                List<double> search_splitvector1 = new List<double>();
                List<double> search_splitvector2 = new List<double>();

                for (int j = 0; j < keywordvector.Count; j++)
                {
                    //......spliting search vectors.....

                    if (splitkey[j].ToString() == "0")
                    {
                        Random randGenerator = new Random();
                        int randNumber = randGenerator.Next(1, 10);

                        if (keywordvector[j].ToString() == "0")
                        {
                            search_splitvector1.Add(double.Parse(randNumber.ToString()));
                            search_splitvector2.Add(-(double.Parse(randNumber.ToString())));
                        }
                        else
                        {
                            double sum = randNumber - double.Parse(keywordvector[j].ToString());
                            search_splitvector1.Add(randNumber);
                            search_splitvector2.Add(-(sum));
                        }
                    }
                    else
                    {
                        search_splitvector1.Add(double.Parse(keywordvector[j].ToString()));
                        search_splitvector2.Add(double.Parse(keywordvector[j].ToString()));
                    }
                }

                //........Generating two inverse matrix..........
                int seed = 2;
                double[][] matrix_one = matrixes.MatrixRandom(keycount, keycount, 1.0, 9.0, seed);
                double[][] matrix_two = matrixes.MatrixRandom(keycount, keycount, 1.0, 9.0, seed);
                double[][] Matrix_One_Inverse = matrixes.MatrixInverse(matrix_one);
                double[][] Matrix_Two_Inverse = matrixes.MatrixInverse(matrix_two);

                //......Encrypting Search split vectors.................

                double[,] split1_encryption = Split_Encryption(search_splitvector1, Matrix_One_Inverse, keywordvector.Count);
                double[,] split2_encryption = Split_Encryption(search_splitvector2, Matrix_Two_Inverse, keywordvector.Count);


                //.........now joining two split encryption results.......

                string encrypted_SearchQuery_vector = "";
                foreach (double dd in split1_encryption)
                {
                    encrypted_SearchQuery_vector = encrypted_SearchQuery_vector + dd.ToString() + ",";
                }
                foreach (double dd in split2_encryption)
                {
                    encrypted_SearchQuery_vector = encrypted_SearchQuery_vector + dd.ToString() + ",";
                }


                //...........searching using Dot Product............
                SearchResult = DotProduct(encrypted_SearchQuery_vector, username);

            }
            return SearchResult;
        }

        //.............Secret Key vector creation...................
        public string vector_key(int pl)
        {
            {
                string possibles = "01";
                char[] passwords = new char[pl];
                Random rd = new Random();
                for (int i = 0; i < pl; i++)
                {
                    passwords[i] = possibles[rd.Next(0, possibles.Length)];

                }
                return new string(passwords);
            }
        }

        //.............Matrix Multiplicaiton document encryption steps............

        public double[,] Split_Encryption(List<double> splitvector, double[][] MatrixInverse, int limit)
        {
            //..........arrange   split vector....

            double[,] cluster1_split1 = new double[limit, 1];
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    cluster1_split1[i, j] = splitvector[i];
                }
            }

            //........Matrix Multiplication................

            double[,] result_cluster_split = new double[1, limit];

            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result_cluster_split[j, i] = 0;
                    for (int kd = 0; kd < limit; kd++)
                    {

                        result_cluster_split[j, i] += Math.Round(MatrixInverse[i][kd] * cluster1_split1[kd, j], 3);
                    }
                }
            }

            return result_cluster_split;
        }


        public Dictionary<string, double> DotProduct(string EncryptedQuery, string username)
        {

            Dictionary<string, double> searchResult = new Dictionary<string, double>();
            DbConnect db = new DbConnect();
            DataTable ds = new DataTable();
            string stcode = db.extscalr("select [stationCode] from [PoliceStation] where Username='" + username + "'");
            ds = db.discont3("select * from File_Info where p_code='" + stcode + "'");
            //var documentvectorresult = db.File_Infos.Where(x => x.owner != username);
            foreach (DataRow oneresult in ds.Rows)
            {
                string Fname = oneresult["fname"].ToString();
                List<string> StrDocVector = (oneresult["indexValue"].ToString()).Split(',').ToList();
                StrDocVector.Remove("");
                List<double> Documentvector = new List<double>();
                foreach (string onedoc in StrDocVector)
                {
                    Documentvector.Add(double.Parse(onedoc));
                }

                List<string> strsearchvector = EncryptedQuery.Split(',').ToList();
                strsearchvector.Remove("");
                List<double> DoubleSearchVector = new List<double>();
                foreach (string onbind in strsearchvector)
                {
                    DoubleSearchVector.Add(double.Parse(onbind));
                }

                int tcount = DoubleSearchVector.Count;
                int dcount = Documentvector.Count();
                int diff = dcount - tcount;
                for (int i = 0; i < diff; i++)
                {
                    DoubleSearchVector.Add(0.0);
                }

                //..............now generating document vector................
                double rank = 0.0;
                for (int l = 0; l < DoubleSearchVector.Count; l++)
                {
                    rank += DoubleSearchVector[l] * Documentvector[l];
                }
                searchResult.Add(Fname, rank);
            }

            return searchResult;
        }


    }
}