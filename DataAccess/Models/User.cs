using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Password { get; set; }
        public string Phone_number { get; set; }
        public string Gmail { get; set; }
        public string NormalizedGmail { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        public User() {  }

        public User(int id, string name, string password, string phone_number, string gmail, string address, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Phone_number = phone_number;
            this.Gmail = gmail;
            this.Address = address;
            this.Status = status;
        }

    }
}
