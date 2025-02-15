using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        public DateTime BrithDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> flights { get; set; }

        public override string? ToString()
        {
            return "Date" + BrithDate;
        }


    //question10-a
    public bool CheckProfile1(string firstName, string lastName)
        {
            return FirstName == firstName && Lastname == lastName;
        }
        //question10-b
        public bool CheckProfile2(string firstName, string lastName, string email) {
            return FirstName == firstName && Lastname == lastName && EmailAddress == email;
        }
        //question10-c

         public bool CheckProfile3(string firstName, string lastName, string email = null)

         {   if(email != null) 
             return FirstName == firstName && Lastname == lastName && EmailAddress == email;
         else
                 return FirstName == firstName && Lastname == lastName;

         }


        //question11
        public virtual void PassengerType()
        {
            Console.WriteLine("i am a passenger");
        }
    }
}
