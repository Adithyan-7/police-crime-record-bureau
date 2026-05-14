using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IndexGeneration
/// </summary>
/// 
namespace PoliceCrimeRecordBureau
{
    public class IndexGeneration
    {
        MatricCreation matrixes = new MatricCreation();
        cryptography crypto = new cryptography();

        public string Index_Generation(string[] keywords, string[] distinctkeyword, int keycount, string shapath)
        {

            //..........matrix creation.................

            int seed = 2;
            double[][] matrix_one = matrixes.MatrixRandom(keycount, keycount, 1.0, 9.0, seed);
            double[][] matrix_two = matrixes.MatrixRandom(keycount, keycount, 1.0, 9.0, seed);

            //.......secret key creation..............

            string vectorkey = vector_key(keycount);

            //................document vector generation.........
            List<int> Doc_vector = document_vecotr(keywords, distinctkeyword, keycount);

            //.............now spliting document vector....................

            List<double> split_vector1 = new List<double>();
            List<double> split_vector2 = new List<double>();

            for (int i = 0; i < vectorkey.Length; i++)
            {
                if (vectorkey[i].ToString() == "1")
                {
                    Random randGenerator = new Random();
                    int randNumber = randGenerator.Next(1, 10);

                    if (Doc_vector[i].ToString() == "0")
                    {
                        split_vector1.Add(double.Parse(randNumber.ToString()));
                        split_vector2.Add(-(double.Parse(randNumber.ToString())));
                    }
                    else
                    {
                        double sum = randNumber - double.Parse(Doc_vector[i].ToString());
                        split_vector1.Add(randNumber);
                        split_vector2.Add(-(sum));
                    }
                }
                else
                {
                    split_vector1.Add(double.Parse(Doc_vector[i].ToString()));
                    split_vector2.Add(double.Parse(Doc_vector[i].ToString()));
                }
            }

            //...........Mtatric Generation.............
            double[,] Matrix_One_Traspose = TransposeMatrix(keycount);
            double[,] Matrix_two_Traspose = TransposeMatrix(keycount);

            //.........Matrix Multiplication or document encryption steps...........

            double[,] split1_encryption = Split_Encryption(split_vector1, Matrix_One_Traspose, keycount);
            double[,] split2_encryption = Split_Encryption(split_vector2, Matrix_two_Traspose, keycount);

            //.........now joining two split encryption results.......

            string encrypted_document_vector = "";
            foreach (double dd in split1_encryption)
            {
                encrypted_document_vector = encrypted_document_vector + dd.ToString() + ",";
            }
            foreach (double dd in split2_encryption)
            {
                encrypted_document_vector = encrypted_document_vector + dd.ToString() + ",";
            }

            //.......hash generation of keywords...........

            bloomhash(keywords, shapath);

            return encrypted_document_vector;
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

        //........document generation code.............
        public List<int> document_vecotr(string[] keywords, string[] distinctkeyword, int keycount)
        {
            List<int> documentvector = new List<int>();

            foreach (string onekey in distinctkeyword)
            {
                int cnt = 0;
                foreach (string keyone in keywords)
                {
                    if (keyone == onekey)
                    {
                        cnt++;
                    }
                }
                documentvector.Add(cnt);
            }



            return documentvector;
        }



        //............matrix generation step.........

        public double[,] TransposeMatrix(int keycount)
        {
            int seed = 2;
            double[][] Matrix = matrixes.MatrixRandom(keycount, keycount, 1.0, 9.0, seed);
            //..............creating transpose of matrix .............

            double[,] matrix_two_transpose = new double[keycount, keycount];

            for (int i = 0; i < keycount; i++)
            {
                for (int j = 0; j < keycount; j++)
                {
                    matrix_two_transpose[i, j] = Matrix[j][i];

                }
            }

            return matrix_two_transpose;
        }

        //.............Matrix Multiplicaiton document encryption steps............

        public double[,] Split_Encryption(List<double> splitvector, double[,] matrixTraspose, int limit)
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

                        result_cluster_split[j, i] += Math. Round(matrixTraspose[i, kd] * cluster1_split1[kd, j], 3);
                    }
                }
            }

            return result_cluster_split;
        }

        public void bloomhash(string[] keywords, string shapath)
        {
            using (StreamWriter sw = File.CreateText(shapath))
            {

                for (int i = 0; i < keywords.Count(); i++)
                {
                    string hashvalue = crypto.createhash_of_string(keywords[i].ToString().ToLower());
                    sw.WriteLine(hashvalue);

                }

            }
        }
    }
}