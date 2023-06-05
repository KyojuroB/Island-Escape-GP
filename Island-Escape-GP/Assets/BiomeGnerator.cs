using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BiomeGnerator : MonoBehaviour
{
    GameObject parentObject;
    float minX = parentObject.transform.position.x - parentObject.transform.localScale.x / 2;
    float maxX = parentObject.transform.position.x + parentObject.transform.localScale.x / 2;
    float minY = parentObject.transform.position.y - parentObject.transform.localScale.y / 2;
    float maxY = parentObject.transform.position.y + parentObject.transform.localScale.y / 2;
    ///
    List<GameObject> spawnableItems;
    List<int> min;
    List<int> max;
    List<int> amount;
    List<Vector2>
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnableItems.Count; i++)
        {
            var amm = Random.Range(min[i], max[i]++);
            amount.Add(amm);
        }

        for(int y = 0; y < spawnableItems.Count; y++)
        {
            for(int x = 0; x < amount[y]; x++)
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
