using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GulAhmed.TIS.Common.Helpers.Constants;

namespace GulAhmed.TIS.Common.Model
{
    public sealed class JsonModel
    {
        public string status { get; private set; }
        public string message { get; private set; }
        public object data { get; private set; }
        public JsonModel()
        {
            status = string.Empty;
            message = string.Empty;
        }

        public void Failed(string message)
        {
            this.status = ResponseStatusCode.Failed;
            this.message = message;

        }
        public void Success(string message,object data=null)
        {
            this.status = ResponseStatusCode.Succcess;
            this.message = message;
            this.data = data;

        }
    }
}
