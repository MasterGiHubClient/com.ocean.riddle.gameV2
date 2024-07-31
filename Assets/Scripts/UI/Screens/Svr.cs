using Managers;
using UnityEngine;

namespace UI.Screens
{
    public abstract class Svr : MonoBehaviour
    {
        protected CnvaSert _canvas;
        protected DnundManager DnundManager;
        
        public void InjectData(CnvaSert canvas, DnundManager dnundManager)
        {
            _canvas = canvas;
            DnundManager = dnundManager;
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public virtual void OpenExitScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<ExpoSrv>();            
        }

        public virtual void OpenHelloScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<HelSwreSvr>();
        }

        public virtual void OpenLevelListScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<Lev1SlerSvr>();
        }

        public virtual void OpenMenuScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<MsfnSvr>();
        }

        public virtual void OpenPolicyScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<Plsw1Svr>();
        }

        public virtual void OpenProfileScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<PrjvSvr>();
        }

        public virtual void OpenRulesScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<FjrwSvr>();
        }

        public virtual void OpenSettingsScreen()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<SrtbeOertSvr>();
        }

        public virtual void Back()
        {
            DnundManager.OnButtonClick();
            _canvas.OpenPreviousScreen();
        }
    }
}