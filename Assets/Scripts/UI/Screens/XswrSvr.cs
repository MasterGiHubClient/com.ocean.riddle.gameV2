using Core;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class XswrSvr : PayloadedScreen<GamePayload>
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Text scoreText;
        
        private LvrSdrWert _lvrSdrWert;

        public void Bootstrap(LvrSdrWert lvrSdrWert)
        {
            _lvrSdrWert = lvrSdrWert;
        }

        public override void Open()
        {
            scoreText.text = $"{TextFormatter.FormatScore(_payload.Score)}";
            
            base.Open();
        }

        public void Next()
        {
            DnundManager.OnButtonClick();
            
            _canvas.ChanSerSvr<CseSvr, GamePayload>(new GamePayload()
            {
                SelectedLevel = _lvrSdrWert.LastLevelIndex,
            });
        }
    }
}