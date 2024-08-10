using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrupManager : MonoBehaviour
{
    public Group group;

    public GameObject[] Characters = new GameObject[4];
    public GameObject[] Enemies = new GameObject[4];

    private List<GameObject> initialObjects; // 초기 상태 저장
    private bool isReordering = false; // 재정렬 확인

    private static readonly Vector3[] P_positions = new Vector3[4]
    {
        new Vector3(-2f, 0.5f, 0f),   // 1번
        new Vector3(-3.8f, 0.5f, 0f),
        new Vector3(-5.6f, 0.5f, 0f),
        new Vector3(-7.4f, 0.5f, 0f)  // 4번
    };

    private static readonly Vector3[] E_positions = new Vector3[4]
    {
        new Vector3(2f, 0.5f, 0f),   // 1번
        new Vector3(3.8f, 0.5f, 0f),
        new Vector3(5.6f, 0.5f, 0f),
        new Vector3(7.4f, 0.5f, 0f)  // 4번
    };

    public enum Group
    {
        Players,
        Enemies
    }

    private void Start()
    {
        initialObjects = new List<GameObject>();
        initialObjects.AddRange(Characters);
        initialObjects.AddRange(Enemies);

        UpdateObjectPos();
    }

    private void Update()
    {
        if (CheckIfObjectsChanged() && !isReordering)
        {
            StartCoroutine(ReorderObjects());
        }

        if (Input.GetKeyDown(KeyCode.E)) // 1에서 3으로 밀기
        {
            StartCoroutine(MoveObjects(1, 3));
        }
        if (Input.GetKeyDown(KeyCode.Q)) // 4에서 1로 당이기
        {
            StartCoroutine(MoveObjects(4, 1));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SetGroup(Group.Players);
        }
    }

    public void SetGroup(Group newGroup)
    {
        group = newGroup;
        UpdateObjectPos();
    }

    private GameObject[] GetCurrentGroupArray()
    {
        return group == Group.Players ? Characters : Enemies;
    }

    private Vector3[] GetCurrentGroupPositions()
    {
        return group == Group.Players ? P_positions : E_positions;
    }

    public IEnumerator MoveObjects(int from, int to)
    {
        from -= 1;
        to -= 1;

        var currentGroupArray = GetCurrentGroupArray();
        from = GetValidIndex(from, currentGroupArray);
        to = GetValidIndex(to, currentGroupArray);

        if (from == to || from == -1 || to == -1)
        {
            yield break;
        }

        GameObject tempObject = currentGroupArray[from];
        if (from < to)
        {
            for (int i = from; i < to; i++)
            {
                currentGroupArray[i] = currentGroupArray[i + 1];
            }
        }
        else
        {
            for (int i = from; i > to; i--)
            {
                currentGroupArray[i] = currentGroupArray[i - 1];
            }
        }
        currentGroupArray[to] = tempObject;

        Vector3[] positions = GetCurrentGroupPositions();
        for (int i = 0; i < currentGroupArray.Length; i++)
        {
            if (currentGroupArray[i] != null && currentGroupArray[i].activeSelf)
            {
                currentGroupArray[i].transform.DOMove(positions[i], 0.5f).SetEase(Ease.InOutQuad);
            }
        }

        yield return new WaitForSeconds(0.5f);
    }

    private void UpdateObjectPos()
    {
        var currentGroupArray = GetCurrentGroupArray();
        Vector3[] positions = GetCurrentGroupPositions();
        for (int i = 0; i < currentGroupArray.Length; i++)
        {
            if (currentGroupArray[i] != null)
            {
                currentGroupArray[i].transform.position = positions[i];
            }
        }
    }

    private bool CheckIfObjectsChanged()
    {
        List<GameObject> currentObjects = new List<GameObject>();

        foreach (var obj in Characters)
        {
            if (obj != null && obj.activeSelf)
            {
                currentObjects.Add(obj);
            }
        }

        foreach (var obj in Enemies)
        {
            if (obj != null && obj.activeSelf)
            {
                currentObjects.Add(obj);
            }
        }

        bool changed = currentObjects.Count != initialObjects.Count;

        for (int i = 0; !changed && i < initialObjects.Count; i++)
        {
            if (i >= currentObjects.Count || initialObjects[i] != currentObjects[i])
            {
                changed = true;
            }
        }

        if (changed)
        {
            initialObjects = new List<GameObject>(currentObjects); // 상태 업데이트
        }

        return changed;
    }

    private IEnumerator ReorderObjects()
    {
        isReordering = true;

        List<GameObject> updatedPlayerObjects = new List<GameObject>();
        List<GameObject> updatedEnemyObjects = new List<GameObject>();

        foreach (var obj in Characters)
        {
            if (obj != null && obj.activeSelf)
            {
                updatedPlayerObjects.Add(obj);
            }
        }

        foreach (var obj in Enemies)
        {
            if (obj != null && obj.activeSelf)
            {
                updatedEnemyObjects.Add(obj);
            }
        }

        Characters = updatedPlayerObjects.ToArray();
        Enemies = updatedEnemyObjects.ToArray();

        UpdateObjectPositions(updatedPlayerObjects, P_positions);
        UpdateObjectPositions(updatedEnemyObjects, E_positions);

        yield return new WaitForSeconds(0.5f);

        isReordering = false;
    }

    private void UpdateObjectPositions(List<GameObject> objects, Vector3[] positions)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.DOMove(positions[i], 0.5f).SetEase(Ease.InOutQuad);
        }
    }

    // 밀고 당기는거 배열이 넘어갔을떄
    private int GetValidIndex(int index, GameObject[] groupArray)
    {
        // 범위 내인지 확인
        if (index < 0 || index >= groupArray.Length || groupArray[index] == null || !groupArray[index].activeSelf)
        {
            int closestIndex = -1;
            float closestDistance = float.MaxValue;

            //가장 가까운 인덱스 찾기
            for (int i = 0; i < groupArray.Length; i++)
            {
                if (groupArray[i] != null && groupArray[i].activeSelf)
                {
                    float distance = Mathf.Abs(i - index);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestIndex = i;
                    }
                }
            }
            return closestIndex;
        }
        return index;
    }

}
