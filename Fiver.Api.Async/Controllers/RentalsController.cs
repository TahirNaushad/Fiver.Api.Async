using Fiver.Api.Async.Lib;
using Fiver.Api.Async.Models.Rentals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fiver.Api.Async.Controllers
{
    [Route("")]
    public class RentalsController : BaseController
    {
        [HttpPost("request-rental", Name = "RequestRental")]
        public IActionResult RequestRental([FromBody]RequestRentalInputModel inputModel)
        {
            var queueNo = "q-2";
            return AcceptedAtRoute("CheckStatus", new { queueNo = queueNo });
        }

        [HttpGet("check-status/{queueNo}", Name = "CheckStatus")]
        public IActionResult CheckStatus(string queueNo)
        {
            if (queueNo == "q-2") // pending
            {
                return Ok(new CheckStatusOutputModel
                {
                    Status = "Pending"
                });
            }
            else // complete
            {
                var refNo = "r-1";
                return SeeOther("GetRental", new { refNo = refNo });
            }
        }

        [HttpGet("get-rental/{refNo}", Name = "GetRental")]
        public IActionResult GetRental(string refNo)
        {
            if (refNo == "r-1")
            {
                return Ok(new GetRentalOutputModel
                {
                    DeliveryEstimate = DateTime.Now.AddDays(2),
                    RentalCost = 5.99
                });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
