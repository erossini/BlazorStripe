using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStripe.Shared.Models
{
    public class StripeOptions
    {
        public string? ApiKey { get; set; }
        public string? WebhookSigningKey { get; set; }
    }
}
