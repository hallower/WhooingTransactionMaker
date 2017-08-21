using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.Models
{
    public class Transaction
    {
        public DateTime Time { get; set; }
        public Double Price { get; set; }
        public String Desc { get; set; }
        public String Left { get; set; }
        public String Right { get; set; }
        
    }
}