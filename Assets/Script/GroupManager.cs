using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroupManager : MonoBehaviour
{
    //public GameObject[] objects = new GameObject[4]; // 4개의 오브젝트를 배열로 받음

    //private Vector3[] positions = new Vector3[4] {
    //    new Vector3(-3f, 0.67f, 0f),
    //    new Vector3(-4.5f, 0.67f, 0f),
    //    new Vector3(-6f, 0.67f, 0f),
    //    new Vector3(-7.5f, 0.67f, 0f)
    //};

    //void Start()
    //{
    //    // 초기 위치 설정
    //    UpdateObjectPositions();
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartCoroutine(MoveObjects(1, 3)); // 1번이 3번으로
    //    }
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        StartCoroutine(MoveObjects(4, 1)); // 3번이 1번으로
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


    public GameObject[] objects = new GameObject[4]; // 4개의 오브젝트를 배열로 받음

    private Vector3[] positions = new Vector3[4] {
        new Vector3(-3f, 0.67f, 0f),
        new Vector3(-4.5f, 0.67f, 0f),
        new Vector3(-6f, 0.67f, 0f),
        new Vector3(-7.5f, 0.67f, 0f)
    };

    private List<GameObject> initialObjects; // 초기 상태를 저장할 리스트
    private bool isReordering = false; // 재정렬 중인지 확인하는 플래그

    void Start()
    {
        // 초기 상태를 리스트에 저장
        initialObjects = new List<GameObject>(objects);
        // 초기 위치 설정
        UpdateObjectPositions();
    }

    void Update()
    {
        // 현재 배열과 초기 배열을 비교하여 변경 사항이 있는지 확인
        if (CheckIfObjectsChanged())
        {
            // 변경 사항이 있고 현재 재정렬 중이 아니면 코루틴 실행
            if (!isReordering)
            {
                StartCoroutine(ReorderObjects());
            }
        }

        // E 키 입력 시 1번 오브젝트를 3번 위치로 이동
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveObjects(1, 3));
        }
        // Q 키 입력 시 3번 오브젝트를 1번 위치로 이동
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

        // 유효하지 않은 인덱스일 경우 가장 가까운 유효한 인덱스로 조정
        from = GetValidIndex(from);
        to = GetValidIndex(to);

        // 유효한 인덱스 범위에 있는지 확인
        if (from == to || from == -1 || to == -1)
        {
            yield break;
        }

        // 배열에서 오브젝트 순서를 교체
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

        // 새로운 순서에 따라 끝 위치 설정
        Vector3[] endPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null && objects[i].activeSelf)
            {
                endPositions[i] = positions[i];
            }
        }

        float duration = 0.5f; // 애니메이션 지속 시간

        // DOTween을 사용하여 이동 애니메이션 적용
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null && objects[i].activeSelf) // 활성화된 오브젝트만 애니메이션 적용
            {
                objects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
            }
        }

        // 애니메이션 지속 시간 동안 대기
        yield return new WaitForSeconds(duration);
    }

    void UpdateObjectPositions()
    {
        // 오브젝트를 초기 위치로 업데이트
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
        // 현재 배열의 상태를 저장할 임시 리스트
        List<GameObject> currentObjects = new List<GameObject>();

        // 활성화된 오브젝트만 임시 리스트에 추가
        foreach (var obj in objects)
        {
            if (obj != null && obj.activeSelf)
            {
                currentObjects.Add(obj);
            }
        }

        // 변경 사항이 있는지 확인
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

    IEnumerator ReorderObjects()
    {
        isReordering = true; // 재정렬 시작

        // 갱신된 오브젝트를 저장할 임시 리스트 생성
        List<GameObject> updatedObjects = new List<GameObject>();

        // 활성화된 오브젝트만 임시 리스트에 추가
        foreach (var obj in objects)
        {
            if (obj != null && obj.activeSelf)
            {
                updatedObjects.Add(obj);
            }
        }

        // Null 또는 비활성화된 오브젝트를 제거
        objects = updatedObjects.ToArray();

        // 활성화된 오브젝트의 위치 업데이트
        Vector3[] endPositions = new Vector3[updatedObjects.Count];
        for (int i = 0; i < updatedObjects.Count; i++)
        {
            endPositions[i] = positions[i];
        }

        float duration = 0.5f; // 애니메이션 지속 시간

        // DOTween을 사용하여 이동 애니메이션 적용
        for (int i = 0; i < updatedObjects.Count; i++)
        {
            updatedObjects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
        }

        // 애니메이션 지속 시간 동안 대기
        yield return new WaitForSeconds(duration);

        isReordering = false; // 재정렬 종료
    }

    int GetValidIndex(int index)
    {
        // 유효한 인덱스 범위 내인지 확인
        if (index < 0 || index >= objects.Length || objects[index] == null || !objects[index].activeSelf)
        {
            // 유효하지 않으면 가장 가까운 유효한 인덱스 찾기
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
