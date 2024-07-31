using Core;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MsfnSvr : Svr
    {
        [SerializeField] private Text profileName;
        [SerializeField] private Image profilePhoto;
        [SerializeField] private RectTransform photoMask;
        [SerializeField] private Text scoreText;
        private UserFileManager _userFileManager;
        private LvrSdrWert _lvrSdrWert;

        public void Bootstrap(
            LvrSdrWert lvrSdrWert,
            UserFileManager userFileManager
        )
        {
            _lvrSdrWert = lvrSdrWert;
            _userFileManager = userFileManager;
        }

        public void StartGame()
        {
            DnundManager.OnButtonClick();
            _canvas.ChanSerSvr<CseSvr, GamePayload>(
                new GamePayload() { SelectedLevel = _lvrSdrWert.LastLevelIndex }
            );
            // _canvas.ChangeScreen<GameScreen, GamePayload>(new GamePayload { SelectedLevel = _levelSavesManager.LastLevelIndex });
        }

        public override void Open()
        {
            profileName.text = PlayerPrefs.HasKey(PrjvSvr.NicknameKey) 
                ? PlayerPrefs.GetString(PrjvSvr.NicknameKey) 
                : "Name";
            profilePhoto.sprite = _userFileManager.UserPhoto;
            scoreText.text = $"{TextFormatter.FormatScore(_lvrSdrWert.Sctew)}";
            profilePhoto.SetNativeSize();
            
            var verticalCoeff = photoMask.rect.height / profilePhoto.rectTransform.rect.height / 
                                profilePhoto.transform.localScale.y;
            var horizontalCoeff = photoMask.rect.width / profilePhoto.rectTransform.rect.width
                / profilePhoto.transform.localScale.x;

            if (verticalCoeff < .9 && horizontalCoeff < .9) 
                profilePhoto.transform.localScale *= Mathf.Max(verticalCoeff, horizontalCoeff);
            
            profilePhoto.color = new Color(255, 255, 255, profilePhoto.sprite is null ? 0 : 255);
            
            base.Open();
        }
        
        public void Exit()
        {
            DnundManager.OnButtonClick();
            Application.Quit();
        }
    }
}