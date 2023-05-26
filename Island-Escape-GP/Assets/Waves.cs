using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    float Xspeed = 5f;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Xspeed, gameObject.transform.position.y);
    }

}
