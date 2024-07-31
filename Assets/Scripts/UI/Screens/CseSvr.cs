using System;
using System.Collections;
using Core;
using Entities;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class CseSvr : PayloadedScreen<GamePayload>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timeText;
        [SerializeField] private Transform gamePlace;
        [SerializeField] private Text levelText;
        [SerializeField] private Text movesText;
        [SerializeField] private int winScore = 550;
        
        private GField _gField;
        
        private LvrSdrWert _lvrSdrWert;

        public void Bootstrap(LvrSdrWert lvrSdrWert)
        {
            _lvrSdrWert = lvrSdrWert;
        }

        public override void SetPayload(GamePayload payload)
        {
            base.SetPayload(payload);

            scoreText.text = $"0";
            // levelText.text = $"L E V E L   {TextFormatter.FormatScore(payload.SelectedLevel + 1)}";

            if (_gField != null)
            {
                _gField.OnWin -= OnWin;
                // _gameField.OnLose -= OnLose;
                _gField.OnScCnn -= OnScCnn;
                _gField.OnTmChn -= OnTmChn;
                _gField.OnMove -= OnMove;
                Destroy(_gField.gameObject);
            }

            _gField = Instantiate(
                _lvrSdrWert.GetSertJety(payload.SelectedLevel), 
                gamePlace
            );
            _gField.OnWin += OnWin;
            // _gameField.OnLose += OnLose;
            _gField.OnScCnn += OnScCnn;
            _gField.OnTmChn += OnTmChn;
            _gField.OnMove += OnMove;
            
            _gField.Bootstrap(DnundManager, winScore, payload.SelectedLevel);
        }

        public override void Open()
        {
            base.Open();
            
            if(_gField != null)
                _gField.Confirm();
        }

        public override void Close()
        {
            base.Close();
        }
        
        public void NextLevel()
        {
            DnundManager.OnButtonClick();
            if (_payload.SelectedLevel >= 8)
            {
                _canvas.ChanSerSvr<MsfnSvr>();
                return;
            }
            
            SetPayload(new GamePayload() { SelectedLevel = _payload.SelectedLevel + 1 });
        }

        private void OnWin()
        {
            _lvrSdrWert.InerWertSwer(_payload.SelectedLevel);
            _lvrSdrWert.Sctew += _gField.Scrtg;

            StartCoroutine(CallDelayed(() =>
            {
                _canvas.ChanSerSvr<XswrSvr, GamePayload>(new GamePayload
                {
                    Score = _gField.Scrtg,
                    SelectedLevel = _payload.SelectedLevel
                });
            }));


            // winScreen.SetActive(true);
            // nextLevelButton.SetActive(true);
        }

        private void OnMove(int moves)
        {
            movesText.text = $"MOVES: {moves}";
        }

        private void OnLose()
        {
            StartCoroutine(CallDelayed(() =>
            {
                _canvas.ChanSerSvr<LoseVttSvr, GamePayload>(new GamePayload
                {
                    Score = _gField.Scrtg,
                    SelectedLevel = _payload.SelectedLevel
                });
            }));
        }

        private void OnScCnn(int score)
        {
            // scoreText.text = $"Score:\n{score}";
            scoreText.text = $"{TextFormatter.FormatScore(score)}";
        }

        private void OnTmChn(int time)
        {
            timeText.text = $"TIME: {TextFormatter.FormatTime(time)}";
        }

        private IEnumerator CallDelayed(Action callback)
        {
            yield return new WaitForSeconds(1f);
            
            callback.Invoke();
        }
    }

    public class GamePayload
    {
        public int SelectedLevel;
        public int Score;
    }
}