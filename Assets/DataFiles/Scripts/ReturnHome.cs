using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    public Button home;

    public int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        Button homebtn = home.GetComponent<Button>();

        homebtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneID);
    }
    // Update is called once per frame
    
}
