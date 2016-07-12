using System;

namespace Azure_Demo_2.ViewModels
{
    public class ContactModel
    {
        public ContactModel()
        {
        }
        private string name;
        public string  Name
        {
            get { return name;}
            set { name = value;}
        }

        private int age;
        public int Age
        {
            get { return age;}
            set { age = value;}
        }

        private DateTime dob;
        public DateTime Dob
        {
            get { return dob;}
            set { dob = value;}
        }
    }
}
