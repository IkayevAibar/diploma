using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class login_menu : MonoBehaviour
{
    public InputField mailField;
    public InputField passField;
    public Text loginFailed;
    public Button submit;

    public void CallLogin(){
        StartCoroutine(Login());
    }
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    [System.Obsolete]
    IEnumerator Login(){
        WWWForm form = new WWWForm();
        form.AddField("mail",mailField.text);
        form.AddField("password",passField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php",form);

        yield return www;

        if (www.text[0]=='0')
        {
            DBManager.mail=mailField.text;
            DBManager.nickname = www.text.Split('\t')[1];
            DBManager.id = int.Parse(www.text.Split('\t')[2]);
            DBManager.skin_id = www.text.Split('\t')[3];
            SceneManager.LoadScene(0);
        }
        else
        {
            loginFailed.text = "User login failed.";
            Debug.Log("Error #" + www.text);
        }
    }
    
    public void VerifyInputs(){
        submit.interactable = (mailField.text.Length >= 0 && passField.text.Length >= 0);
    }
}
