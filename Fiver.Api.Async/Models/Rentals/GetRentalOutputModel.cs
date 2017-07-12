using System;

namespace Fiver.Api.Async.Models.Rentals
{
    public class GetRentalOutputModel
    {
        public DateTime DeliveryEstimate { get; set; }
        public double RentalCost { get; set; }
    }
}
