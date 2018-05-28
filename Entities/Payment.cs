using System;
using System.ComponentModel.DataAnnotations;

namespace RcpgMicroserviceClient.Entities
{
    public class Payment
    {
        public string Token { get; set; }
        
        public int Sum { get; set; }

        [Required]
        [MaxLength(50)]
        public string Currency { get; set; }

        [Required]
        [MaxLength(200)]
        public string Provider { get; set; }

        [Required]
        [MaxLength(100)]
        public string Intent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Status { get; set; }

        [MaxLength(450)]
        public string TransactionId { get; set; }

        public DateTime InitiatedOn { get; set; }

        public DateTime? CapturedOn { get; set; }
    }
}