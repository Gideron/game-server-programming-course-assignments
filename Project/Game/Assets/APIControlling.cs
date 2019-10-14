using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;

public class APIControlling : MonoBehaviour
{
    public string apiPath = "http://localhost:5000";

    public List<Player> GetAll()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiPath + "/api/players"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        PlayerList pList = JsonUtility.FromJson<PlayerList>(jsonResponse);
        return pList.Players;
    }

    public IEnumerator Create(string pName, int pScore)
    {
        string b = "{\"Name\": \"" + pName + "\", \"Score\": " + pScore + "}";

        var uwr = new UnityWebRequest(apiPath + "/api/players", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(b);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}

[System.Serializable]
public class Player
{
    public string Name;
    public int Score;
}

[System.Serializable]
public class PlayerList
{
    public List<Player> Players;
}