using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Analytics.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellicose.GoogleAnalytics.Interfaces
{
    public interface IGaDataSerializer
    {
        void Serialize(GaData gaData);
    }
}
