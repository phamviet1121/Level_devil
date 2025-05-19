using System.Collections;
using UnityEngine;

public class trap6 : MonoBehaviour
{
    public GameObject[] objects;        // Các GameObject cần di chuyển
    public GameObject[] positionsA;     // Điểm A tương ứng
    public GameObject[] positionsB;     // Điểm B tương ứng

    public float moveTime = 1f;              // Thời gian di chuyển đến mỗi điểm (t)
    public float intervalTime = 0.5f;        // Thời gian chênh giữa các object (n)
    public float comebackSpeedMultiplier = 0.5f; // Tốc độ gấp khi quay lại (0.5x = nhanh gấp đôi)
    public float loopDelay = 2f;
    public void MoveObjects_Ontrap()
    {
        StartCoroutine(MoveObjects());
    }

    public void MoveObjectscomeback_Ontrap()
    {
        StartCoroutine(MoveObjectscomeback());
    }

    public void MoveObjects_Ontrap_loop()
    {
        StartCoroutine(LoopMoveTrap());
    }
    IEnumerator LoopMoveTrap()
    {
        while (true)
        {
            yield return StartCoroutine(MoveObjects1());              // Đi từ A -> B
            yield return new WaitForSeconds(loopDelay);
            yield return StartCoroutine(MoveObjects());      // Đi từ B -> A
            yield return new WaitForSeconds(loopDelay);
        }
    }


    IEnumerator MoveObjects()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 pointA = positionsA[i].transform.position;
            Vector3 pointB = positionsB[i].transform.position;

            StartCoroutine(MoveToPoints(objects[i].transform, pointA, pointB, moveTime));
            yield return new WaitForSeconds(intervalTime);
        }
    }
    IEnumerator MoveObjects1()
    {
        for (int i = objects.Length - 1; i >= 0; i--)
        {
            Vector3 pointA = positionsA[i].transform.position;
            Vector3 pointB = positionsB[i].transform.position;

            StartCoroutine(MoveToPoints(objects[i].transform, pointA, pointB, moveTime));
            yield return new WaitForSeconds(intervalTime);
        }
    }

    IEnumerator MoveObjectscomeback()
    {
        float originalMoveTime = moveTime;
        float fastTime = moveTime * comebackSpeedMultiplier;

        for (int i = objects.Length - 1; i >= 0; i--)
        {
            Vector3 pointA = positionsA[i].transform.position;
            Vector3 pointB = positionsB[i].transform.position;

            StartCoroutine(MoveToPoints(objects[i].transform, pointA, pointB, fastTime));
            yield return new WaitForSeconds(intervalTime/2);
        }
    }

    IEnumerator MoveToPoints(Transform obj, Vector3 pointA, Vector3 pointB, float customMoveTime)
    {
        yield return MoveTo(obj, pointA, customMoveTime);
        yield return new WaitForSeconds(customMoveTime);
        yield return MoveTo(obj, pointB, customMoveTime);
    }

    IEnumerator MoveTo(Transform obj, Vector3 targetPos, float customMoveTime)
    {
        Vector3 start = obj.position;
        float elapsed = 0f;

        while (elapsed < customMoveTime)
        {
            obj.position = Vector3.Lerp(start, targetPos, elapsed / customMoveTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPos;
    }
}
