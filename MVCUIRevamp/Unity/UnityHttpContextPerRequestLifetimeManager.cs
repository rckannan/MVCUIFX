namespace RithV.FX.Unity
{
    public class UnityHttpContextPerRequestLifetimeManager : UnityPerRequestLifetimeManager
    {
        public UnityHttpContextPerRequestLifetimeManager()
            : base(new HttpContextPerRequestStore())
        {
        }
    }
}