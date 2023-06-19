using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Loot : MonoBehaviour
{

    [SerializeField] bool playerInRange = false;
    [SerializeField] List<GameObject> loot;
    [SerializeField] List<int> ammount;
    [SerializeField] int max = 3;
    [SerializeField] int min = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < loot.Count; i++)
        {
            ammount.Add(Random.Range(min, max + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        ActionLoot();
    }

    private void ActionLoot()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("chestopen");

            Destroy(transform.GetChild(0).gameObject);

            for (int i = 0; i < loot.Count; i++)
            {
                for (int x = 0; x < ammount[i]; x++)
                {
                    Instantiate(loot[i], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }

               
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In");
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("out");
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
