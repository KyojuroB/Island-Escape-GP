using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerRang : MonoBehaviour
{
    public List<GameObject> itemsInRange = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < itemsInRange.Count; i++)
        {
            if (itemsInRange[i] != null)
            {
                if (itemsInRange[i].CompareTag("PickUpItem"))
                {
                    //  itemsInRange[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }    

        }
    }

    // Update is called once per frame
    void Update()
    {
        InteractAttempt();
        itemsInRange.RemoveAll(obj => obj == null);
    }
  

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!itemsInRange.Contains(collider.gameObject) && GameObject.FindGameObjectWithTag("PickUpItem"))
        {
            itemsInRange.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (itemsInRange.Contains(collider.gameObject))
        {
           // itemsInRange.Find(collider.gameObject).GetComponent<Image>().color = Color.red; 
            itemsInRange.Remove(collider.gameObject);
        }
    }

    public void InteractAttempt()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemsInRange.Count != 0)
            {
                if (itemsInRange.Find(obj => obj.GetComponent<ID>() != null))
                {
                    Debug.Log("addToInv");

                    GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().AddItem(itemsInRange[0].GetComponent<ID>().GetIcon(), itemsInRange[0].GetComponent<ID>().GetItemID(), itemsInRange[0].GetComponent<ID>().Holdable());
                    Destroy(itemsInRange[0], 0.1f);

                }
                else if (itemsInRange.Any(item => item.CompareTag("Motor")) || itemsInRange.Any(item => item.CompareTag("Blade")) || itemsInRange.Any(item => item.CompareTag("Wires")))
                {
             
                    if(itemsInRange.Any(item => item.CompareTag("Motor")))
                    {
                        
                        GameObject.FindGameObjectWithTag("FinalList").GetComponent<List>().ItemFound(2);
                        Destroy(GameObject.FindGameObjectWithTag("Motor"));
                    }
                    else if (itemsInRange.Any(item => item.CompareTag("Blade")))
                    {
                        GameObject.FindGameObjectWithTag("FinalList").GetComponent<List>().ItemFound(0);
                        Destroy(GameObject.FindGameObjectWithTag("Blade"));
                    }
                    else if (itemsInRange.Any(item => item.CompareTag("Wires")))
                    {
                        GameObject.FindGameObjectWithTag("FinalList").GetComponent<List>().ItemFound(1);
                        Destroy(GameObject.FindGameObjectWithTag("Wires"));

                    }






                }
               
            }
        }
    }
}
