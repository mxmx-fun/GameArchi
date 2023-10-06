using GameArchi.Repo;

namespace GameArchi.UISystem
{

    public class UIContext
    {
        // ========== Repo ==========
        UIRepo uiRepo;
        public UIRepo UIRepo => uiRepo;

        public UIContext() {
            uiRepo = new UIRepo();
        }

    }
}