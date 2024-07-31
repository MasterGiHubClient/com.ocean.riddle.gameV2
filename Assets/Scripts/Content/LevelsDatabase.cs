using Entities;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelsDatabase", fileName = "Level Database")]
    public class LevelsDatabase : ScriptableObject
    {
        [field: SerializeField] public GField[] GameFields { get; private set; }
    }
}