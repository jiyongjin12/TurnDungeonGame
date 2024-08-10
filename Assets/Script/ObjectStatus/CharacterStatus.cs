using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    public int Num;
    
    [Header("Value(Num)")]
    public string name;
    public int maxHp;
    public int maxSpeed;
    public int maxDamage;
    public int Defense; // 방어
    public int Mental; // 정신력

    [Header("Percentage(%)")]
    public int Critical; // 크리
    public int Accuracy; // 정확도
    public int Resistance; // 저항
    public int Avoidance; // 회피

    private void Start()
    {
        StartSetting();
    }

    private void StartSetting()
    {
        name = characterData.characterStatsList[Num].name;
        maxDamage = characterData.characterStatsList[Num].damage;
        maxHp = characterData.characterStatsList[Num].hp;
        maxSpeed = characterData.characterStatsList[Num].speed;

        Critical = characterData.characterStatsList[Num].critical;
        Accuracy = characterData.characterStatsList[Num].accuracy;
        Resistance = characterData.characterStatsList[Num].resistance;
        Defense = characterData.characterStatsList[Num].defense;
        Avoidance = characterData.characterStatsList[Num].avoidance;
        Mental = characterData.characterStatsList[Num].mental;


        gameObject.name = name;
    } // 스크립터블 오브젝트값 가지고옴


}
