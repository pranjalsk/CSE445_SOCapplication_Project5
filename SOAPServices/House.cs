using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPServices
{
    public class House
    {
        public House() { }

        public House(int id, string name, int zip)
        {
            this._uId = id;
            this._name = name;
            this._zip = zip;
        }


        private int _uId;

        public int ID
        {
            get { return _uId; }
            set { _uId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _zip;

        public int ZIP
        {
            get { return _zip; }
            set { _zip = value; }
        }
        
    }
}