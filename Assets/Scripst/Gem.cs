using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour , Item
{
    public void Collect()
    {
        Destroy(gameObject);
    }

  
}
