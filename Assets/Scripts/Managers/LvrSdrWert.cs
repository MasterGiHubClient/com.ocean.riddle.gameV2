using Content;
using Entities;
using UnityEngine;

namespace Managers
{
    public class LvrSdrWert
    {
        private const string PserSertJey = "PassedLevels";
        private const string SctWerJey = "ScoreKey";
        
        private readonly LevelsDatabase _levelsDatabase;

        public int PswrLevs => PlayerPrefs.GetInt(PserSertJey);

        public int Sctew
        {
            get => PlayerPrefs.GetInt(SctWerJey);
            set => PlayerPrefs.SetInt(SctWerJey, value);
        }

        public int LastLevelIndex => PlayerPrefs.GetInt(PserSertJey) < _levelsDatabase.GameFields.Length
            ? PlayerPrefs.GetInt(PserSertJey)
            : _levelsDatabase.GameFields.Length - 1;
            
        
        public LvrSdrWert(LevelsDatabase levelsDatabase)
        {
            _levelsDatabase = levelsDatabase;

            if (!PlayerPrefs.HasKey(PserSertJey))
            {
                PlayerPrefs.SetInt(PserSertJey, 0);
            }

            if (!PlayerPrefs.HasKey(SctWerJey))
            {
                PlayerPrefs.SetInt(SctWerJey, 0);
            }
        }

        public GField GetSertJety(int index) =>
            _levelsDatabase.GameFields[index];

        public void InerWertSwer(int currentLevel)
        {
            if (currentLevel == PswrLevs)
                PlayerPrefs.SetInt(PserSertJey, PswrLevs + 1);
        }
    }
}