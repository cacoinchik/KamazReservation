﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class ParkingViewModels
    {
        public IEnumerable<ParkingSpace> parkingSpaces { get; set; }
        public IEnumerable<Booking> bookings { get; set; }
    }
}