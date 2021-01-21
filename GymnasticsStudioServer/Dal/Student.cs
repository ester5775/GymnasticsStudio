using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Student
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string IdentityNumber;
        public string PhoneNumber;
        public string MobilePhoneNumber;
        public int Balance=87;


        public Student()
        { }

        public Student(int id ,string firstName ,string lastName ,string identityNumber,string phoneNumber,string mobilePhoneNumber,int balance)
       {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IdentityNumber = identityNumber;
            this.PhoneNumber = phoneNumber;
            this.MobilePhoneNumber = mobilePhoneNumber;
            this.Balance = balance;
        }
    }



}
