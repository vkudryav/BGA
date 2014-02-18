using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bellicose.GoogleAnalytics.Interfaces;
using Google.Apis.Analytics.v3.Data;

namespace Bellicose.GoogleAnalytics.Concrete
{
    //Serializes GaData to Tab Separated Value file
    public class GaDataTsvSerializer: IGaDataSerializer
    {
        private string _filePath;

        public GaDataTsvSerializer(string filePath)
        {
            _filePath = filePath;
        }

        public void Serialize(GaData gaData)
        {
            using (var s = new StreamWriter(_filePath))
            {
                int i = 0;
                foreach (var h in gaData.ColumnHeaders)
                {
                    if (i++ > 0)
                        s.Write("\t");
                    s.Write(h.Name);
                }
                s.WriteLine();

                foreach (var row in gaData.Rows)
                {
                    for (int col = 0; col < row.Count; col++)
                    {
                        if (col > 0)
                            s.Write("\t");
                        s.Write(row[col]);
                    }
                    s.WriteLine();
                }
                s.Flush();
                s.Close();
            }
        }
    }
}
