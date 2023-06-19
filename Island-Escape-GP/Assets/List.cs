using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class List : MonoBehaviour
{

    [SerializeField] List<GameObject> partList;
    [SerializeField] int partsfound=0;
    Vector2 defaultPos = new Vector2(353f, 17f);
    Vector2 outPos = new Vector2(745f, 17f);
    public RectTransform rectTransform;
    bool isact = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            partList.Add(transform.GetChild(0).GetChild(i).gameObject) ;
        }

        InvokeRepeating("IsDone", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        InteractPop();
    }

    public void InteractPop()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isact)
            {
                rectTransform.anchoredPosition = defaultPos;
                isact = true;
            }
            else
            {
                rectTransform.anchoredPosition = outPos;
                isact = false;
            }
                    

        }
    }

    public void ItemFound(int part)
    {
        partList[part].GetComponent<TextMeshProUGUI>().color = Color.red;
        partsfound++;
    }

    private void IsDone()
    {
        if(partsfound == 3)
        {
            GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().load();
        }

    }


    
}
