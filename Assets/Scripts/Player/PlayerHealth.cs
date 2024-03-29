﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public Image healthBar; //UI Bar
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //At start of scene, player gets max health
        healthBar.fillAmount = currentHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        float health = currentHealth / maxHealth;
        healthBar.fillAmount = health;
        if (currentHealth <= 0)      //If health goes to 0 or below, call GameOver in GameManager
        {
            SceneManager.LoadScene("GameOver");//If health is put to zero, changes scene to GameOver
        }
    }

    public void HealDamage(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) //If health goes above max health then cap it at max health
            currentHealth = maxHealth;

        float health = currentHealth / maxHealth;
        healthBar.fillAmount = health;
    }


}
