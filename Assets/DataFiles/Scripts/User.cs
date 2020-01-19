using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string name;
    public string password;
    public string url;
    public int score;

    public User(string na,string pas)
    {
        name = na;
        password = pas;
        url = null;
        score = 0;
    }

}
