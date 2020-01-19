using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData : MonoBehaviour
{
    public string name;
    public string url;
    public string url1;
    public string url2;
    public string url3;
    public string url4;
    public string url5;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void updateScore(string i)
    {
        name = i;
    }
}
