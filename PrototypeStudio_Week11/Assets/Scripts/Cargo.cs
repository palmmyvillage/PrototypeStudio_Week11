using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    public SpriteRenderer[] cargo;
    public PlayerMove player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.cargoNum == 1)
        {
            cargo[0].color = Color.white;
        }
        
        if (player.cargoNum == 2)
        {
            cargo[1].color = Color.white;
        }
        
        if (player.cargoNum == 3)
        {
            cargo[2].color = Color.white;
        }
        
        if (player.cargoNum == 4)
        {
            cargo[3].color = Color.white;
        }
    }
}
