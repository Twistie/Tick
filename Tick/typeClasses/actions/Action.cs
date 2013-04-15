namespace Tick.typeClasses.actions
{
    public abstract class Action
    {
        protected Entity Owner;
        public abstract void DoTick();
        public bool Complete { get; set; }
        protected Action( Entity e )
        {
            Owner = e;
        }
    }
}
