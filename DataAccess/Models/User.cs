using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; }
        public string gmail { get; set; }
        public string address { get; set; }

        public User() {  }

        public User(int id, string name, string password, string phone_number, string gmail, string address)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.phone_number = phone_number;
            this.gmail = gmail;
            this.address = address;
        }

    }
}
