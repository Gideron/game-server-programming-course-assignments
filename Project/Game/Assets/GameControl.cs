using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public string playerName = "Guest";
    public float score = 0;

    private APIControlling apiController;
    public GameObject menuObject;
    public Text leaderList;
    public Text scoreText;

    public bool paused;

    void Awake()
    {
        paused = false;
        apiController = this.GetComponent<APIControlling>();
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
        {
            score += Time.deltaTime;
            UpdateScoreText();
        }

        if (Input.GetButtonDown("Cancel"))
            ToggleMenu(!paused);
    }

    public void ToggleMenu(bool toggle) {
        if (toggle)
        {
            paused = true;
            Time.timeScale = 0;
            menuObject.SetActive(paused);
            UpdateLeaders();
            ResetLevel();
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

    public void CreateNewScore()
    {
        ToggleMenu(true);
        StartCoroutine(apiController.Create(playerName, (int)score));
        UpdateLeaders();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void ResetLevel()
    {
        score = 0;
        UpdateScoreText();
        foreach(GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(e);
        }
    }
}
