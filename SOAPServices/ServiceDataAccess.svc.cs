using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace SOAPServices
{
    public class ServiceDataAccess : IServiceDataAccess
    {
        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Setup inital db with dummy values
        /// </summary>
        public void createDB()
        {      
            // initial db setup
            House[] houses = new House[]{
                new House(1,"Palm Ville",85281),
                new House(2,"University Ville",85281),
                new House(3,"Casa Ville",85281),
                new House(4,"Avion Ville",85009),
                new House(5,"Triangle Ville",85009),
                new House(6,"Xia Ville",85281),
                new House(7,"Sham Ville",85281),
                new House(8,"Pointe Ville",94137),
                new House(9,"Vertex Ville",85281),
                new House(10,"Horizon Ville",35281),
                new House(11,"Charm Ville",35281),
                new House(12,"Piece Ville",35281),
                new House(13,"Sanioni Ville",35281),
                new House(14,"Saloni Ville",35281),
                new House(15,"Margaratha Ville",35281),
                new House(16,"Avenue Ville",85281),
                new House(17,"DeltaStreet Ville",85281),
                new House(18,"AvenueRoad Ville",94137),
                new House(19,"Bioni Ville",94137),
                new House(20,"Horizon Ville",94137),
                new House(21,"Carlson Ville",94137),
                new House(22,"Prince Ville",94137),
                new House(23,"Hamilton Ville",94016),
                new House(24,"Hamerita Ville",94016),
                new House(25,"Calmata Ville",94016),
                new House(26,"Siper Ville",90033),
                new House(27,"HyperStreet Ville",90033),
                new House(28,"PonyStreet Ville",90033),
                new House(29,"Toni Ville",90033),
            };

            IEnumerable<XElement> xml = from house in houses
                                        select new XElement(
                                                "House", new XAttribute("id", house.ID),
                                                new XElement("name", house.Name),
                                                new XElement("zip", house.ZIP)
                                            );

            //create new xml doument
            XElement xmldoc = new XElement("Houses", xml);

            xmldoc.Save(path + @"\Houses.xml");

        }

        /// <summary>
        /// Read the values from DB filtered on ZIP code
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        public List<string> read(int zip)
        {
            XDocument xmlDoc = XDocument.Load(path + @"\Houses.xml");
            var elements = from elem in xmlDoc.Elements("Houses").Elements("House")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                if (e.Element("zip").Value.Equals(zip.ToString()))
                    result.Add(e.Attribute("id").Value + ";" + e.Element("name").Value + ";" + e.Element("zip").Value);
            }
            return result;
        }

        /// <summary>
        /// Read all the values from DB 
        /// </summary>
        /// <returns></returns>
        public List<string> readAll()
        {
            XDocument xmlDoc = XDocument.Load(path + @"\Houses.xml");
            var elements = from elem in xmlDoc.Elements("Houses").Elements("House")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                result.Add(e.Attribute("id").Value + ";" + e.Element("name").Value + ";" + e.Element("zip").Value);
            }
            return result;
        }

        /// <summary>
        /// Add new entry in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        public bool addNew(int id, string name, int zip)
        {
            House house = new House(id, name, zip);
            XDocument xmlDoc = XDocument.Load(path + @"\Houses.xml");
            xmlDoc.Elements("Houses").First().Add(
                    new XElement("House", new XAttribute("id", house.ID),
                    new XElement("name", house.Name),
                    new XElement("zip", house.ZIP)
                    )
                );
            xmlDoc.Save(path + @"\Houses.xml");
            return true;
        }

        /// <summary>
        /// Remove the entry from the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        public bool remove(int id, string name, int zip)
        {
            House house = new House(id, name, zip);
            XDocument xmlDoc = XDocument.Load(path + @"\Houses.xml");
            var elementToDelete = from elem in xmlDoc.Elements("Houses").Elements("House")
                                  where elem != null &&
                                        elem.Attribute("id").Value.Equals(house.ID.ToString()) &&
                                        elem.Element("zip").Value.Equals(house.ZIP.ToString())
                                  select elem;

            foreach (var e in elementToDelete)
            {
                e.Remove();
            }
            xmlDoc.Save(path + @"\Houses.xml");
            return true;
        }
    }
}
