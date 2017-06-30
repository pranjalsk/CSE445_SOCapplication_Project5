using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalHousingWebApp.RemoteServiceLayer
{
    public class HousingServiceAccess
    {
        ServiceReferenceHousingData.ServiceDataAccessClient housingProxy = new ServiceReferenceHousingData.ServiceDataAccessClient();

        public HousingServiceAccess() {
            housingProxy.createDB();
        }

        public List<string> readAllHouses(){
            return housingProxy.readAll().ToList();         
        }

        public List<string> readHouseByZip(int zip) {
            return housingProxy.read(zip).ToList();
        }

        public bool addNewHouse(int id, string name, int zip) {
            return housingProxy.addNew(id, name, zip);
        }

        public bool removeHouse(int id, string name, int zip) {
            return housingProxy.remove(id,name,zip);
        }
        
    }
}