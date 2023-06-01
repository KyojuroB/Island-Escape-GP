using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class AttackRange : MonoBehaviour
{
    public List<GameObject> entitiesInRange = new List<GameObject>();
    [SerializeField] int fistDamage = 10;
    [SerializeField] float FistCoolDown = 0.4f;
    void Start()
    {
        
    }
    void Update()
    {
        attack();
        entitiesInRange.RemoveAll(GameObject => GameObject == null);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!entitiesInRange.Contains(collider.gameObject) && GameObject.FindGameObjectWithTag("PickUpItem"))
        {
            entitiesInRange.Add(collider.gameObject);
            Debug.Log("Added " + gameObject.name + " To Possible attack list");
            Debug.Log("GameObjects in list: " + entitiesInRange.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (entitiesInRange.Contains(collider.gameObject))
        {
            entitiesInRange.Remove(collider.gameObject);
            Debug.Log("Removed " + gameObject.name + " To Possible attack list");
            Debug.Log("GameObjects in list: " + entitiesInRange.Count );
        }
    }


    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (entitiesInRange.Count != 0)
            {
                if (entitiesInRange.Find(obj => obj.GetComponent<AllEntities>() != null))
                {
                    Debug.Log("attack");
                    entitiesInRange[0].GetComponent<AllEntities>().TakeAwayHealth(fistDamage);
                    StartCoroutine(CoolDown());
                }
            }
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(FistCoolDown);
    }
}
