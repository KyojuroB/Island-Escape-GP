using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AllEntities : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject drops;
    bool died = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (health <= 0)
        {

            if (drops != null && !died )
            { 
                Instantiate(drops, transform.position, Quaternion.identity);
                died = true;
            }
            
            Destroy(gameObject, 0.5f);
        }
    }
    public void TakeAwayHealth(int damage)
    { 
     health -= damage;

     StartCoroutine(damageColor());

    }

    IEnumerator damageColor()
    { 
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.35f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
