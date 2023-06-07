using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGenerator : MonoBehaviour
{
    float minX;
    float maxX;
    float minY;
    float maxY;
    ///


    [SerializeField] List<GameObject> spawnableItems;
    [SerializeField] List<int> min;
    [SerializeField] List<int> max;
    [SerializeField] List<int> amount;
 
    [SerializeField] List<GameObject> instantiatedItems;
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
                var qobj = Instantiate(spawnableItems[y]);
                qobj.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                instantiatedItems.Add(qobj);

            }

        }

    }



    // Update is called once per frame
    void Update()
    {

    }
}
