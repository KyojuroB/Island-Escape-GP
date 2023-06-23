using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkAround : MonoBehaviour
{
    [SerializeField] float moveSpeed = 72.7f;
    private bool isActive = false;
    private Vector3 previousPosition;
    Animator animator;
    [SerializeField] bool animate = true;
    int changeX;
    int changeY;

    private void Start()
    {
        StartCoroutine(Walk());
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (animate)
        {
            if (changeX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (changeX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

                    Vector3 currentPosition = transform.position;

            float distance = Vector3.Distance(previousPosition, currentPosition);

            if (distance > 0.01)
            {
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }

            previousPosition = currentPosition;
        }

    }





    private IEnumerator Walk()
    {
        isActive = true;

         changeX = Random.Range(-50, 50);
         changeY = Random.Range(-59, 50);

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