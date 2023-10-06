using UnityEngine;

namespace GameArchi.UISystem
{
    public abstract class UIBase : MonoBehaviour
    {
        protected int _id;
        public int Id => _id;

        protected UIRoot _rootLayer;
        public UIRoot RootLayer => _rootLayer;

        protected int _order;
        public int Order => _order;

        public abstract void Ctor();

        public virtual void Dispose()
        {
            Destroy(this.gameObject);
        }

        public virtual void Show()
        {
            this.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public virtual void Tick(float dt)
        {

        }
    }
}