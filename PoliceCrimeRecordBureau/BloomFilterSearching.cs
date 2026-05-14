using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BloomFilterSearching
/// </summary>
namespace PoliceCrimeRecordBureau
{
    public class BloomFilterSearching
    {
        public int bloomSearch(List<string> DocumentHash, List<string> keyword)
        {
            var docCount = DocumentHash;
            var resultdocu = docCount.GroupBy(i => i);
            int keycount = 0;
            foreach (string onekey in keyword)
            {
                foreach (var oneresult in resultdocu)
                {
                    if (oneresult.Key == onekey)
                    {
                        keycount = keycount + oneresult.Count();
                    }
                }
            }
            return keycount;
        }
    }
}