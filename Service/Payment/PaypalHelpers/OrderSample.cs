using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Payment.PaypalHelpers
{
    class OrderSample
    {

        #region capture order
        public async static Task<HttpResponse> CaptureOrder(string OrderId)
        {
            var request = new OrdersCaptureRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            var response = await PaypalClient.client().Execute(request);

            // Add code here to process the response results on server.
            // for example, you can extract the order ID and buyer's information and store them to database.


            return response;
        }
        #endregion capture order

        #region get order


        public async static Task<HttpResponse> GetOrder(string orderId)
        {
            var request = new OrdersGetRequest(orderId);
            var response = await PaypalClient.client().Execute(request);
            return response;
        }
        #endregion get order

        #region capture intent order

        public async static Task<HttpResponse> CreateOrderWithMinimumFields(string intent, string amount = "0.01")
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBodyWithMinimumFields(intent, amount));
            var response = await PaypalClient.client().Execute(request);

            return response;
        }

        private static OrderRequest BuildRequestBodyWithMinimumFields(string intent, string amount)
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = intent.ToUpper(),
                ApplicationContext = new ApplicationContext
                {
                    CancelUrl = "",
                    ReturnUrl = ""
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest{
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = "PHP",
                            Value = amount
                        }
                    }
                }
            };

            return orderRequest;
        }


        #endregion capture intent order
    }
}
