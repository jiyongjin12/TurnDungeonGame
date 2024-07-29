using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroupManager : MonoBehaviour
{
    public GameObject[] objects = new GameObject[4]; // 4개의 오브젝트를 배열로 받음

    private Vector3[] positions = new Vector3[4] {
        new Vector3(-3f, 0.67f, 0f),
        new Vector3(-4.5f, 0.67f, 0f),
        new Vector3(-6f, 0.67f, 0f),
        new Vector3(-7.5f, 0.67f, 0f)
    };

    void Start()
    {
        // 초기 위치 설정
        UpdateObjectPositions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveObjects(1, 3)); // 1번이 3번으로
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(MoveObjects(4, 1)); // 3번이 1번으로
        }
    }

    IEnumerator MoveObjects(int from, int to)
    {
        from -= 1; // 1-based index to 0-based index
        to -= 1;   // 1-based index to 0-based index

        Debug.Log($"MoveObjects called with from={from + 1}, to={to + 1}");

        if (from < 0 || from >= objects.Length || to < 0 || to >= objects.Length || from == to)
        {
            Debug.Log("Invalid indices, exiting coroutine");
            yield break;
        }

        // Perform the swap in the array
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

        // Set end positions according to the new order
        Vector3[] endPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            endPositions[i] = positions[System.Array.IndexOf(objects, objects[i])];
            Debug.Log($"Reassigned end position for object {i + 1}: {endPositions[i]}");
        }

        float duration = 0.5f; // Duration for the animation

        Debug.Log("Starting animation");

        // Animate the movement using DOTween
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.DOMove(endPositions[i], duration).SetEase(Ease.InOutQuad);
            Debug.Log($"Animating object {i + 1} to position {endPositions[i]}");
        }

        // Wait for the duration of the animation
        yield return new WaitForSeconds(duration);

        Debug.Log("Move completed.");
    }

    void UpdateObjectPositions()
    {
        // Update object positions to their initial state
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.position = positions[i];
            Debug.Log($"Initial position for object {i + 1}: {objects[i].transform.position}");
        }
    }
}
