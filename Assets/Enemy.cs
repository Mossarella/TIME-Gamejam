﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }
}
