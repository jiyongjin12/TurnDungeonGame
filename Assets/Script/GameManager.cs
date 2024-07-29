using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DownloadCharacterData());
    }


    #region 스크립터블 오브젝트

    [SerializeField] CharacterData characterData;
    const string URL = "https://docs.google.com/spreadsheets/d/1VQjB5RHN0Vu5o6xa2k4J7zgbCF710WJUpHJa2Y-huuo/export?format=tsv&range=A2:D";

    IEnumerator DownloadCharacterData()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        SetCharacterSO(www.downloadHandler.text);
    }

    void SetCharacterSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                CharacterStats Character = characterData.characterStatsList[i];

                Character.name = column[0];
                Character.hp = int.Parse(column[1]);
                Character.speed = int.Parse(column[2]);
                Character.Damage = int.Parse(column[3]);

            }
        }
    }


    #endregion
}
