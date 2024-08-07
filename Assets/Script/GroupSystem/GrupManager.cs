using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrupManager : MonoBehaviour
{
    //public GameObject[] Characters = new GameObject[4]; 

    //private List<GameObject> initialObjects; // 초기 상태 저장 리스트
    //private bool isReordering = false; // 재정렬 중인지 확인

    //private Vector3[] positions = new Vector3[4] 
    //{
    //    new Vector3(-3f, 0.67f, 0f),   // 1번
    //    new Vector3(-4.5f, 0.67f, 0f),
    //    new Vector3(-6f, 0.67f, 0f),
    //    new Vector3(-7.5f, 0.67f, 0f)  // 4번
    //};

    //public Group group;
    //public enum Group
    //{
    //    Players,
    //    Enemies
    //};

    //private void Start()
    //{
    //    // 초기 상태를 리스트에 저장
    //    initialObjects = new List<GameObject>(Characters);
    //    // 초기 위치 설정
    //    UpdateObjectPos();
    //}

    //private void Update()
    //{
    //    // 아군이 사망시 - 배열 재정렬
    //    if (CheckIfObjectsChanged())
    //    {
    //        if (!isReordering)
    //        {
    //            StartCoroutine(ReorderObjects());
    //        }
    //    }


    //    // 1에서 3으로
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartCoroutine(MoveObjects(1, 3));
    //    }
    //    // 4에서 1ㅇ으로
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        StartCoroutine(MoveObjects(4, 1));
    //    }
    //}

    //// from에서 to로 밀치거나 당기거나
    //public IEnumerator MoveObjects(int from, int to)
    //{
    //    from -= 1;
    //    to -= 1;

    //    // 유효하지 않은 인덱스일 경우 가장 가까운 유효한 인덱스로 조정
    //    from = GetValidIndex(from);
    //    to = GetValidIndex(to);

    //    // 유효한 인덱스 범위에 있는지 확인
    //    if (from == to || from == -1 || to == -1)
    //    {
    //        yield break;
    //    }

    //    // 배열에서 오브젝트 순서를 교체
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

    //    // 새로운 순서에 따라 끝 위치 설정
    //    Vector3[] endPositions = new Vector3[Characters.Length];
    //    for (int i = 0; i < Characters.Length; i++)
    //    {
    //        if (Characters[i] != null && Characters[i].activeSelf)
    //        {
    //            endPositions[i] = positions[i];
    //        }
    //    }

    //    float duration = 0.5f; // 애니메이션 지속 시간

    //    // DOTween을 사용하여 이동 애니메이션 적용
    //    for (int i = 0; i < Characters.Length; i++)
    //    {
    //        if (Characters[i] != null && Characters[i].activeSelf) // 활성화된 오브젝트만 애니메이션 적용
    //        {
    //            Characters[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
    //        }
    //    }

    //    // 애니메이션 지속 시간 동안 대기
    //    yield return new WaitForSeconds(duration);
    //}

    //// 초반 위치 셋업
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

    //// 아군이 죽거나 없어졌을떄
    //private bool CheckIfObjectsChanged()
    //{
    //    // 현재 배열의 상태를 저장할 임시 리스트
    //    List<GameObject> currentObjects = new List<GameObject>();

    //    // 활성화된 오브젝트만 임시 리스트에 추가
    //    foreach (var obj in Characters)
    //    {
    //        if (obj != null && obj.activeSelf)
    //        {
    //            currentObjects.Add(obj);
    //        }
    //    }

    //    // 변경 사항 확인
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
    //        initialObjects = new List<GameObject>(currentObjects); // 상태 업데이트
    //    }

    //    return changed;
    //}

    //// 없어진 배열 제외 후 재정렬
    //private IEnumerator ReorderObjects()
    //{
    //    isReordering = true; // 재정렬 

    //    List<GameObject> updatedObjects = new List<GameObject>();

    //    // 활성화 오브젝트만 임시 리스트 추가
    //    foreach (var obj in Characters)
    //    {
    //        if (obj != null && obj.activeSelf)
    //        {
    //            updatedObjects.Add(obj);
    //        }
    //    }

    //    // 비활성화 오브젝트를 제거
    //    Characters = updatedObjects.ToArray();

    //    // 활성화된 오브젝트의 위치 업데이트
    //    Vector3[] endPositions = new Vector3[updatedObjects.Count];
    //    for (int i = 0; i < updatedObjects.Count; i++)
    //    {
    //        endPositions[i] = positions[i];
    //    }

    //    float duration = 0.5f; // 이동 시간

    //    // 이동
    //    for (int i = 0; i < updatedObjects.Count; i++)
    //    {
    //        updatedObjects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
    //    }

    //    // 이동 시간 기다리기
    //    yield return new WaitForSeconds(duration);

    //    isReordering = false; // 재정렬 종료
    //}

    //// 밀고 당기는거 배열이 넘어갔을떄
    //private int GetValidIndex(int index)
    //{
    //    // 배열번호 범위 내인지 확인
    //    if (index < 0 || index >= Characters.Length || Characters[index] == null || !Characters[index].activeSelf)
    //    {
    //        // 범위 밖이면 가장 가까운 유효한 인덱스 찾기
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

    private List<GameObject> initialObjects; // 초기 상태 저장
    private bool isReordering = false; // 재정렬 확인

    private static readonly Vector3[] P_positions = new Vector3[4]
    {
        new Vector3(-3f, 0.67f, 0f),   // 1번
        new Vector3(-4.5f, 0.67f, 0f),
        new Vector3(-6f, 0.67f, 0f),
        new Vector3(-7.5f, 0.67f, 0f)  // 4번
    };

    private static readonly Vector3[] E_positions = new Vector3[4]
    {
        new Vector3(3f, 0.67f, 0f),   // 1번
        new Vector3(4.5f, 0.67f, 0f),
        new Vector3(6f, 0.67f, 0f),
        new Vector3(7.5f, 0.67f, 0f)  // 4번
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
