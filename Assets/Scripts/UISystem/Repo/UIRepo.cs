using System.Collections.Generic;
using GameArchi.UISystem;

namespace GameArchi.Repo
{
    public class UIRepo
    {
        public Dictionary<int, UIBase> uiDic = new Dictionary<int, UIBase>();

        public void Ctor()
        {
            uiDic = new Dictionary<int, UIBase>();
        }

        public void Add(int id,UIBase ui)
        {
            uiDic.Add(id, ui);
        }

        public UIBase Get(UIType type) 
        {
            var id = (int)type;
            if (uiDic.ContainsKey(id))
            {
                return uiDic[id];
            }
            return null;
        }

        public void Remove(UIType type)
        {
            var id = (int)type;
            if (uiDic.ContainsKey(id))
            {
                uiDic.Remove(id);
            }
        }

        public void Dispose()
        {
            foreach (var ui in uiDic.Values)
            {
                ui.Dispose();
            }
            uiDic.Clear();
        }


    }
}