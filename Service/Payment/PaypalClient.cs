using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Core;
using PayPalHttp;
using Service.Payment.PaypalHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Payment
{
    public class PaypalClient
    {
        public static PayPalEnvironment environment()
        {
            IOptions<PaypalApiSetting> ps = ServiceLocator.Current.GetInstance<IOptions<PaypalApiSetting>>();
            return new LiveEnvironment(ps.Value.ClientID, ps.Value.Secret); // Enable in  Production
            //return new SandboxEnvironment(ps.Value.ClientID, ps.Value.Secret);
        }

        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(serializableObject.GetType(),
                new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            serializer.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
