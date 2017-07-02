using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RentalHousingWebApp.DataAccessLayer
{
    public class EndUser{

        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _lastName;

        public string Lastname
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        
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

        public EndUser(string firstname,string lastname, string userName, string password, bool isEncrypted) {
            this._firstname = firstname;
            this._lastName = lastname;
            this._userName = userName;
            this._password = password;
            this._passwordEncrypted = isEncrypted;
        }

    }

    public class UserCredentials
    {
        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
       // string path = HttpRuntime.AppDomainAppPath + "/DataAccessLayer/Database/";
        
        /// <summary>
        /// setup initial users db
        /// </summary>
        public void setupEndUserDB() { 

            //encrypted string for "password" 
            EndUser [] endUsers = new EndUser[]{
                new EndUser("test","user1","testUser1","pYyzmOe/wmh5Rpu+dwwK8Q==",true),
                new EndUser("test","user2","testUser2","pYyzmOe/wmh5Rpu+dwwK8Q==",true)
            };

            IEnumerable<XElement> xml = from endUser in endUsers
                                        select new XElement(
                                                "EndUser", new XAttribute("isPasswordEncrypted", endUser.PasswordEncrypted),
                                                new XElement("username", endUser.UserName),
                                                new XElement("password", endUser.Password),
                                                new XElement("firstname", endUser.Firstname),
                                                new XElement("lastname", endUser.Lastname)
                                            );

            //create new xml doument
            XElement xmldoc = new XElement("EndUsers", xml);

            xmldoc.Save(path + @"\EndUsers.xml");
        }

        /// <summary>
        /// read all users
        /// </summary>
        /// <returns></returns>
        public List<string> readAllEndUsers()
        {
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            var elements = from elem in xmlDoc.Elements("EndUsers").Elements("EndUser")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                result.Add(e.Element("username").Value + ";" + e.Element("password").Value);
            }
            return result;
        }

        /// <summary>
        /// Read a particular user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isEncrypted"></param>
        /// <returns></returns>
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
                    result.Add(e.Element("username").Value + ";" + e.Element("password").Value);
            }

           return result;
            
        }

        /// <summary>
        /// Read a particular user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isEncrypted"></param>
        /// <returns></returns>
        public List<string> readUserByName(string userName)
        {
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            var elements = from elem in xmlDoc.Elements("EndUsers").Elements("EndUser")
                           where elem != null
                           select elem;

            List<string> result = new List<string>();

            foreach (var e in elements)
            {
                if (e.Element("username").Value.Equals(userName))
                    result.Add(e.Element("username").Value + ";" + e.Element("password").Value);
            }

            return result;

        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isEncrypted"></param>
        /// <returns></returns>
        public bool addNewEndUser(string firstname, string lastname, string userName, string password, bool isEncrypted)
        {
            EndUser endUser = new EndUser(firstname, lastname,userName, password, isEncrypted);
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            xmlDoc.Elements("EndUsers").First().Add(
                    new XElement("EndUser", new XAttribute("isPasswordEncrypted", endUser.PasswordEncrypted),
                    new XElement("username", endUser.UserName),
                    new XElement("password", endUser.Password),
                    new XElement("firstname", endUser.Firstname),
                    new XElement("lastname", endUser.Lastname)
                    )
                );
            xmlDoc.Save(path + @"\EndUsers.xml");
            return true;
        }

        /// <summary>
        /// remove exisitng user
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isEncrypted"></param>
        /// <returns></returns>
        public bool removeEndUser(string firstname, string lastname, string userName, string password, bool isEncrypted)
        {
            EndUser endUser = new EndUser(firstname,lastname,userName, password, isEncrypted);
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

        /// <summary>
        /// remove end user by  usernames
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool removeEndUserByName(string userName)
        {
            
            XDocument xmlDoc = XDocument.Load(path + @"\EndUsers.xml");
            var elementToDelete = from elem in xmlDoc.Elements("EndUsers").Elements("EndUser")
                                  where elem != null &&
                                        elem.Element("username").Value.Equals(userName)
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