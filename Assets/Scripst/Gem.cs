using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour , Item
{

    public static event Action<int> OnGemCollect;
    public int worth = 5;
    public void Collect()
    {
        OnGemCollect.Invoke(worth);
        Destroy(gameObject);
    }

  
}
