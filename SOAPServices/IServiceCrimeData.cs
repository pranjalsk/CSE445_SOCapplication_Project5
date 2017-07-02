using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPServices
{
     [ServiceContract]
    public interface IServiceCrimeData
    {
        [OperationContract]
        int[] getCrimeData(int zipCode);

        [OperationContract]
        int getCrimeIndex(int zipCode);

        [OperationContract]
        string getLatitudeLongitude(int zipCode);
       
    }
}
