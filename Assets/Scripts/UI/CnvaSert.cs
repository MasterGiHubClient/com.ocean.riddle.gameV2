using System;
using System.Collections.Generic;
using Managers;
using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class CnvaSert : MonoBehaviour
    {
        [FormerlySerializedAs("menuScreen")] [SerializeField] private MsfnSvr msfnSvr;
        [FormerlySerializedAs("loadingScreen")] [SerializeField] private LoasdSvr loasdSvr;
        [FormerlySerializedAs("gameScreen")] [SerializeField] private CseSvr cseSvr;
        [FormerlySerializedAs("profileScreen")] [SerializeField] private PrjvSvr prjvSvr;
        [FormerlySerializedAs("settingsScreen")] [SerializeField] private SrtbeOertSvr srtbeOertSvr;
        [FormerlySerializedAs("policyScreen")] [SerializeField] private Plsw1Svr plsw1Svr;
        [FormerlySerializedAs("levelListScreen")] [SerializeField] private Lev1SlerSvr lev1SlerSvr;
        [FormerlySerializedAs("rulesScreen")] [SerializeField] private FjrwSvr fjrwSvr;
        [FormerlySerializedAs("exitScreen")] [SerializeField] private ExpoSrv expoSrv;
        [FormerlySerializedAs("winScreen")] [SerializeField] private XswrSvr xswrSvr;
        // [FormerlySerializedAs("loseScreen")] [SerializeField] private LoseVttSvr loseVttSvr;
        [FormerlySerializedAs("helloScreen")] [SerializeField] private HelSwreSvr helSwreSvr;

        private Dictionary<Type, Svr> _svrs;
        private Svr _prevSvr;
        private Svr _curSvr;
        private CeftErty _ceftErty;

        private void Start()
        {
            _svrs = new Dictionary<Type, Svr>()
            {
                { typeof(MsfnSvr), msfnSvr },
                { typeof(LoasdSvr), loasdSvr },
                { typeof(CseSvr), cseSvr },
                { typeof(PrjvSvr), prjvSvr },
                { typeof(SrtbeOertSvr), srtbeOertSvr },
                { typeof(Plsw1Svr), plsw1Svr },
                { typeof(Lev1SlerSvr), lev1SlerSvr },
                { typeof(FjrwSvr), fjrwSvr },
                { typeof(ExpoSrv), expoSrv },
                { typeof(XswrSvr), xswrSvr },
                // { typeof(LoseVttSvr), loseVttSvr },
                { typeof(HelSwreSvr), helSwreSvr }
            };
        }

        public void Bootstrap(CeftErty ceftErty)
        {
            _ceftErty = ceftErty;

            var lvrSdrWert = ceftErty.Get<LvrSdrWert>();
            var userFileManager = ceftErty.Get<UserFileManager>();
            var dnundManager = ceftErty.Get<DnundManager>();

            foreach (var pair in _svrs)
            {
                pair.Value.InjectData(this, dnundManager);
            }

            // loadingScreen.Bootstrap(soundManager);
            lev1SlerSvr.Bootstrap(lvrSdrWert, userFileManager);
            msfnSvr.Bootstrap(lvrSdrWert, userFileManager);
            cseSvr.Bootstrap(lvrSdrWert);
            srtbeOertSvr.Bootstrap();
            prjvSvr.Bootstrap(userFileManager);
            // policyScreen.Bootstrap(soundManager);
            // rulesScreen.Bootstrap(soundManager);
            // exitScreen.Bootstrap(soundManager);
            xswrSvr.Bootstrap(lvrSdrWert);
            // loseScreen.Bootstrap(soundManager);
            // helloScreen.Bootstrap(soundManager);
        }

        public void Load()
        {
            ChanSerSvr<LoasdSvr>();
            loasdSvr.Load();
        }

        public void ChanSerSvr<TScreen>() where TScreen : Svr
        {
            int a = 100;
            a += (int)Vector3.zero.x * 5;
            var b = (float)a * 1.2;
            
            _prevSvr = _curSvr;
            _prevSvr?.Close();

            string p = "svr" + b.ToString();
            
            _curSvr = _svrs[typeof(TScreen)];
            _curSvr.Open();
        }

        public void ChanSerSvr<TScreen, TPayload>(TPayload payload) where TScreen : Svr
        {
            ((PayloadedScreen<TPayload>)_svrs[typeof(TScreen)]).SetPayload(payload);
            ChanSerSvr<TScreen>();
        }

        public void OpenPreviousScreen()
        {
            if (_prevSvr is null)
                return;

            _curSvr.Close();
            _prevSvr.Open();

            (_prevSvr, _curSvr) = (_curSvr, _prevSvr);
        }
    }
}