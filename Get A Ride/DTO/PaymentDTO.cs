using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetARide.DTO
{
    public class PaymentDTO
    {
        public int Id {get; set;}
        public string ReferenceNumber{get; set;}
        public decimal Amount { get; set; }
        public bool Ispayed { get; set; }
        public int OrderId { get; set; }       
    }

    public class PaymentRequestModel
    {
        public decimal Amount{get; set;}
        public int orderId{get; set;}
    }

    public class PaymentResponseModel
    {
        public PaymentDTO Data{get; set;}
    }

    public class PaymentsResponseModel
    {
        public ICollection<PaymentDTO> Data{get; set;}
    }
}
