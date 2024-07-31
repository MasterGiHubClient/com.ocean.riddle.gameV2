using Content;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class ServaWrt : MonoBehaviour
{
        [FormerlySerializedAs("canvas")] [SerializeField] private CnvaSert cverwe;
        [FormerlySerializedAs("levelsDatabase")] [SerializeField] private LevelsDatabase lvsetDetqwe;
        [FormerlySerializedAs("soundManager")] [SerializeField] private DnundManager dnundManager;

        private readonly CeftErty _ceftErty = CeftErty.Instance;

        private void Start()
        {
                Application.targetFrameRate = 60;
                
                DontDestroyOnLoad(this);
                
                _ceftErty.Register(cverwe);
                _ceftErty.Register(lvsetDetqwe);
                _ceftErty.Register(new LvrSdrWert(lvsetDetqwe));
                _ceftErty.Register(dnundManager);
                _ceftErty.Register(new UserFileManager());
                
                cverwe.Bootstrap(_ceftErty);
                cverwe.Load();
        }
}