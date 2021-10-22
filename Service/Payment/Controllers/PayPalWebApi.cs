using Core.Entities;
using Infrastructure.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using Service.Payment.PaypalHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Service.Payment.Controllers
{
    public class PayPalWebApi : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
     

        public PayPalWebApi(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager; 

        }

        [Route("~/api/CreateMinimumOrder/{intent}/{amount}")]
        [HttpPost]
        public async Task<string> CreateMinimumOrder(string intent, string amount)
        {
            var response = await OrderSample.CreateOrderWithMinimumFields(intent, amount);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/CaptureOrder/{orderId}/{productId}")]
        [HttpPost]
        public async Task<string> CaptureOrder(string orderId, int productid)
        {


            var response = await OrderSample.CaptureOrder(orderId);
            var res = response.Result<Order>();

            #region SampleCode

            //var selectedProduct = _context.Products.FirstOrDefault(x => x.ProductID == productid);

            //if (res.Status.StartsWith("COMPLETED"))
            //{
            //    var newInvoice = new OrderInvoice
            //    {
            //        TotalAmount = selectedProduct.PricePerQuantity,
            //        Discount = 0,
            //        ValueAddedTax = 0,
            //        Currency = selectedProduct.Currency,
            //        IsFullfilled = true,
            //        AppUserID = _userManager.GetUserId(User),

            //    };

            //    _context.OrderInvoices.Add(newInvoice);

            //    _context.SaveChanges();

            //    var newPaymentTransact = new PaymentTransaction
            //    {
            //        OrderInvoiceID = newInvoice.OrderInvoiceID,
            //        AmountPaid = selectedProduct.PricePerQuantity,
            //        PayChannel = "PayPal",
            //        PayReference = res.Id,
            //        DatePaid = DateTime.Now.Date,
            //        IsVerified = true

            //    };

            //    _context.PaymentTransactions.Add(newPaymentTransact);


            //    _context.OrderItems.Add(new OrderItem
            //    {
            //        OrderInvoiceID = newInvoice.OrderInvoiceID,
            //        Currency = selectedProduct.Currency,
            //        Quantity = 1,
            //        Price = selectedProduct.PricePerQuantity,
            //        ProductID = selectedProduct.ProductID

            //    });

            //    _context.ReviewerAccess.Add(
            //        new ReviewerAccess
            //        {
            //            AppUserID = _userManager.GetUserId(User),
            //            DateRequested = DateTime.Now.Date,
            //            LicenseType = selectedProduct.ProductName,
            //            OrderInvoiceID = newInvoice.OrderInvoiceID
            //        }
            //    );

            //    _context.SaveChanges();

            //    var appuser = _context.AppUsers.Find(_userManager.GetUserId(User));

            //    var moodleUserPrem = _pmoodleDbContext.MdlUsers.FirstOrDefault(x => x.Id == appuser.MoodleUserIDPrem);
            //    var moodleUserCohort = _pmoodleDbContext.MdlCohortMembers.FirstOrDefault(x => x.Userid == appuser.MoodleUserIDPrem);

            //    if (moodleUserPrem != null)
            //        moodleUserPrem.Confirmed = true;

            //    if (moodleUserCohort == null)
            //    {
            //        _pmoodleDbContext.MdlCohortMembers.Add(new Core.Entities.MoodlePremium.MdlCohortMember
            //        {
            //            Cohortid = 1,
            //            Userid = appuser.MoodleUserIDPrem,
            //            Timeadded = 0
            //        });
            //    }
            //    _pmoodleDbContext.SaveChanges();
            //}

            #endregion

            var json = JsonConvert.SerializeObject(res);

            return json;
        }

    }

}
