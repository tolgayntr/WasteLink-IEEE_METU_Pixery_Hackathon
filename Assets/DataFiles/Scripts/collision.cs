using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Vuforia;
using Proyecto26;
using System.IO;

public class collision : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vb;
    public GameObject texxt;
    public GameObject starbucks;
    public GameObject part;

    User temp = new User(null, null);
    // Start is called before the first frame update
    void Start()
    {
        vb = GameObject.Find("love");
        vb.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        returnFromDatabase();
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        int count = Int32.Parse(texxt.GetComponent<Text>().text);
        temp.score += 10;
        count += 10;
        texxt.GetComponent<Text>().text = count.ToString();
        RestClient.Put("https://wastelink-f800c.firebaseio.com/Tolga.json", temp);
        part.SetActive(true);
        part.GetComponent<ParticleSystem>().Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        print("noooo");
    }

    public void execute() {
        int count = temp.score;
        texxt.GetComponent<Text>().text = count.ToString();
    }

    private void returnFromDatabase()
    {
        RestClient.Get<User>("https://wastelink-f800c.firebaseio.com/Tolga.json").Then(response =>
        {
            temp = response;

            execute();
        }
        );
    }
}
