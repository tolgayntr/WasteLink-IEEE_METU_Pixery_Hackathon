using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClick : MonoBehaviour
{
    int count=0;
    public GameObject starbucks;
    public GameObject starbucks_text;
    private void OnMouseDown()
    {
        count += 1;
        if (starbucks.active == false)
        {
            starbucks.SetActive(true); 
        }
        starbucks_text.GetComponent<Text>().text = count.ToString();
        
    }

}
