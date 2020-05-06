using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth = 100;
    
    public GameObject FillArea;
    public Slider healthBar;
    public Text hbText;
    
    public GameObject DeathEffect;
    
    public PlayerController pc;
    
    
    private float invincibilityLength=1.5f;
    private float invincibilityCounter;
    
    public Renderer playerRenderer;
    private float flashCounter;
    private float flashLength=0.1f;

    private Vector3 respawnPoint = Vector3.zero;
    private bool isRespawning;
    private float respawnLength = 3f;

    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    private float fadeSpeed=2f;
    private float waitForFade=3f;

    public Material b1;
    public Material b2;
    public Material b3;
    public Material b4;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        //pc = FindObjectOfType<PlayerController>();
        if (DBManager.skin_id == "b1")
        {
            playerRenderer.material = b1;
        }
        else if (DBManager.skin_id == "b2")
        {
            playerRenderer.material = b2;

        }
        else if (DBManager.skin_id == "b3")
        {
            playerRenderer.material = b3;

        }
        else if (DBManager.skin_id == "b4")
        {
            playerRenderer.material = b4;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength; 
            }
        }
        else
        {
            playerRenderer.enabled = true;

        }
        hbText.text =  healthBar.value.ToString() + "%";
        healthBar.value = currentHealth;
        if (healthBar.value == 0)
        {
            FillArea.gameObject.SetActive(false);
        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r,blackScreen.color.g,blackScreen.color.b,Mathf.MoveTowards(blackScreen.color.a,1f,fadeSpeed*Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }


    }

    public void DamagePlayer(float amount, Vector3 direction)
    {
        if (invincibilityCounter <= 0) { 
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Respawn();
            }
            else { 
                pc.KnockBack(direction);
                invincibilityCounter = invincibilityLength;
                playerRenderer.enabled = false;
                flashCounter = flashLength;
            }
        }
    }
    public void Respawn()
    {
        Debug.Log(!isRespawning);
        if (!isRespawning) { 
            StartCoroutine(RespawnCo());
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        pc.gameObject.SetActive(false);
        Instantiate(DeathEffect, pc.transform.position, pc.transform.rotation);
        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;
        yield return new WaitForSeconds(waitForFade);

        try
        {
            pc.transform.position = respawnPoint;
        }
        finally
        {
            pc.transform.position = respawnPoint;
        }

        isFadeToBlack = false;
        isFadeFromBlack = true;

        isRespawning = false;
        pc.gameObject.SetActive(true);
        
        
        if (pc.transform.position != respawnPoint)
        {
            pc.transform.position = respawnPoint;
        }
        currentHealth = maxHealth;

        FillArea.gameObject.SetActive(true);

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;

    }
    public void SetSpawnPoint(Vector3 point)
    {
        respawnPoint = point;
    }
    public void HealPlayer(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
 