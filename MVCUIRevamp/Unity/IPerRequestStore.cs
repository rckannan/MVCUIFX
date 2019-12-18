using System;

namespace RithV.FX.Unity
{
    public interface IPerRequestStore
    {
        object GetValue(object key);
        void SetValue(object key, object value);
        void RemoveValue(object key);

        event EventHandler EndRequest;
    }
}