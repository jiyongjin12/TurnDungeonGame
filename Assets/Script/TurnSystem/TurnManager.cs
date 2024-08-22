using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //[SerializeField] private CharacterStatus[] players = new CharacterStatus[4];
    //[SerializeField] private EnemyStatus[] enemies = new EnemyStatus[4];

    [SerializeField] private SpeedTest[] sequenceSpeed = new SpeedTest[8];
    [SerializeField] private SpeedTest[] turnSequence; // speed에 따라 정렬된 순서대로 저장할 배열

    private void Start()
    {
        StartCoroutine(SequenceSetting());

    }

    public IEnumerator SequenceSetting() // 순서 세팅
    {
        yield return new WaitForSeconds(.5f);

        // speed 값을 기준으로 내림차순 정렬
        turnSequence = sequenceSpeed.OrderByDescending(character => character.speed).ToArray();

        // 1부터 할당
        for (int i = 0; i < turnSequence.Length; i++)
        {
            turnSequence[i].sequence = i + 1; // 1부터 시작
        }

        // 정렬된 결과를 출력해봅니다.
        foreach (var character in turnSequence)
        {
            Debug.Log($"{character.name} with Speed: {character.speed}");
        }
    }

}
