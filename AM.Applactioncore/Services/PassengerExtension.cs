using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;

namespace AM.Applactioncore.Services
{
    public static class PassengerExtension
    {
            public static void UpperFullName(this Passenger p)
            {
                p.FirstName = p.FirstName[0].ToString().ToUpper() + p.FirstName.Substring(1);
                p.Lastname = p.Lastname[0].ToString().ToUpper() + p.Lastname.Substring(1);
            }
        }
    }

