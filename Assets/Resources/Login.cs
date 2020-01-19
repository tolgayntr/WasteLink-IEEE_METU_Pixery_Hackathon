using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System.IO;

public class Login : MonoBehaviour
{
    public InputField nameText;
    public InputField passText;

    public GameObject us;
    User temp = new User(null,null);

    public string userName;
    public string userPassword;
    // Start is called before the first frame update
    void Start()
    {
    }

    private GameObject gameObject;

    private void Awake()
    {
        gameObject = GameObject.FindObjectOfType<GameObject>();
    }

    public void onLogin()
    {
        if (nameText.text.Length>0) {
            userName = nameText.text;
            userPassword = passText.text;
            returnFromDatabase();
        }
        else
        {
            return;
        }
        
    }

    public void loginRoutine()
    {
        if(temp != null && temp.password == passText.text)
        {
            SceneManager.LoadScene(1);
            GameObject temp=GameObject.Instantiate(us);
            temp.GetComponent<Text>().text = nameText.text;
            //gameObject.UpdateScore(userName);
            //string path = Application.persistentDataPath + "Assets/Resources/userName.txt";
            //StreamWriter writer = new StreamWriter(path , false);
            //writer.WriteLine(userName);
            //writer.WriteLine(temp.url);
            //writer.Close();
        }
    }

    // Update is called once per frame
    private void returnFromDatabase()
    {

        RestClient.Get<User>("https://wastelink-f800c.firebaseio.com/" + nameText.text + ".json").Then(response =>
          {
              temp = response;
              loginRoutine();
          }
        );
    }

}
