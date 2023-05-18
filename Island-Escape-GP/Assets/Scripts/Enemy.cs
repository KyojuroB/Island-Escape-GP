using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] float speed = 3f;
    GameObject player;
    bool isInRange;
    GameObject range;
    void Start()
    {
         range = transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        MoveTowards();
          
    }

    



    private void MoveTowards()
    {
        if (range.GetComponent<EnemyRange>().IsInRange() == true)
        {
            Vector2 target = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.position = target;
        }
    }    
   
}
