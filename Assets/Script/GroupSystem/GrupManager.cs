using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrupManager : MonoBehaviour
{
    //public GameObject[] Characters = new GameObject[4]; 

    //private List<GameObject> initialObjects; // �ʱ� ���� ���� ����Ʈ
    //private bool isReordering = false; // ������ ������ Ȯ��

    //private Vector3[] positions = new Vector3[4] 
    //{
    //    new Vector3(-3f, 0.67f, 0f),   // 1��
    //    new Vector3(-4.5f, 0.67f, 0f),
    //    new Vector3(-6f, 0.67f, 0f),
    //    new Vector3(-7.5f, 0.67f, 0f)  // 4��
    //};

    //public Group group;
    //public enum Group
    //{
    //    Players,
    //    Enemies
    //};

    //private void Start()
    //{
    //    // �ʱ� ���¸� ����Ʈ�� ����
    //    initialObjects = new List<GameObject>(Characters);
    //    // �ʱ� ��ġ ����
    //    UpdateObjectPos();
    //}

    //private void Update()
    //{
    //    // �Ʊ��� ����� - �迭 ������
    //    if (CheckIfObjectsChanged())
    //    {
    //        if (!isReordering)
    //        {
    //            StartCoroutine(ReorderObjects());
    //        }
    //    }


    //    // 1���� 3����
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartCoroutine(MoveObjects(1, 3));
    //    }
    //    // 4���� 1������
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        StartCoroutine(MoveObjects(4, 1));
    //    }
    //}

    //// from���� to�� ��ġ�ų� ���ų�
    //public IEnumerator MoveObjects(int from, int to)
    //{
    //    from -= 1;
    //    to -= 1;

    //    // ��ȿ���� ���� �ε����� ��� ���� ����� ��ȿ�� �ε����� ����
    //    from = GetValidIndex(from);
    //    to = GetValidIndex(to);

    //    // ��ȿ�� �ε��� ������ �ִ��� Ȯ��
    //    if (from == to || from == -1 || to == -1)
    //    {
    //        yield break;
    //    }

    //    // �迭���� ������Ʈ ������ ��ü
    //    GameObject tempObject = Characters[from];
    //    if (from < to)
    //    {
    //        for (int i = from; i < to; i++)
    //        {
    //            Characters[i] = Characters[i + 1];
    //        }
    //    }
    //    else
    //    {
    //        for (int i = from; i > to; i--)
    //        {
    //            Characters[i] = Characters[i - 1];
    //        }
    //    }
    //    Characters[to] = tempObject;

    //    // ���ο� ������ ���� �� ��ġ ����
    //    Vector3[] endPositions = new Vector3[Characters.Length];
    //    for (int i = 0; i < Characters.Length; i++)
    //    {
    //        if (Characters[i] != null && Characters[i].activeSelf)
    //        {
    //            endPositions[i] = positions[i];
    //        }
    //    }

    //    float duration = 0.5f; // �ִϸ��̼� ���� �ð�

    //    // DOTween�� ����Ͽ� �̵� �ִϸ��̼� ����
    //    for (int i = 0; i < Characters.Length; i++)
    //    {
    //        if (Characters[i] != null && Characters[i].activeSelf) // Ȱ��ȭ�� ������Ʈ�� �ִϸ��̼� ����
    //        {
    //            Characters[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
    //        }
    //    }

    //    // �ִϸ��̼� ���� �ð� ���� ���
    //    yield return new WaitForSeconds(duration);
    //}

    //// �ʹ� ��ġ �¾�
    //private void UpdateObjectPos()
    //{
    //    for (int i = 0; i < Characters.Length; i++)
    //    {
    //        if (Characters[i] != null)
    //        {
    //            Characters[i].transform.position = positions[i];
    //        }
    //    }
    //}

    //// �Ʊ��� �װų� ����������
    //private bool CheckIfObjectsChanged()
    //{
    //    // ���� �迭�� ���¸� ������ �ӽ� ����Ʈ
    //    List<GameObject> currentObjects = new List<GameObject>();

    //    // Ȱ��ȭ�� ������Ʈ�� �ӽ� ����Ʈ�� �߰�
    //    foreach (var obj in Characters)
    //    {
    //        if (obj != null && obj.activeSelf)
    //        {
    //            currentObjects.Add(obj);
    //        }
    //    }

    //    // ���� ���� Ȯ��
    //    bool changed = currentObjects.Count != initialObjects.Count;

    //    for (int i = 0; !changed && i < initialObjects.Count; i++)
    //    {
    //        if (i >= currentObjects.Count || initialObjects[i] != currentObjects[i])
    //        {
    //            changed = true;
    //        }
    //    }

    //    if (changed)
    //    {
    //        initialObjects = new List<GameObject>(currentObjects); // ���� ������Ʈ
    //    }

    //    return changed;
    //}

    //// ������ �迭 ���� �� ������
    //private IEnumerator ReorderObjects()
    //{
    //    isReordering = true; // ������ 

    //    List<GameObject> updatedObjects = new List<GameObject>();

    //    // Ȱ��ȭ ������Ʈ�� �ӽ� ����Ʈ �߰�
    //    foreach (var obj in Characters)
    //    {
    //        if (obj != null && obj.activeSelf)
    //        {
    //            updatedObjects.Add(obj);
    //        }
    //    }

    //    // ��Ȱ��ȭ ������Ʈ�� ����
    //    Characters = updatedObjects.ToArray();

    //    // Ȱ��ȭ�� ������Ʈ�� ��ġ ������Ʈ
    //    Vector3[] endPositions = new Vector3[updatedObjects.Count];
    //    for (int i = 0; i < updatedObjects.Count; i++)
    //    {
    //        endPositions[i] = positions[i];
    //    }

    //    float duration = 0.5f; // �̵� �ð�

    //    // �̵�
    //    for (int i = 0; i < updatedObjects.Count; i++)
    //    {
    //        updatedObjects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
    //    }

    //    // �̵� �ð� ��ٸ���
    //    yield return new WaitForSeconds(duration);

    //    isReordering = false; // ������ ����
    //}

    //// �а� ���°� �迭�� �Ѿ����
    //private int GetValidIndex(int index)
    //{
    //    // �迭��ȣ ���� ������ Ȯ��
    //    if (index < 0 || index >= Characters.Length || Characters[index] == null || !Characters[index].activeSelf)
    //    {
    //        // ���� ���̸� ���� ����� ��ȿ�� �ε��� ã��
    //        int closestIndex = -1;
    //        float closestDistance = float.MaxValue;

    //        for (int i = 0; i < Characters.Length; i++)
    //        {
    //            if (Characters[i] != null && Characters[i].activeSelf)
    //            {
    //                float distance = Mathf.Abs(i - index);
    //                if (distance < closestDistance)
    //                {
    //                    closestDistance = distance;
    //                    closestIndex = i;
    //                }
    //            }
    //        }
    //        return closestIndex;
    //    }

    //    return index;
    //}


    public Group group;

    public GameObject[] Characters = new GameObject[4];
    public GameObject[] Enemies = new GameObject[4];

    private List<GameObject> initialObjects; // �ʱ� ���� ����
    private bool isReordering = false; // ������ Ȯ��

    private static readonly Vector3[] P_positions = new Vector3[4]
    {
        new Vector3(-3f, 0.67f, 0f),   // 1��
        new Vector3(-4.5f, 0.67f, 0f),
        new Vector3(-6f, 0.67f, 0f),
        new Vector3(-7.5f, 0.67f, 0f)  // 4��
    };

    private static readonly Vector3[] E_positions = new Vector3[4]
    {
        new Vector3(3f, 0.67f, 0f),   // 1��
        new Vector3(4.5f, 0.67f, 0f),
        new Vector3(6f, 0.67f, 0f),
        new Vector3(7.5f, 0.67f, 0f)  // 4��
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

        if (Input.GetKeyDown(KeyCode.E)) // 1���� 3���� �б�
        {
            StartCoroutine(MoveObjects(1, 3));
        }
        if (Input.GetKeyDown(KeyCode.Q)) // 4���� 1�� ���̱�
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
            initialObjects = new List<GameObject>(currentObjects); // ���� ������Ʈ
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

    // �а� ���°� �迭�� �Ѿ����
    private int GetValidIndex(int index, GameObject[] groupArray)
    {
        // ���� ������ Ȯ��
        if (index < 0 || index >= groupArray.Length || groupArray[index] == null || !groupArray[index].activeSelf)
        {
            int closestIndex = -1;
            float closestDistance = float.MaxValue;

            //���� ����� �ε��� ã��
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
