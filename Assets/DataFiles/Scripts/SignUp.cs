using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class SignUp : MonoBehaviour
{
    public InputField nameText;
    public InputField passText;

    public string userName;
    public string userPassword;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onSignup()
    {
        if (nameText.text.Length > 0)
        {
            userName = nameText.text;
            userPassword = passText.text;
            PostToDatabase();
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    private void PostToDatabase()
    {
        User user = new User(userName,userPassword);
        //RestClient.Post("https://wastelink-f800c.firebaseio.com/"+"Users"+".json", user);
        RestClient.Put("https://wastelink-f800c.firebaseio.com/"+userName+".json",user);
    }
}
