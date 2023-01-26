using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    internal class User
    {
        [PrimaryKey]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return this.Name + "\t\t\t\t " + this.Email;
        }


    }
}
