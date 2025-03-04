using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Key]
        [StringLength(7)]
        public int PassportNumber { get; set; }

        [MinLength(3,ErrorMessage = "FirstName must be at least 3 characters long.")]
        [MaxLength(25, ErrorMessage = "FirstName cannot exceed 25 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BrithDate { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [RegularExpression("^[0,9]{8}$")]
        public int TelNumber { get; set; }
        public string Lastname { get; set; }
       
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
