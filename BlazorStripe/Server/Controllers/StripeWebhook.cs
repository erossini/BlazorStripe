using BlazorStripe.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace BlazorStripe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebhook : ControllerBase
    {
        private readonly string _webhookSecret;

        public StripeWebhook(StripeOptions options)
        {
            _webhookSecret = options?.WebhookSigningKey;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            string json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            //try
            //{
                var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], _webhookSecret);
                switch (stripeEvent.Type)
                {
                    case Events.CustomerSourceUpdated:
                        //make sure payment info is valid
                        break;
                    case Events.CustomerSourceExpiring:
                        //send reminder email to update payment method
                        break;
                    case Events.ChargeFailed:
                        //do something
                        break;
                }
                return Ok();
            //}
            //catch (StripeException e)
            //{
            //    return BadRequest();
            //}
        }
    }
}
