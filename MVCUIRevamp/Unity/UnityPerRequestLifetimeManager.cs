using System;

namespace RithV.FX.Unity
{
    public class UnityPerRequestLifetimeManager : Microsoft.Practices.Unity.LifetimeManager, IDisposable
    {
        private readonly IPerRequestStore _contextStore;
        private readonly Guid _key = Guid.NewGuid();

        /// <summary>
        /// Initializes a new instance of UnityPerRequestLifetimeManager with a per-request store.
        /// </summary>
        /// <param name="contextStore"></param>
        public UnityPerRequestLifetimeManager(IPerRequestStore contextStore)
        {
            this._contextStore = contextStore;
            this._contextStore.EndRequest += this.EndRequestHandler;
        }

        public override object GetValue()
        {
            return this._contextStore.GetValue(this._key);
        }

        public override void SetValue(object newValue)
        {
            this._contextStore.SetValue(this._key, newValue);
        }

        public override void RemoveValue()
        {
            var oldValue = this._contextStore.GetValue(this._key);
            this._contextStore.RemoveValue(this._key);

            var disposable = oldValue as IDisposable;
            disposable?.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            this.RemoveValue();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            this.RemoveValue();
        }
    }
}