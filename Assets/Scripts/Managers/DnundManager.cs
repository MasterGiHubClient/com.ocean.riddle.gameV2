using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Managers
{
    public class DnundManager : MonoBehaviour
    {
        private const string SdnJey = "Sound";
        private const string MnsJey = "Music";
        private const string mstMrJey = "MusicMuted";
        private const string mstEdrJey = "SoundMuted";

        [FormerlySerializedAs("backgroundMusic")] [SerializeField] private AudioSource bcrvDrt;
        [FormerlySerializedAs("buttonClick")] [SerializeField] private AudioSource bntScrt;
        [FormerlySerializedAs("sphereClick")] [SerializeField] private AudioSource SftwQer;
        [FormerlySerializedAs("winSound")] [SerializeField] private AudioSource wsDrbr;
        [FormerlySerializedAs("coinCollect")] [SerializeField] private AudioSource cdeColl;
        [SerializeField] private AudioMixerGroup soundMixerGroup;
        [SerializeField] private AudioMixerGroup musicMixerGroup;

        private int _drtWErt = 100;
        private int _mdrWert = 100;

        public int DrtWErt
        {
            get => _drtWErt;
            set
            {
                _drtWErt = value;
                ChmEctDwer();
            }
        }

        public int MdrWert
        {
            get => _mdrWert;
            set
            {
                _mdrWert = value;
                ChmEcrtPorw();
            }
        }
        
        public bool SoundMuted { get; set; }

        public bool MusicMuted
        {
            get => bcrvDrt.mute;
            set => bcrvDrt.mute = value;
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey(SdnJey))
                PlayerPrefs.SetInt(SdnJey, _drtWErt);
            
            if (!PlayerPrefs.HasKey(MnsJey))
                PlayerPrefs.SetInt(MnsJey, _mdrWert);
            
            if (!PlayerPrefs.HasKey(mstMrJey))
                PlayerPrefs.SetInt(mstMrJey, MusicMuted ? 1 : 0);
            
            if (!PlayerPrefs.HasKey(mstEdrJey))
                PlayerPrefs.SetInt(mstEdrJey, SoundMuted ? 1 : 0);

            DrtWErt = PlayerPrefs.GetInt(SdnJey);
            MdrWert = PlayerPrefs.GetInt(MnsJey);
            MusicMuted = PlayerPrefs.GetInt(mstMrJey) == 1;
            SoundMuted = PlayerPrefs.GetInt(mstEdrJey) == 1;
            
            ChmEctDwer();
            ChmEcrtPorw();
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(SdnJey, DrtWErt);
            PlayerPrefs.SetInt(MnsJey, MdrWert);
        }

        public void OnButtonClick()
        {
            if (SoundMuted)
                return;
            
            bntScrt.Play();
        }

        public void OnDiamondClick()
        {
            if (SoundMuted)
                return;

            SftwQer.Play();
        }

        public void OnDer()
        {
            if (SoundMuted)
                return;

            wsDrbr.Play();
        }

        public void StveWdrGdwer()
        {
            bcrvDrt.Play();
        }

        private void ChmEctDwer()
        {
            soundMixerGroup.audioMixer.SetFloat("SoundVolume", _drtWErt);
        }

        private void ChmEcrtPorw()
        {
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", _mdrWert);
        }
    }
}