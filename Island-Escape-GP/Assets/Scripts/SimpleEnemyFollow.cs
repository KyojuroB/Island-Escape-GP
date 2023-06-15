using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Audio;

public class SimpleEnemyFollow : MonoBehaviour
{
    public float movespeed = 5f;
    
    GameObject Player;
    public Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 EnemyMovement;
    bool inRange;
    // Start is called before the first frame update


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
   
    

    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        EnemyMovement = direction;


    }
    private void FixedUpdate()
    {
        moveCharectar(EnemyMovement);
    }
    void moveCharectar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
        
}
