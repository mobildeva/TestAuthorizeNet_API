using AuthorizeNet.Api.Contracts.V1;
using System;

namespace TestAPI_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var apiLogin = "3C6M9JggD";

            var tk = "24V9zfbeV6M73b88";

            //ChargeCreditCard.Run("3C6M9JggD", "24V9zfbeV6M73b88");

            Console.WriteLine("Authorize credit card.");

            AuthorizeCreditCard.Run(apiLogin, tk, 200);

            Console.WriteLine("Do a ChasePay Transaction....");

            createTransactionResponse response = CreateChasePayTransaction.Run(apiLogin, tk) as createTransactionResponse;

            var transactionId = response!=null?  response.transactionResponse.transId: string.Empty;

            if (!string.IsNullOrEmpty(transactionId))
            {
                Console.WriteLine("Do a Refund Transaction....");

                RefundTransaction.Run(apiLogin, tk, 133.45m, transactionId);
            }

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
