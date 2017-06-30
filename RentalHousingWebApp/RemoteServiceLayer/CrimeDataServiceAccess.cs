using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace RentalHousingWebApp.RemoteServiceLayer
{
    public class CrimeDataServiceAccess
    {
        /// <summary>
        /// Gives crime data in the area using zip code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public int[] getCrimeData(int zipCode)
        {
            //Zip, ViolentCrime,MurderAndManslaughter,ForcibleRape,Robbery,AggravatedAssault,PropertyCrime,Burglary,LarcenyTheft,MotorVehicleTheft  
            int[] crimeDataRateReturn = new int[10];
            ServiceReferenceWebToString.ServiceClient proxyWebToString = new ServiceReferenceWebToString.ServiceClient();

            string geoDataServiceUrl = "https://azure.geodataservice.net/GeoDataService.svc/GetUSDemographics?includecrimedata=true&zipcode=" + zipCode;

            string xmlInString = proxyWebToString.GetWebContent(geoDataServiceUrl);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlInString);

            List<XmlNodeList> elemList = new List<XmlNodeList>();
            elemList.Add(xmldoc.GetElementsByTagName("ZipCode"));
            elemList.Add(xmldoc.GetElementsByTagName("ViolentCrime"));
            elemList.Add(xmldoc.GetElementsByTagName("MurderAndManslaughter"));
            elemList.Add(xmldoc.GetElementsByTagName("ForcibleRape"));
            elemList.Add(xmldoc.GetElementsByTagName("Robbery"));
            elemList.Add(xmldoc.GetElementsByTagName("AggravatedAssault"));
            elemList.Add(xmldoc.GetElementsByTagName("PropertyCrime"));
            elemList.Add(xmldoc.GetElementsByTagName("Burglary"));
            elemList.Add(xmldoc.GetElementsByTagName("LarcenyTheft"));
            elemList.Add(xmldoc.GetElementsByTagName("MotorVehicleTheft"));

            for (int i = 0; i < crimeDataRateReturn.Length; i++)
            {
                crimeDataRateReturn[i] = Convert.ToInt32(elemList[i][0].InnerText);
            }
            return crimeDataRateReturn;
        }

        public int getCrimeIndex(int zipCode)
        {
            //implement weighted avaerage logic
            return 0;

        }


    }
}