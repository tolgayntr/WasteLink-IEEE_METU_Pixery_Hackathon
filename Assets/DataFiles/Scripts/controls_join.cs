using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controls_join : MonoBehaviour
{
    public Button mainmenu;
    public Button profile;
    public Button events;

    int score;
    int star_count;
    int cola_count;
    

    void Start()
    {
        Button btn_main = mainmenu.GetComponent<Button>();
        Button btn_prof = profile.GetComponent<Button>();
        Button btn_event = events.GetComponent<Button>();

        btn_main.onClick.AddListener(TaskOnClick_main);
        btn_prof.onClick.AddListener(TaskOnClick_prof);
        btn_event.onClick.AddListener(TaskOnClick_event);
    }
    void TaskOnClick_main()
    {
        SceneManager.LoadScene(1);
    }
    void TaskOnClick_prof()
    {
        SceneManager.LoadScene(2);
    }
    void TaskOnClick_event()
    {
        SceneManager.LoadScene(4);
    }
}
