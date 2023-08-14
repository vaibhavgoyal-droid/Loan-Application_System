using Backend.Models;

namespace Backend.Repository
{
    public interface IPaymentRepo
    {
        Payment GetPaymentById(int id);

        List<Payment> GetPaymentByuserId(int userId);

        Payment MakePayment(Payment payment);


    }
}
