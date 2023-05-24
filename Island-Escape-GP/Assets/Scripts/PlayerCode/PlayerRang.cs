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
        
    }
    public List<GameObject> itemsInRange = new List<GameObject>();
    public void OnTriggerEnter(Collider collider)
    {
        if (!itemsInRange.Contains(collider.gameObject) && GameObject.FindGameObjectWithTag("PickUpItem"))
        {
            itemsInRange.Add(collider.gameObject);
            Debug.Log("Added " + gameObject.name);
            Debug.Log("GameObjects in list: " + itemsInRange.Count);
        }
    }

    public void OnTriggerExit(Collider collider)
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
            if (itemsInRange.Count > 1)
            {

            }
        }
    }
}
