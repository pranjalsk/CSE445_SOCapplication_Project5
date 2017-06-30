using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RentalHousingWebApp.DataAccessLayer
{
    public class EndUser{

        private bool _passwordEncrypted;

        public bool PasswordEncrypted
        {
            get { return _passwordEncrypted; }
            set { _passwordEncrypted = value; }
        }
        
        private string _userName;

	    public string UserName
	    {
		get { return _userName;}
		set { _userName = value;}
	    }

        private string _password;

	    public string Password
	    {
		get { return _password;}
		set { _password = value;}
	    }

        public EndUser() { }

        public EndUser(string userName, string password, bool isEncrypted) {
            this._userName = userName;
            this._password = password;
            this._passwordEncrypted = isEncrypted;
        }

    }

    public class UserCredentials
    {
        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        /*
         * create user object...create xml file...crud operations
         */
        public void setupEndUserDB() { 
            EndUser [] endUsers = new EndUser[]{
                new EndUser("testUser1","password",false),
                new EndUser("testUser2","password",false)
            };

            IEnumerable<XElement> xml = from endUser in endUsers
                                        select new XElement(
                                                "EndUser", new XAttribute("isPasswordEncrypted", endUser.PasswordEncrypted),
                                                new XElement("username", endUser.UserName),
                                                new XElement("password", endUser.Password)
                                            );

            //create new xml doument
            XElement xmldoc = new XElement("EndUsers", xml);

            xmldoc.Save(path + @"\EndUsers.xml");
        }

        public List<string> readAllEndUsers()
        {
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            var elements = from elem in xmlDoc.Elements("EndUsers").Elements("EndUser")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                result.Add(e.Attribute("isPasswordEncrypted").Value + ";" + e.Element("username").Value + ";" + e.Element("password").Value);
            }
            return result;
        }

        public List<string> readUser(string userName, string password, bool isEncrypted)
        {
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            var elements = from elem in xmlDoc.Elements("EndUsers").Elements("EndUser")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                if (e.Element("username").Value.Equals(userName) && e.Element("password").Value.Equals(password))
                    result.Add(e.Attribute("isPasswordEncrypted").Value + ";" + e.Element("username").Value + ";" + e.Element("password").Value);
            }

           return result;
            
        }



        public bool addNewEndUser(string userName, string password, bool isEncrypted)
        {
            EndUser endUser = new EndUser(userName, password, isEncrypted);
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            xmlDoc.Elements("EndUsers").First().Add(
                    new XElement("EndUser", new XAttribute("isPasswordEncrypted", endUser.PasswordEncrypted),
                    new XElement("username", endUser.UserName),
                    new XElement("password", endUser.Password)
                    )
                );
            xmlDoc.Save(path + @"\EndUsers.xml");
            return true;
        }

        public bool removeEndUser(string userName, string password, bool isEncrypted)
        {
            EndUser endUser = new EndUser(userName, password, isEncrypted);
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            var elementToDelete = from elem in xmlDoc.Elements("EndUsers").Elements("EndUser")
                                  where elem != null &&
                                        elem.Element("username").Value.Equals(endUser.UserName)&&
                                        elem.Element("password").Value.Equals(endUser.Password)
                                  select elem;

            foreach (var e in elementToDelete)
            {
                e.Remove();
            }
            xmlDoc.Save(path + @"\EndUsers.xml");
            return true;
        }


    }
}