using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.WebAPI.Helper
{
    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

    public class JsonResponse
    {

        private event PropertyChangedEventHandler _objHandler = null;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { this._objHandler += value; }
            remove { this._objHandler -= value; }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this._objHandler == null) { return; }
            this._objHandler(this, e);
        }

        private MessageCode _msgCode = 0;
        public MessageCode Code
        {
            get { return this._msgCode; }
            set
            {
                PropertyChangedEventArgs objArgs = new PropertyChangedEventArgs(this._msgCode, value);
                this._msgCode = value; this.OnPropertyChanged(objArgs);
            }
        }

        private string _strMessage = null;
        public string Message
        {
            get { return this._strMessage; }
            set
            {
                PropertyChangedEventArgs objArgs = new PropertyChangedEventArgs(this._strMessage, value);
                this._strMessage = value; this.OnPropertyChanged(objArgs);
            }
        }

        private object _objResult = null;
        public object Result
        {
            get { return this._objResult; }
            set
            {
                PropertyChangedEventArgs objArgs = new PropertyChangedEventArgs(this._objResult, value);
                this._objResult = value; this.OnPropertyChanged(objArgs);
            }
        }

        public JsonResponse()
        {
            this._msgCode = MessageCode.Success;
            this._strMessage = "Success";

            this._objResult = null;
        }

        public JsonResponse(MessageCode msgCode)
            : this()
        {
            this._msgCode = msgCode;
        }

        public JsonResponse(string strMessage)
            : this()
        {
            this._strMessage = strMessage;
        }

        public JsonResponse(MessageCode msgCode, string strMessage)
            : this()
        {
            this._msgCode = msgCode;
            this._strMessage = strMessage;
        }
    }
}
