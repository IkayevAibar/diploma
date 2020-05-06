using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main_menu : MonoBehaviour
{
    public Text playerDisplay;
    public Button register;
    public Button login;
    public Button logout;


    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.nickname;
            
        }
        register.gameObject.SetActive(!DBManager.LoggedIn);
        login.gameObject.SetActive(!DBManager.LoggedIn);
        logout.gameObject.SetActive(DBManager.LoggedIn);
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined;

        }
    }
    public void GoToRegister(){
        //http://localhost:8000/register
        Application.OpenURL("http://localhost:8000/register");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToPlayMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void LogOut()
    {
        DBManager.nickname = null;
        DBManager.mail = null;
        DBManager.score = 0;
        DBManager.id = 0;

        SceneManager.LoadScene(0);

    }
}
