using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BiomeGnerator : MonoBehaviour
{

    float minX;
    float maxX; 
    float minY; 
    float maxY;
    ///
    List<GameObject> spawnableItems;
    List<int> min;
    List<int> max;
    List<int> amount;
    List<Vector2> Pos;
    // Start is called before the first frame update
    void Start()
    {
        minX = gameObject.transform.position.x - gameObject.transform.localScale.x / 2;
        maxX = gameObject.transform.position.x + gameObject.transform.localScale.x / 2;
        minY = gameObject.transform.position.y - gameObject.transform.localScale.y / 2;
        maxY = gameObject.transform.position.y + gameObject.transform.localScale.y / 2;






        for (int i = 0; i < spawnableItems.Count; i++)
        {
            var amm = Random.Range(min[i], max[i]++);
            amount.Add(amm);
        }

        for (int y = 0; y < spawnableItems.Count; y++)
        {
            for (int x = 0; x < amount[y]; x++)
            {
                Instantiate(spawnableItems[y]);
            }

        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
