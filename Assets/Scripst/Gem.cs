using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour , Item
{
    [SerializeField] private AudioSource soundGem;

    public static event Action<int> OnGemCollect;
    public int worth = 5;

    private void Awake()
    {
        soundGem = FindAnyObjectByType<AudioSource>();
    }
    public void Collect()
    {
        
        OnGemCollect.Invoke(worth);
        soundGem.Play();
        Destroy(gameObject);
        
    }

  
}
