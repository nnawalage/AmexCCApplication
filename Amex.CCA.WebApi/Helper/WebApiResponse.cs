using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.WebAPI.Helper
{
    public class WebApiResponse : HttpResponseMessage
    {
        private JsonResponse _objResponse = null;

        public WebApiResponse()
            : base()
        {
            base.StatusCode = HttpStatusCode.OK;

            this._objResponse = new JsonResponse();
            this._objResponse.PropertyChanged += OnPropertyChanged;

            this.SetContent();
        }

        public WebApiResponse(HttpStatusCode statusCode)
            : this()
        {
            this.StatusCode = statusCode;
        }

        public new JsonResponse Content
        {
            get { return this._objResponse; }
        }

        private void SetContent()
        {
            string strOutput = JsonConvert.SerializeObject(this._objResponse,Formatting.Indented,
                                new JsonSerializerSettings
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
            base.Content = new StringContent(strOutput, Encoding.UTF8, "application/json");
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.SetContent();
        }

    }
}
