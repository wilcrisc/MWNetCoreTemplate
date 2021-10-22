using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Payment
{
    public class PaypalApiSetting
    {
        public string ApiAppName { get; set; }
        public string Account { get; set; }
        public string ClientID { get; set; }
        public string Secret { get; set; }

    }
}
