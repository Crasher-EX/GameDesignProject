using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int playerHealth;
    public GameObject AliveHeart1;
    public GameObject AliveHeart2;
    public GameObject AliveHeart3;
    public GameObject player;

    public AudioSource buttonClickSFX;
    public AudioSource levelMusic;
    public AudioSource playerHurtSFX;
    public AudioSource playerDeathSFX;

    public bool gameActive;
    public bool playerAlive;
    public bool playerImmunity;
    public bool playerDamagedBool;
    public float immunityTime;

    public Animator playerAnim;
    public Animator deadMenu;

    [SerializeField] string neighboorhoodScene;
    [SerializeField] string mainMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      playerAnim.SetBool("isDamaged", playerDamagedBool); //Connects "playerDamagedBool" from this script to the animators "isDamaged" bool
      deadMenu.SetBool("playerAlive", playerAlive); //Connects playerAlive bool to the dead menu pop up bool
    }

    //Handles the wait timer before turning of players immunity
    IEnumerator immunityLengthTimer()
    {
        yield return new WaitForSeconds(immunityTime);
        playerImmunity = false;
        playerDamagedBool = false;
    }
    

    //Script responsible for damaging player
    public void playerDamaged()
    {
        if (playerImmunity == false)
        {
            //gives player temporary immunity and turning on immunity timer
            playerImmunity = true;
            playerDamagedBool = true;
            StartCoroutine(immunityLengthTimer());

            if (playerHealth == 1)
            {
                playerHealth -= 1;
                AliveHeart3.SetActive(false);
                playerDeath();
                playerDeathSFX.Play();
            }
            else if (playerHealth == 2)
            {
                playerHealth -= 1;
                AliveHeart2.SetActive(false);
                playerHurtSFX.Play();
            }
            else //(playerHealth == 3)
            {
                playerHealth -= 1;
                AliveHeart1.SetActive(false);
                playerHurtSFX.Play();
            }
        
        }
    }

    void playerDeath()
    {
        playerAlive = false;
        player.GetComponent<BoxCollider2D>().enabled = false; //makes player fall out of map
        Debug.Log("PLAYER HAS DIED");
        levelMusic.Stop();
    }


    //MENU BUTTONS - SCENE CHANGERS

    public void playButton() //loads neighboorhood game scene
    {
        SceneManager.LoadScene(neighboorhoodScene);
        buttonClickSFX.Play();
    }

    public void quitButton() //loads neighboorhood game scene
    {
        SceneManager.LoadScene(mainMenu);
        buttonClickSFX.Play();
    }
}