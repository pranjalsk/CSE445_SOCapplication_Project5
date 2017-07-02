using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace SOAPServices
{
     public class ServiceCrimeData : IServiceCrimeData
    {
        public int[] getCrimeData(int zipCode)
        {

            //insert valid zip code checks

            //Zip, ViolentCrime,MurderAndManslaughter,ForcibleRape,Robbery,AggravatedAssault,PropertyCrime,Burglary,LarcenyTheft,MotorVehicleTheft  
            int[] crimeDataRateReturn = new int[10];
            WebToStringService.ServiceClient proxyWebToString = new WebToStringService.ServiceClient();

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

         /// <summary>
         /// Return latitude longitude information based on ZIP code
         /// </summary>
         /// <param name="zipCode"></param>
         /// <returns></returns>
        public string getLatitudeLongitude(int zipCode)
        {
            WebToStringService.ServiceClient proxyWebToString = new WebToStringService.ServiceClient();

            string geoDataServiceUrl = "https://azure.geodataservice.net/GeoDataService.svc/GetUSDemographics?includecrimedata=true&zipcode=" + zipCode;

            string xmlInString = proxyWebToString.GetWebContent(geoDataServiceUrl);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlInString);

            XmlNodeList latitudeNode = xmldoc.GetElementsByTagName("Latitude");
            string latitude = latitudeNode[0].InnerXml;
            XmlNodeList longitudeNode = xmldoc.GetElementsByTagName("Longitude");
            string longitude = longitudeNode[0].InnerXml;

            return (latitude + "," + longitude);
        }
  
    }
}
