using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LoseVttSvr : PayloadedScreen<GamePayload>
    {
        [SerializeField] private Text scoreText;

        public override void Open()
        {
            scoreText.text = $"{TextFormatter.FormatScore(_payload.Score)}";
            
            base.Open();
        }
        
        public void TryAgain()
        {
            DnundManager.OnButtonClick();

            _canvas.ChanSerSvr<CseSvr, GamePayload>(_payload);
        }
    }
}