namespace GameArchi.UISystem
{

    public class UISystem
    {

        UISetter uiSetter;
        public IUISetter UISetter => uiSetter;

        UIContext context;

        LoginPanelUIDomain loginPanelUIDomain;
        public LoginPanelUIDomain LoginPanelUIDomain => loginPanelUIDomain;

        public UISystem()
        {
            uiSetter = new UISetter();
            context = new UIContext();
            loginPanelUIDomain = new LoginPanelUIDomain();
        }

        public void Inject()
        {
            loginPanelUIDomain.Inject(context);
        }

        public void Ctor()
        {
            loginPanelUIDomain.Ctor();
        }
    }
}