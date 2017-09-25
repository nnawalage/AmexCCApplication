using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.WebAPI.Helper
{
    public class PropertyChangedEventArgs : EventArgs
    {
        private object _objBefore = null;
        public object Before
        {
            get { return this._objBefore; }
        }

        private object _objAfter = null;
        public object After
        {
            get { return this._objAfter; }
        }

        public PropertyChangedEventArgs(object objBefore, object objAfter)
        {
            this._objBefore = objBefore;
            this._objAfter = objAfter;
        }
    }
}
