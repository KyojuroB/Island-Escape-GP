using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatorthinger : MonoBehaviour
{
    Animator animator;
    public bool isMoving = false;
    Vector3 previousPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("chigling niglers");
    }
    void Update()
    {

        Animation();
    }
    private void Animation()
    {
        //isMoving = GetComponent<Rigidbody2D>().velocity.magnitude > 0.09f;
        Vector3 currentPosition = transform.position; 
        float distance = Vector3.Distance(previousPosition, currentPosition);

        if (distance > 0.01)
        {
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        previousPosition = currentPosition;




    }
}
