namespace Fiver.Api.Async.Models.Rentals
{
    public class RequestRentalInputModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public int Days { get; set; }
    }
}
