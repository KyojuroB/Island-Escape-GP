using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] float speed = 3f;
    GameObject player;
    bool isInRange;
    void Start()
    {
        GameObject Range = transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        MoveTowards();
          
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        Debug.Log("Touch");
        if (obj.gameObject == player)
        {
            Debug.Log("player");
            isInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D obj)
    {
        Debug.Log("leave");

        if (obj.gameObject == player)
        {
            Debug.Log("player leave");

            isInRange = false;
        }
    }



    private void MoveTowards()
    {
        if (isInRange == true)
        {
            Vector2 target = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.position = target;
        }
    }    
   
}
