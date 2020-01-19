using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;

public class onlineImage2 : MonoBehaviour
{
    public int i;
    public string url;
    public RawImage img;

    public Text url1;


    void awake()
    {
        img = this.gameObject.GetComponent<RawImage>();
    }

    IEnumerator Start()
    {
        //string[] lines = System.IO.File.ReadAllText(@"urls.txt").Split('*');
        while (true)
        {
            img = this.gameObject.GetComponent<RawImage>();
            WWW www = new WWW(url1.text);
            yield return www;
            img.texture = www.texture;
            img.SetNativeSize();
        }
    }


}

