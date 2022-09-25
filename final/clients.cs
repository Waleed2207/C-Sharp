using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasses_project
{
    class clients
    {
        private string firstname;
        private string lastname;
        private string id;
        private int age;
        private string phone;
        private bool isqsm;
        private string date;
        private string glasstype;

        public clients(string firstname, string lastname, string id, string phone, int age, string date)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.id = id;
            this.age = age;
            this.phone = phone;
            this.date = date;

        }


        public string getfirstname()
        {
            return this.firstname;
        }
        public string getlastname()
        {
            return this.lastname;
        }
        public string getid()
        {
            return this.id;
        }
        public int getage()
        {
            return this.age;
        }
        public string getPhone()
        {
            return this.phone;
        }

        public string getdate()
        {
            return this.date;
        }


        public void Setfirstname(string firstname)
        {
            this.firstname = firstname;

        }
        public void Setlastname(string lastname)
        {
            this.lastname = lastname;

        }
        public void Setid(string id)
        {
            this.id = id;
        }
        public void Setage(int age)
        {
            this.age = age;
        }

        public void Setdate(string date)
        {
            this.date = date;
        }

    }
}
