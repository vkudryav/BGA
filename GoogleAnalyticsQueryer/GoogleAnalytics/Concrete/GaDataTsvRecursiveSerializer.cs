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
    //In addition to exporting each column, it breaks makes multiple rows if a column has multiple comma-separated values
    public class GaDataTsvRecursiveSerializer: IGaDataSerializer
    {
        private string _filePath;

        public GaDataTsvRecursiveSerializer(string filePath)
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

	            if (gaData.Rows != null)
	            {
		            foreach (var columnArray in gaData.Rows)
		            {
			            SerializeRemainderOfRow(s, new StringBuilder(), columnArray, 0);
		            }
	            }
	            s.Flush();
                s.Close();
            }
        }

        private void SerializeRemainderOfRow(StreamWriter streamWriter, StringBuilder partialOutput, IList<string> columnArray, int startingColumn)
        {
            string toSerialize = columnArray[startingColumn];

            //process a separate instance of this output row for each comma-separated token.
            foreach (string token in toSerialize.Split(','))
            {
                var output = new StringBuilder(partialOutput.ToString());
                if (startingColumn > 0)
                    output.Append("\t");
                output.Append(token);

                if (startingColumn < columnArray.Count - 1)
                {
                    SerializeRemainderOfRow(streamWriter, new StringBuilder(output.ToString()), columnArray, startingColumn + 1);
                }
                else
                {
                    streamWriter.WriteLine(output);
                }
            }
        }
    }
}
