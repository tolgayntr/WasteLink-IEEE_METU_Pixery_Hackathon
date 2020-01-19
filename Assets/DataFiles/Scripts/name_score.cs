using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class name_score : MonoBehaviour
{
    public void onJoin()
    {
        SceneManager.LoadScene(3);
    }
    User temp = new User(null, null);
    Text txt;
    string[] lines;
    // Start is called before the first frame update
    void Start()
    {
        lines = System.IO.File.ReadAllLines(@"userName.txt");
        txt = GameObject.Find("Camera/Canvas/Panel/Text").GetComponent<Text>() ;
        returnFromDatabase();
    }

    private void execute()
    {
        txt.text = temp.name + "\n" + temp.score;
    }

    private void returnFromDatabase()
    {
        Debug.Log(lines[0]);
        RestClient.Get<User>("https://wastelink-f800c.firebaseio.com/" + lines[0] + ".json").Then(response =>
        {
            temp = response;
            
            execute();
        }
        );
    }
}
