using System;
using System.Globalization;

namespace RithV.FX.Entity
{
    public interface IExceptionMessageFormatter
    {
        string GetCompleteException(Exception ex);
    }

    public class ExceptionMessageFormatter : IExceptionMessageFormatter
    {
        public string GetCompleteException(Exception ex)
        {
            var exceptions = ex.Message.ToString(CultureInfo.InvariantCulture);
            var innerexe = ex.InnerException;
            while (innerexe != null)
            {
                exceptions += " --> " + innerexe.Message.ToString(CultureInfo.InvariantCulture);
                innerexe = innerexe.InnerException;
            }
            return exceptions;
        }
    }
}