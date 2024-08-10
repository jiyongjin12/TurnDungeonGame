using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "StatusData/Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    public List<Stats> characterStatsList = new List<Stats>();
}
