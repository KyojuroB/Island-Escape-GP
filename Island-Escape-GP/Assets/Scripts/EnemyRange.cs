using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    bool isInRange = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
    

    public bool IsInRange()
    { 
        return isInRange;
    }



}

