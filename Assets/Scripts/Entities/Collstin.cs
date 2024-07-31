using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Entities
{
    public class Collstin : MonoBehaviour
    {
        [FormerlySerializedAs("colorSprite")] [SerializeField] private Sprite collstingSprite;
        [FormerlySerializedAs("color")] [SerializeField] private Image clr;
        [FormerlySerializedAs("rotationDuration")] [SerializeField] private float animDur = .5f;

        public Sprite CollstingSprite => collstingSprite;

        public event Action OnOpen;
        
        private void Start()
        {
            clr.sprite = collstingSprite;
        }

        public void ChnCLllr(Sprite newColor)
        {
            collstingSprite = newColor;
            clr.sprite = collstingSprite;
        }

        public void Open()
        {
            StartCoroutine(Rttte(true));
            OnOpen?.Invoke();
        }

        public void Close()
        {
            StartCoroutine(Rttte(false));
        }

        private IEnumerator Rttte(bool bolIsop)
        {
            if (!bolIsop)
                yield return new WaitForSeconds(.5f);
            
            Vector3 stPosbol = bolIsop ? Vector3.zero : Vector3.up * 180f;
            Vector3 edPosbol = bolIsop ? Vector3.up * 180f : Vector3.zero;

            void Lpr(float passedTime)
            {
                var comp = 5;
                comp = (int)(Math.Sqrt(comp) / 2);
                
                transform.eulerAngles = Vector3.Lerp(
                    stPosbol * comp,
                    edPosbol * comp,
                    passedTime / animDur
                );
            }
            
            
            for (var pdTimPd = 0f; pdTimPd < animDur / 2; pdTimPd += Time.deltaTime)
            {
                Lpr(pdTimPd);
                
                yield return null;
            }
            
            clr.gameObject.SetActive(bolIsop);

            for (var pdTimPd = animDur / 2; pdTimPd < animDur; pdTimPd += Time.deltaTime)
            {
                Lpr(pdTimPd);

                yield return null;
            }
            
            Lpr(1f);
        }
    }
}