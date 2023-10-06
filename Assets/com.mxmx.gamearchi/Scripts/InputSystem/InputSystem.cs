namespace GameArchi.InputSystem
{
    public class InputSystem
    {

        InputContext context;
        InputDomain domain;
        InputSetter setter;
        public IInputSetter Setter => setter;
        public InputEventCenter eventCenter;

        public InputSystem()
        {
            context = new InputContext();
            domain = new InputDomain();
            setter = new InputSetter();
            eventCenter = new InputEventCenter();
        }

        public void Inject()
        {
            domain.Inject(context,eventCenter);
            setter.Inject(domain);
        }

        public void Tick()
        {
            domain.Tick();
        }
    }
}