using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class SrtbeOertSvr : Svr
    {
        [SerializeField] private Image musicIcon;
        [SerializeField] private Image soundIcon;
        [SerializeField] private Toggle soundToggle;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Sprite musicSprite;
        [SerializeField] private Sprite soundSprite;
        [SerializeField] private Sprite musicDisabledSprite;
        [SerializeField] private Sprite soundDisabledSprite;
        
        public void Bootstrap()
        {
            UpdateIcons();
        }

        /*
        public void ToggleMusic()
        {
            _soundManager.OnButtonClick();
            _soundManager.IsMusicTurnedOn = !_soundManager.IsMusicTurnedOn;
            UpdateIcons();
        }

        public void ToggleSound()
        {
            _soundManager.OnButtonClick();
            _soundManager.IsSoundTurnedOn = !_soundManager.IsSoundTurnedOn;
            UpdateIcons();
        }*/

        public void ChangeSoundLevel()
        {
            DnundManager.DrtWErt = (int)(soundSlider.value * 100) - 100;
        }

        public void ChangeMusicLevel()
        {
            DnundManager.MdrWert = (int)(musicSlider.value * 100) - 100;
        }

        public void ToggleMusic()
        {
            DnundManager.MusicMuted = !DnundManager.MusicMuted;
            DnundManager.OnButtonClick();
            UpdateIcons();
        }

        public void ToggleSound()
        {
            DnundManager.SoundMuted = !DnundManager.SoundMuted;
            DnundManager.OnButtonClick();
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            soundIcon.sprite = DnundManager.SoundMuted 
                ? soundDisabledSprite 
                : soundSprite;
            musicIcon.sprite = DnundManager.MusicMuted
                ? musicDisabledSprite
                : musicSprite;
            
            // soundToggle.isOn = _soundManager.IsSoundTurnedOn;
            // musicToggle.isOn = _soundManager.IsMusicTurnedOn;

            soundSlider.value = (float)(DnundManager.DrtWErt + 100) / 100;
            musicSlider.value = (float)(DnundManager.MdrWert + 100) / 100;
        }
    }
}