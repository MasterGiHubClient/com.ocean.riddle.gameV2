using Entities;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelData", fileName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public GField GFieldPrefab { get; private set; }
    }
}