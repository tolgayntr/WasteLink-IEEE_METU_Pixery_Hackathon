using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;

    public void hebele()
    {
        if(inventory.active == false)
        {
            inventory.transform.gameObject.SetActive(true);
        }
        else
        {
            inventory.transform.gameObject.SetActive(false);
        }
    }
    public void hubele()
    {
        SceneManager.LoadScene(2);
    }

    public void sak()
    {
    }
}
