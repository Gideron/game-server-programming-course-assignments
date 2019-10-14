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
    public InputField playerNameInput;
    public InputField apiInput;

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
            playerNameInput.text = playerName.Length > 0 ? playerName : "Guest";
            apiInput.text = apiController.apiPath.Length > 0 ? apiController.apiPath : "http://localhost:5000";
            UpdateLeaders();
            ResetLevel();
        } else {
            playerName = playerNameInput.text.Length > 0 ? playerNameInput.text : "Guest";
            apiController.apiPath = apiInput.text.Length > 0 ? apiInput.text : "http://localhost:5000";
            paused = false;
            menuObject.SetActive(paused);
            Time.timeScale = 1;
        }
    }

    public void UpdateLeaders()
    {
        List<Player> players = apiController.GetAll();
        players.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));
        string txt = "";
        foreach(Player p in players)
        {
            Debug.Log(p.Name + " - " + p.Score);
            txt += p.Name + " - " + p.Score + "\n";
        }
        leaderList.text = txt;
    }

    public void CreateNewScore()
    {
        StartCoroutine(apiController.Create(playerName, Mathf.RoundToInt(score)));
        ToggleMenu(true);
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
        Rigidbody2D pRb2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        pRb2.velocity = Vector3.zero;
        pRb2.angularVelocity = 0;
    }
}
