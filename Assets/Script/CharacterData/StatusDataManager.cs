using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StatusDataManager : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    const string CrURL = "https://docs.google.com/spreadsheets/d/1VQjB5RHN0Vu5o6xa2k4J7zgbCF710WJUpHJa2Y-huuo/export?format=tsv&range=A2:J";

    [SerializeField] private EnemyData enemyData;
    const string EnURL = "https://docs.google.com/spreadsheets/d/1VQjB5RHN0Vu5o6xa2k4J7zgbCF710WJUpHJa2Y-huuo/export?format=tsv&gid=682900903&range=A2:J";

    private void Awake()
    {
        StartCoroutine(DownloadCharacterData());
        StartCoroutine(DownloadEnemyData());
    }


    private IEnumerator DownloadCharacterData()
    {
        UnityWebRequest player = UnityWebRequest.Get(CrURL);
        yield return player.SendWebRequest();
        SetCharacterSO(player.downloadHandler.text);
    }

    private IEnumerator DownloadEnemyData()
    {
        UnityWebRequest enemy = UnityWebRequest.Get(EnURL);
        yield return enemy.SendWebRequest();
        SetEnemySO(enemy.downloadHandler.text);
    }

    private void SetCharacterSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                Stats Character = characterData.characterStatsList[i];

                Character.name = column[0];
                Character.hp = int.Parse(column[1]);
                Character.speed = int.Parse(column[2]);
                Character.damage = int.Parse(column[3]);

                Character.critical = int.Parse(column[4]);
                Character.accuracy = int.Parse(column[5]);
                Character.resistance = int.Parse(column[6]);
                Character.defense = int.Parse(column[7]);
                Character.avoidance = int.Parse(column[8]);
                Character.mental = int.Parse(column[9]);

            }
        }
    }

    private void SetEnemySO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                Stats Character = enemyData.characterStatsList[i];

                Character.name = column[0];
                Character.hp = int.Parse(column[1]);
                Character.speed = int.Parse(column[2]);
                Character.damage = int.Parse(column[3]);

                Character.critical = int.Parse(column[4]);
                Character.accuracy = int.Parse(column[5]);
                Character.resistance = int.Parse(column[6]);
                Character.defense = int.Parse(column[7]);
                Character.avoidance = int.Parse(column[8]);
                Character.mental = int.Parse(column[9]);

            }
        }
    }
}
