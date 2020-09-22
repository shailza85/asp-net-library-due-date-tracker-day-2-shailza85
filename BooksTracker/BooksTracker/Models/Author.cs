using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BooksTracker.Models
{
    public class Author
    {
        /* Author class:
        int “ID”
        This property should be readOnly
        string “Name”
        This property should be readOnly

         */
        private int _id;
        public int ID { get

            {
                return _id;
            }
        }

        private string _name;
        public string Name { get
            {
                return _name;
            }
        }

    }
}

//Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/tree/master/MVC_4Point1