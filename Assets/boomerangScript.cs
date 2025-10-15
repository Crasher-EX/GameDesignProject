using System.Collections;
using UnityEngine;

public class boomerangScript : MonoBehaviour
{
    public float boomerangCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(boomerangCooldownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator boomerangCooldownTimer()
    {
        yield return new WaitForSeconds(boomerangCooldown);
        Destroy(gameObject);
    }

}
