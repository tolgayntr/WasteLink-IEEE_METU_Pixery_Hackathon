using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;

public class onlineImage : MonoBehaviour
{
    public string url;
    public RawImage img;

    void awake()
    {
        img = this.gameObject.GetComponent<RawImage>();
    }

    IEnumerator Start()
    {
        string[] lines = System.IO.File.ReadAllLines(@"userName.txt");
        img = this.gameObject.GetComponent<RawImage>();
        WWW www = new WWW(lines[1]);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();
    }


}

