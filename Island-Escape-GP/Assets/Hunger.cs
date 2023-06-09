using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField] public int hunger = 100;
    bool isHunger = false;
    [SerializeField] int SectillHungerGone =4;
    public float hungertobar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hungertobar = hunger / 100f;
        Debug.Log(hungertobar);
        gameObject.GetComponent<Image>().fillAmount = hungertobar;
        if (!isHunger)
        {
            StartCoroutine(TakeAwayHunger());
        }
    }
    public void AddHunger(int hungerAdd)
    { 
        hunger += hungerAdd;

    }
    IEnumerator TakeAwayHunger()
    {
        isHunger = true;
        hunger -= 1;
        yield return new WaitForSeconds(SectillHungerGone);
        isHunger = false;
    }
}
