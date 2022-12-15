using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetARide.Context;
using GetARide.Entities;
using GetARide.Interface.IRepository;

namespace GetARide.Implementation.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationContext _context;
        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Payment> MakePayment(Payment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
