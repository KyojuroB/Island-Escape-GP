using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleEnemyRangeIGuess : MonoBehaviour
{

    public float moveSpeed;
    public Transform playerMabye;
    public Transform gun;
    public Transform shotPoint;
    public GameObject enemyProjectil;
    public float followPlayerRange;
    public bool inRange;
    public float timeBtwnShots;
    public float AttackRange;
    public float startTimebtwnShots;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = playerMabye.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f,rotZ);

        if (Vector2.Distance(transform.position, playerMabye.position) <= followPlayerRange && Vector2.Distance(transform.position, playerMabye.position) > AttackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    
   
    
       if(Vector2.Distance(transform.position, playerMabye.position) <= AttackRange)
        {
            if(timeBtwnShots<= 0)
            {
                Instantiate(enemyProjectil, shotPoint.position, shotPoint.transform.rotation);
                timeBtwnShots = startTimebtwnShots;
            }
        
            else
            {
                timeBtwnShots -= Time.deltaTime;
            }
        
        
        
        }
    
    
    }

    private void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position,playerMabye.position, moveSpeed*Time.deltaTime);
        }



    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlayerRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

}
