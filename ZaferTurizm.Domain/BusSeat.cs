using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class BusSeat
    {
        public BusSeat(int seatNumber, bool isFull, Gender gender)
        {
            this.seatNumber = seatNumber;
            this.isFull = isFull;
            Gender = gender;
        }

        public int seatNumber  { get; set; }
        public bool isFull { get; set; }
         public Gender Gender { get; set; }
    }
}
