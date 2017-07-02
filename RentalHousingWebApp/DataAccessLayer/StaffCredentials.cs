using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RentalHousingWebApp.DataAccessLayer
{
    public class StaffMember {

        private string _staffRole;

        public string StaffRole
        {
            get { return _staffRole; }
            set { _staffRole = value; }
        }

        private string _staffUserName;

        public string StaffUserName
        {
            get { return _staffUserName; }
            set { _staffUserName = value; }
        }

        private string _staffPassword;

        public string StaffPassword
        {
            get { return _staffPassword; }
            set { _staffPassword = value; }
        }

        public StaffMember() { }

        public StaffMember(string staffUserName, string staffPassword, string staffRole) {
            this._staffUserName = staffUserName;
            this._staffPassword = staffPassword;
            this._staffRole = staffRole;
        }  
    }
    
    public class StaffCredentials
    {
       // String staffXmlpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string staffXmlpath = HttpRuntime.AppDomainAppPath + "/DataAccessLayer/Database/";

        public void setupStaffDB()
        {
            StaffMember[] staffMembers = new StaffMember[]{
                new StaffMember("managerTest1","password","manager"),
                new StaffMember("managerTest2","password","manager"),
                new StaffMember("clerkTest1","password","clerk"),
                new StaffMember("clerkTest2","password","clerk"),
                new StaffMember("clerkTest3","password","clerk")
            };

            IEnumerable<XElement> xml = from staffMember in staffMembers
                                        select new XElement(
                                                "StaffMember", new XAttribute("role", staffMember.StaffRole),
                                                new XElement("username", staffMember.StaffUserName),
                                                new XElement("password", staffMember.StaffPassword)
                                            );

            //create new xml doument
            XElement xmldoc = new XElement("StaffMembers", xml);

            xmldoc.Save(staffXmlpath + @"\StaffMembers.xml");
        }

        public List<string> readAllStaffMembers()
        {
            XDocument xmlDoc = XDocument.Load(staffXmlpath + @"\StaffMembers.xml");
            var elements = from elem in xmlDoc.Elements("StaffMembers").Elements("StaffMember")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                result.Add(e.Attribute("role").Value + ";" + e.Element("username").Value + ";" + e.Element("password").Value);
            }
            return result;
        }

        public List<string> readStaffMember(string userName, string password)
        {
            XDocument xmlDoc = XDocument.Load(staffXmlpath + @"\StaffMembers.xml");
            var elements = from elem in xmlDoc.Elements("StaffMembers").Elements("StaffMember")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                if (e.Element("username").Value.Equals(userName) && e.Element("password").Value.Equals(password))
                    result.Add(e.Attribute("role").Value + ";" + e.Element("username").Value + ";" + e.Element("password").Value);
            }
            return result;
        }

        public bool removeStaffMember(string userName, string password, string role)
        {
            StaffMember stfmem = new StaffMember(userName, password, role);
            XDocument xmlDoc = XDocument.Load(staffXmlpath + @"\StaffMembers.xml");
            var elementToDelete = from elem in xmlDoc.Elements("StaffMembers").Elements("StaffMember")
                                  where elem != null &&
                                        elem.Element("username").Value.Equals(stfmem.StaffUserName) &&
                                        elem.Element("password").Value.Equals(stfmem.StaffPassword) &&
                                        elem.Element("role").Value.Equals(stfmem.StaffRole)
                                  select elem;

            foreach (var e in elementToDelete)
            {
                e.Remove();
            }
            xmlDoc.Save(staffXmlpath + @"\StaffMembers.xml");
            return true;
        }

    }
}