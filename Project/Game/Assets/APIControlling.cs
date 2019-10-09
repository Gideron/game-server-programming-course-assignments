using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
using System;

public class APIControlling : MonoBehaviour
{
    public string apiPath = "http://localhost:5000";

    public List<Player> GetAll()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiPath + "/players"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        PlayerList pList = JsonUtility.FromJson<PlayerList>(jsonResponse);
        return pList.players;
    }

    public void Create(string pName, int pScore)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiPath + "/players/{0}/{1}", pName, pScore));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        //check if successful
    }
}

public class Player
{
    public string playerName { get; set; }
    public string score { get; set; }
}

public class PlayerList
{
    public List<Player> players { get; set; }
}