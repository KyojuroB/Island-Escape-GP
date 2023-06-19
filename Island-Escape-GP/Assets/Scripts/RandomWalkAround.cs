using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkAround : MonoBehaviour
{
    [SerializeField] float moveSpeed = 72.7f;
    private bool isActive = false;

    private void Start()
    {
        StartCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        isActive = true;

        int changeX = Random.Range(-50, 50);
        int changeY = Random.Range(-59, 50);

        Vector3 targetPosition = new Vector3(transform.position.x + changeX, transform.position.y + changeY, 0);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isActive = false;

        yield return new WaitForSeconds(Random.Range(2f, 8f));

        if (!isActive)
        {
            StartCoroutine(Walk());
        }
    }
}