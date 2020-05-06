using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class play_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Scrollbar diff_scrollbar;
    public Text diff_text;

    private void Update()
    {
        if (diff_scrollbar.value > 0.25)
        {
            diff_text.text = "Normal";
            DBManager.diff_status = 1;
            if (diff_scrollbar.value > 0.5)
            {
                DBManager.diff_status = 2;
                diff_text.text = "Hard";
                if (diff_scrollbar.value > 0.75)
                {
                    DBManager.diff_status = 3;
                    diff_text.text = "Very Hard";
                }
            }
        }
        Debug.Log(DBManager.diff_status);
        if (diff_scrollbar.value < 0.25)
        {
            DBManager.diff_status = 0.5f;
            diff_text.text = "Easy";
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
    public void GotoGame()
    {
        DBManager.difficult = diff_text.text;
        
        SceneManager.LoadScene(3);
    }

}
