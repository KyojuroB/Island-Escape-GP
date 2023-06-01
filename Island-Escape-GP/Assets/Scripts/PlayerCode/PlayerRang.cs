using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRang : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractAttempt();
        itemsInRange.RemoveAll(GameObject => GameObject == null);
    }
    public List<GameObject> itemsInRange = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!itemsInRange.Contains(collider.gameObject) && GameObject.FindGameObjectWithTag("PickUpItem"))
        {
            itemsInRange.Add(collider.gameObject);
            Debug.Log("Added " + gameObject.name);
            Debug.Log("GameObjects in list: " + itemsInRange.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (itemsInRange.Contains(collider.gameObject))
        {
            itemsInRange.Remove(collider.gameObject);
            Debug.Log("Removed " + gameObject.name);
            Debug.Log("GameObjects in list: " + itemsInRange.Count);

        }
    }

    public void InteractAttempt()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemsInRange.Count != 0)
            {
                if(itemsInRange.Find(obj => obj.GetComponent<ID>() != null))
                { 
                    Debug.Log("addToInv");
                    
                    GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().AddItem(itemsInRange[0].GetComponent<ID>().GetIcon(), itemsInRange[0].GetComponent<ID>().GetItemID(), itemsInRange[0].GetComponent<ID>().Holdable());
                    Destroy(itemsInRange[0],0.1f);
                }
               
            }
        }
    }
}
