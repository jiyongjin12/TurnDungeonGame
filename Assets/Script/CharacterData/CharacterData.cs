using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Character Data", order = 1)]
public class CharacterData : ScriptableObject
{
    public List<CharacterStats> characterStatsList = new List<CharacterStats>();
}
