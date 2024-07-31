namespace UI.Screens
{
    public abstract class PayloadedScreen<TPayload> : Svr
    {
        protected TPayload _payload;

        public virtual void SetPayload(TPayload payload)
        {
            _payload = payload;
        }
    }
}