using System.Threading.Tasks;
using GetARide.DTO;

namespace GetARide.Interface.IService
{
    public interface IPaymentService
    {
        public Task<PaystackResponse> MakePayment(PaymentRequestModel model);

        public Task<BaseResponse> VerifyPayment(string referrenceNumber);

        public Task<PaymentsResponseModel> GetAllPaymentsByCustomer(int passngerId);
    }
}