using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private APIControlling apiController;
    public GameObject menuObject;
    public Text leaderList;

    public bool paused;
    public float score;

    void Awake()
    {
        paused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ToggleMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
            score += Time.deltaTime;
    }

    public void ToggleMenu(bool toggle) {
        if (toggle)
        {
            paused = true;
            Time.timeScale = 0;
            menuObject.SetActive(paused);
            UpdateLeaders();
            //TODO reset game (score, etc.)
        } else {
            paused = false;
            menuObject.SetActive(paused);
            Time.timeScale = 1;
        }
    }

    public void UpdateLeaders()
    {
        List<Player> players = apiController.GetAll();
        string txt = "";
        foreach(Player p in players)
        {
            txt += p.playerName + " - " + p.score + "\n";
        }
        leaderList.text = txt;
    }
}
