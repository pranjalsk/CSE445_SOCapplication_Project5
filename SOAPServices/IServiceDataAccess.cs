using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPServices
{
     [ServiceContract]
    public interface IServiceDataAccess
    {
        [OperationContract]
        List<string> read(int zip);

        [OperationContract]
        List<string> readAll();

        [OperationContract]
        void createDB();

        [OperationContract]
        bool addNew(int id, string name, int zip);

        [OperationContract]
        bool remove(int id, string name, int zip);
    }
}
