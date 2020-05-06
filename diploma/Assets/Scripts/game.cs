using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public int currentGold;
    public float currentScore;
    public Text playerDisplay;
    public Text scoreDisplay;
    public Text goldDisplay;
    public Text diffDisplay;
    
    private void Awake()
    {
        if (DBManager.nickname == null)
        {
            playerDisplay.text = "Guest";
        }
        else {
            playerDisplay.text = "Player: " + DBManager.nickname;
        }
        scoreDisplay.text = "Score: " + DBManager.score;
        diffDisplay.text = "Difficult: " + DBManager.difficult;
        if (DBManager.skin_id == "b1")
        {

        }
    }

    [System.Obsolete]
    public void CallSave()
    {
        StartCoroutine(SavePlayerData());
    }

    [System.Obsolete]
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("player_id",DBManager.id);
        form.AddField("score", DBManager.score.ToString());
        form.AddField("difficult", DBManager.difficult);
        form.AddField("time", Random.Range(50,80));
        form.AddField("gold", DBManager.gold);
        
        WWW www = new WWW("http://localhost/sqlconnect/savedata.php",form);

        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }
        DBManager.score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    public void IncreaseScore(float amount)
    {
        currentScore += amount;
    }
    public void GoBack()
    {
        DBManager.score=0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    void Update()
    {
        DBManager.gold = currentGold;
        DBManager.score = currentScore;
        scoreDisplay.text = "Score: " + DBManager.score.ToString();
        goldDisplay.text = "Gold: " + currentGold.ToString();
    }
    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        currentScore += goldToAdd * 10;
    }
}
