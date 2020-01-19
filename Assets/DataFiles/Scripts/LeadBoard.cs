using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using FullSerializer;

public class LeadBoard : MonoBehaviour
{
    public Text txt1;
    public Text txt2;
    public Text txt3;
    public Text txt4;
    public Text txt5;

    public Text url1;
    public Text url2;
    public Text url3;
    public Text url4;
    public Text url5;

    User temp = new User(null, null);
    List<string> keyList;
    private static fsSerializer serializer = new fsSerializer();

    // Start is called before the first frame update
    void Start()
    {
        GetUsers();
    }


    IEnumerator render(string url, RawImage img)
    {
        Debug.Log("asddsa");
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();
    }

    public void GetUsers()
    {
        RestClient.Get($"https://wastelink-f800c.firebaseio.com/.json").Then(response =>
        {
            var responseJson = response.Text;
            
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, User>), ref deserialized);
            Dictionary<string, User> users = deserialized as Dictionary<string, User>;
            List<string> keyList = new List<string>(users.Keys);

            int count=0;

            foreach(string x in keyList)
            {
                count++;
            }

            int i;
            bool run = true;

            while(run)
            {
                i = 0;
                for (int j = 0;j<count-1;j++)
                {
                    if (users[keyList[j]].score < users[keyList[j+1]].score)
                    {
                        i++;
                        var txt = keyList[j];
                        keyList[j] = keyList[j + 1];
                        keyList[j + 1] = txt;
                    }
                }
                if (i == 0) { run = false; }
            }
            string temp3;
            txt1.text = users[keyList[0]].name + "       " + users[keyList[0]].score.ToString();
            txt2.text = users[keyList[1]].name + "       " + users[keyList[1]].score.ToString();
            txt3.text = users[keyList[2]].name + "       " + users[keyList[2]].score.ToString();
            txt4.text = users[keyList[3]].name + "       " + users[keyList[3]].score.ToString();
            txt5.text = users[keyList[4]].name + "       " + users[keyList[4]].score.ToString();

            url1.text = users[keyList[0]].url;
            url2.text = users[keyList[1]].url;
            url3.text = users[keyList[2]].url;
            url4.text = users[keyList[3]].url;
            url5.text = users[keyList[4]].url;

            //System.IO.File.WriteAllText(@"urls.txt", users[keyList[0]].url +"*"+ users[keyList[1]].url +"*"+ users[keyList[2]].url +"*" +users[keyList[3]].url +"*"+ users[keyList[3]].url);


        });
    }
}
