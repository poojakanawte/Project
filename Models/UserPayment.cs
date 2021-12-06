using System;
using System.Collections.Generic;

#nullable disable

namespace BookDatabaseApi.Models
{
    public partial class UserPayment
    {
        public string CardHname { get; set; }
        public int Cvv { get; set; }
        public string CardNumber { get; set; }
    }
}
