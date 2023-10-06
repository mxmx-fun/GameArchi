using System;

namespace GameArchi.UISystem
{
    public class LoginPanelUIDomain
    {
        UIContext context;

        public void Inject(UIContext context) {
            this.context = context;
        }

        public void Ctor()
        {
            var uiRepo = context.UIRepo;
            var loginPanelUI = uiRepo.Get(UIType.LoginPanelUI);
            loginPanelUI.Ctor();
        }

        public void Open()
        {
            var uiRepo = context.UIRepo;
            var loginPanelUI = uiRepo.Get(UIType.LoginPanelUI);
            loginPanelUI.Show();
        }

        public void Close()
        {
            var uiRepo = context.UIRepo;
            var loginPanelUI = uiRepo.Get(UIType.LoginPanelUI);
            loginPanelUI.Hide();
        }

        public void Dispose()
        {
            var uiRepo = context.UIRepo;
            var loginPanelUI = uiRepo.Get(UIType.LoginPanelUI);
            loginPanelUI.Dispose();
        }

    }
}