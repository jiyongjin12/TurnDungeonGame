using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroupManager : MonoBehaviour
{
    //public GameObject[] objects = new GameObject[4]; // 4���� ������Ʈ�� �迭�� ����

    //private Vector3[] positions = new Vector3[4] {
    //    new Vector3(-3f, 0.67f, 0f),
    //    new Vector3(-4.5f, 0.67f, 0f),
    //    new Vector3(-6f, 0.67f, 0f),
    //    new Vector3(-7.5f, 0.67f, 0f)
    //};

    //void Start()
    //{
    //    // �ʱ� ��ġ ����
    //    UpdateObjectPositions();
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartCoroutine(MoveObjects(1, 3)); // 1���� 3������
    //    }
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        StartCoroutine(MoveObjects(4, 1)); // 3���� 1������
    //    }
    //}

    //IEnumerator MoveObjects(int from, int to)
    //{
    //    from -= 1; // 1-based index to 0-based index
    //    to -= 1;   // 1-based index to 0-based index


    //    if (from < 0 || from >= objects.Length || to < 0 || to >= objects.Length || from == to)
    //    {
    //        yield break;
    //    }

    //    // Perform the swap in the array
    //    GameObject tempObject = objects[from];
    //    if (from < to)
    //    {
    //        for (int i = from; i < to; i++)
    //        {
    //            objects[i] = objects[i + 1];
    //        }
    //    }
    //    else
    //    {
    //        for (int i = from; i > to; i--)
    //        {
    //            objects[i] = objects[i - 1];
    //        }
    //    }
    //    objects[to] = tempObject;

    //    // Set end positions according to the new order
    //    Vector3[] endPositions = new Vector3[objects.Length];
    //    for (int i = 0; i < objects.Length; i++)
    //    {
    //        endPositions[i] = positions[System.Array.IndexOf(objects, objects[i])];
    //    }

    //    float duration = 0.5f; // Duration for the animation


    //    // Animate the movement using DOTween
    //    for (int i = 0; i < objects.Length; i++)
    //    {
    //        objects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
    //    }

    //    // Wait for the duration of the animation
    //    yield return new WaitForSeconds(duration);

    //    Debug.Log(objects[0]);

    //}

    //void UpdateObjectPositions()
    //{
    //    // Update object positions to their initial state
    //    for (int i = 0; i < objects.Length; i++)
    //    {
    //        objects[i].transform.position = positions[i];
    //    }
    //}


    public GameObject[] objects = new GameObject[4]; // 4���� ������Ʈ�� �迭�� ����

    private Vector3[] positions = new Vector3[4] {
        new Vector3(-3f, 0.67f, 0f),
        new Vector3(-4.5f, 0.67f, 0f),
        new Vector3(-6f, 0.67f, 0f),
        new Vector3(-7.5f, 0.67f, 0f)
    };

    private List<GameObject> initialObjects; // �ʱ� ���¸� ������ ����Ʈ
    private bool isReordering = false; // ������ ������ Ȯ���ϴ� �÷���

    void Start()
    {
        // �ʱ� ���¸� ����Ʈ�� ����
        initialObjects = new List<GameObject>(objects);
        // �ʱ� ��ġ ����
        UpdateObjectPositions();
    }

    void Update()
    {
        // ���� �迭�� �ʱ� �迭�� ���Ͽ� ���� ������ �ִ��� Ȯ��
        if (CheckIfObjectsChanged())
        {
            // ���� ������ �ְ� ���� ������ ���� �ƴϸ� �ڷ�ƾ ����
            if (!isReordering)
            {
                StartCoroutine(ReorderObjects());
            }
        }

        // E Ű �Է� �� 1�� ������Ʈ�� 3�� ��ġ�� �̵�
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveObjects(1, 3));
        }
        // Q Ű �Է� �� 3�� ������Ʈ�� 1�� ��ġ�� �̵�
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(MoveObjects(4, 1));
        }
    }

    IEnumerator MoveObjects(int from, int to)
    {
        from -= 1;
        to -= 1;

        Debug.Log($"MoveObjects called with from={from + 1}, to={to + 1}");

        // ��ȿ���� ���� �ε����� ��� ���� ����� ��ȿ�� �ε����� ����
        from = GetValidIndex(from);
        to = GetValidIndex(to);

        // ��ȿ�� �ε��� ������ �ִ��� Ȯ��
        if (from == to || from == -1 || to == -1)
        {
            yield break;
        }

        // �迭���� ������Ʈ ������ ��ü
        GameObject tempObject = objects[from];
        if (from < to)
        {
            for (int i = from; i < to; i++)
            {
                objects[i] = objects[i + 1];
            }
        }
        else
        {
            for (int i = from; i > to; i--)
            {
                objects[i] = objects[i - 1];
            }
        }
        objects[to] = tempObject;

        // ���ο� ������ ���� �� ��ġ ����
        Vector3[] endPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null && objects[i].activeSelf)
            {
                endPositions[i] = positions[i];
            }
        }

        float duration = 0.5f; // �ִϸ��̼� ���� �ð�

        // DOTween�� ����Ͽ� �̵� �ִϸ��̼� ����
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null && objects[i].activeSelf) // Ȱ��ȭ�� ������Ʈ�� �ִϸ��̼� ����
            {
                objects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
            }
        }

        // �ִϸ��̼� ���� �ð� ���� ���
        yield return new WaitForSeconds(duration);
    }

    void UpdateObjectPositions()
    {
        // ������Ʈ�� �ʱ� ��ġ�� ������Ʈ
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                objects[i].transform.position = positions[i];
            }
        }
    }

    bool CheckIfObjectsChanged()
    {
        // ���� �迭�� ���¸� ������ �ӽ� ����Ʈ
        List<GameObject> currentObjects = new List<GameObject>();

        // Ȱ��ȭ�� ������Ʈ�� �ӽ� ����Ʈ�� �߰�
        foreach (var obj in objects)
        {
            if (obj != null && obj.activeSelf)
            {
                currentObjects.Add(obj);
            }
        }

        // ���� ������ �ִ��� Ȯ��
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

    IEnumerator ReorderObjects()
    {
        isReordering = true; // ������ ����

        // ���ŵ� ������Ʈ�� ������ �ӽ� ����Ʈ ����
        List<GameObject> updatedObjects = new List<GameObject>();

        // Ȱ��ȭ�� ������Ʈ�� �ӽ� ����Ʈ�� �߰�
        foreach (var obj in objects)
        {
            if (obj != null && obj.activeSelf)
            {
                updatedObjects.Add(obj);
            }
        }

        // Null �Ǵ� ��Ȱ��ȭ�� ������Ʈ�� ����
        objects = updatedObjects.ToArray();

        // Ȱ��ȭ�� ������Ʈ�� ��ġ ������Ʈ
        Vector3[] endPositions = new Vector3[updatedObjects.Count];
        for (int i = 0; i < updatedObjects.Count; i++)
        {
            endPositions[i] = positions[i];
        }

        float duration = 0.5f; // �ִϸ��̼� ���� �ð�

        // DOTween�� ����Ͽ� �̵� �ִϸ��̼� ����
        for (int i = 0; i < updatedObjects.Count; i++)
        {
            updatedObjects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
        }

        // �ִϸ��̼� ���� �ð� ���� ���
        yield return new WaitForSeconds(duration);

        isReordering = false; // ������ ����
    }

    int GetValidIndex(int index)
    {
        // ��ȿ�� �ε��� ���� ������ Ȯ��
        if (index < 0 || index >= objects.Length || objects[index] == null || !objects[index].activeSelf)
        {
            // ��ȿ���� ������ ���� ����� ��ȿ�� �ε��� ã��
            int closestIndex = -1;
            float closestDistance = float.MaxValue;

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null && objects[i].activeSelf)
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
