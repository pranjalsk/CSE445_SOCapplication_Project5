using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceNearByStores" in both code and config file together.
    [ServiceContract]
    public interface IServiceNearByStores
    {
        [OperationContract]
        string findNearestStore(string zip, string storeType);

        [OperationContract]
        string getLatLong(string zip);
    }
}
