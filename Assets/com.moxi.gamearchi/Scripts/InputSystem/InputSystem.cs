namespace GameArchi.InputSystem
{
    public class InputSystem
    {
        InputContext context;
        InputDomain domain;

        InputSetter setterAPI;
        public IInputSetter SetterAPI => setterAPI;
        InputGetter getterAPI;
        public IInputGetter GetterAPI => getterAPI;
        
        public InputEventCenter eventCenter;

        public InputSystem()
        {
            context = new InputContext();
            domain = new InputDomain();
            setterAPI = new InputSetter();
            eventCenter = new InputEventCenter();

            domain.Inject(context, eventCenter);
            setterAPI.Inject(domain);
        }

        public void Tick()
        {
            domain.Tick();
        }
    }
}