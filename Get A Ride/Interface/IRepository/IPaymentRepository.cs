using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetARide.Entities;

namespace GetARide.Interface.IRepository
{
    public interface IPaymentRepository
    {
        public Task<Payment> MakePayment(Payment payment);
    }
}
