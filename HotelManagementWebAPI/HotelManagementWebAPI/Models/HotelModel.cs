using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementWebAPI.Models
{
    public class HotelModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfAvailableRooms { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }

    }
}