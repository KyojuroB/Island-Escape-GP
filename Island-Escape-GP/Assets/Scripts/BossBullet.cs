using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }


    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }





}
