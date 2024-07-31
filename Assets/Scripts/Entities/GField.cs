using System;
using System.Collections;
using System.Linq;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Entities
{
    public class GField : MonoBehaviour
    {
        [FormerlySerializedAs("spheres")] [SerializeField] private Collstin[] collstins;
        [FormerlySerializedAs("colors")] [SerializeField] private Sprite[] clrs;
        [SerializeField] private int seed;

        private Collstin _openedCollstin;
        private int _mtcCond = 0;
        private int _trsCntColl = 0;
        private int _scrtg;
        private int _dfeWer = 0;
        private int _mvSwer = 0;
        private DnundManager _dnundManager;

        public event Action<int> OnScCnn;
        public event Action<int> OnMove;
        public event Action OnWin;
        public event Action<int> OnTmChn;

        public int Scrtg => _scrtg;
        
        private void Start()
        {
            foreach (var collstin in collstins)
            {
                collstin.OnOpen += () => OnSphereOpen(collstin);
            }

            OnMove.Invoke(0);
            OnTmChn.Invoke(0);
        }

        public void Bootstrap(DnundManager dnundManager, int winScore, int level)
        {
            _dnundManager = dnundManager;
            seed = level;
            ShuffleClrs(seed);
        }
        
        public void Confirm()
        {
            StartCoroutine(TckWer());
        }

        private void ShuffleClrs(int seed)
        {
            if (clrs.Length != collstins.Length / 2)
                throw new ArgumentException("Not valid count of clrs");
            
            Random.InitState(seed);
            int k = 0;
            
            foreach (int i in Enumerable.Range(0, collstins.Length).OrderBy(_ => Random.Range(0, collstins.Length)))
            {
                collstins[i].ChnCLllr(clrs[k % clrs.Length]);
                k += 1;
            }
        }

        private void OnSphereOpen(Collstin collstin)
        {
            _dnundManager.OnDiamondClick();
            if (_openedCollstin is null)
            {
                _openedCollstin = collstin;
                return;
            }

            _trsCntColl += 1;
            _mvSwer += 1;
            
            OnMove.Invoke(_mvSwer);

            if (collstin.CollstingSprite == _openedCollstin.CollstingSprite)
            {
                _scrtg += Mathf.RoundToInt(1f / Math.Min(_trsCntColl, 1) * 1);
                _trsCntColl = 0;
                // _dnundManager.OnCoinCollect();
                OnScCnn?.Invoke(_scrtg);
                
                _mtcCond += 2;
                _openedCollstin = null;

                if (_mtcCond == collstins.Length)
                {
                    _dnundManager.OnDer();
                    OnWin?.Invoke();
                }

                return;
            }

            _openedCollstin.Close();
            _openedCollstin = null;
            collstin.Close();
        }
        
        private IEnumerator TckWer()
        {
            while (true)
            {
                _dfeWer += 1;
                
                OnTmChn.Invoke(_dfeWer);

                yield return new WaitForSeconds(1);
            }
        }
    }
}