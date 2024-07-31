using Managers;
using UnityEngine;

namespace UI.Screens
{
    public class ExpoSrv : Svr
    {
        public void Exit()
        {
            DnundManager.OnButtonClick();
            Application.Quit();
        }
    }
}