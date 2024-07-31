using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class PrjvSvr : Svr
    {
        public const string NicknameKey = "Nickname";
        
        [SerializeField] private Image playerPhoto;
        // [SerializeField] private Text playerNickname;
        [SerializeField] private InputField inputField;
        [SerializeField] private RectTransform photoMask;

        private Sprite _playerPhotoSprite;
        private UserFileManager _userFileManager;
        
        public void Bootstrap(UserFileManager userFileManager)
        {
            // if (PlayerPrefs.HasKey(NicknameKey))
            //     playerNickname.text = PlayerPrefs.GetString(NicknameKey);

            _userFileManager = userFileManager;
            _userFileManager.OnPhotoChange += UpdatePhoto;
        }

        public override void Open()
        {
            UpdatePhoto();            
            base.Open();
        }
        
        public void ChangePhoto()
        {
            DnundManager.OnButtonClick();
            _userFileManager.PickUserPhoto();
        }

        public void OnNicknameEditEnd()
        {
            if (inputField.text != "")
            {
                // playerNickname.text = inputField.text;
                PlayerPrefs.SetString(NicknameKey, inputField.text);
            }
            else
            {
                // playerNickname.text = "Name";
                PlayerPrefs.SetString(NicknameKey, "Name");
            }
        }
        
        private void UpdatePhoto()
        {
            playerPhoto.sprite = _userFileManager.UserPhoto;
            
            playerPhoto.SetNativeSize();
            var verticalCoeff = photoMask.rect.height / playerPhoto.rectTransform.rect.height / 
                                playerPhoto.transform.localScale.y;
            var horizontalCoeff = photoMask.rect.width / playerPhoto.rectTransform.rect.width
                                                       / playerPhoto.transform.localScale.x;
            
            if (verticalCoeff < .9 && horizontalCoeff < .9) 
                playerPhoto.transform.localScale *= Mathf.Max(verticalCoeff, horizontalCoeff);
            
            playerPhoto.color = new Color(255, 255, 255, playerPhoto.sprite is null ? 0 : 255);
        }
    }
}