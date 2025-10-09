using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int playerHealth;
    public GameObject AliveHeart1;
    public GameObject AliveHeart2;
    public GameObject AliveHeart3;
    public GameObject DeadHeart1;
    public GameObject DeadHeart2;
    public GameObject DeadHeart3;

    public bool gameActive;
    public bool playerImmunity;
    public float immunityTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Handles the wait timer before turning of players immunity
    IEnumerator immunityLengthTimer()
    {
        yield return new WaitForSeconds(immunityTime);
        playerImmunity = false;
    }
    

    //Script responsible for damaging player
    public void playerDamaged()
    {
        if (playerImmunity == false)
        {
            //gives player temporary immunity and turning on immunity timer
            playerImmunity = true;
            StartCoroutine(immunityLengthTimer());

            if (playerHealth == 1)
            {
                playerHealth -= 1;
                AliveHeart3.SetActive(false);
                playerDeath();
            }
            else if (playerHealth == 2)
            {
                playerHealth -= 1;
                AliveHeart2.SetActive(false);
            }
            else //(playerHealth == 3)
            {
                playerHealth -= 1;
                AliveHeart1.SetActive(false);
            }
            
        }
    }

    void playerDeath()
    {
        Debug.Log("PLAYER HAS DIED");
    }
}
