using System;
using System.Net;

namespace RithV.FX.Base
{
    public class ResultValue<T> : IDisposable
    {
        public T Result
        {
            get;
            set;
        }
        public HttpStatusCode Code
        {
            get;
            set;
        }
        public string Exceptions
        {
            get;
            set;
        }
        public void Dispose()
        {
            ((IDisposable)Result).Dispose();
        }
    }

    public partial class DropDownClass
    {
        public long Key
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }
    }
}