using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject teleportObjLocation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            GameObject.FindGameObjectWithTag("Player").transform.position = teleportObjLocation.transform.position;
        }
    }
}
