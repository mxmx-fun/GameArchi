using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameArchi.UISystem
{
    public class LoginPanelUI : UIBase
    {
        public Button LoginButton;
        public event Action OnLoginButtonClicked;

        public override void Ctor()
        {
            _id = (int)UIType.LoginPanelUI;
            _rootLayer = UIRoot.Bottom;

            LoginButton = transform.Find("Btn_StartGame").GetComponent<Button>();

            LoginButton.onClick.AddListener(() => OnLoginButtonClicked?.Invoke());
        }

        public override void Dispose()
        {
            LoginButton.onClick.RemoveAllListeners();
            base.Dispose();
        }
    }
}