using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerUI : MonoBehaviour
{
    public PlayerMove player;
    public SpriteRenderer[] guageBull;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.scannerCurrentCoolDown > 720)
        {
            GuageRegen(0);
        }
        else if (player.scannerCurrentCoolDown > 540)
        {
            GuageRegen(1);
        }
        else if (player.scannerCurrentCoolDown > 360)
        {
            GuageRegen(2);
        }
        else if (player.scannerCurrentCoolDown > 180)
        {
            GuageRegen(3);
        }
        else if (player.scannerCurrentCoolDown > 0)
        {
            GuageRegen(4);
        }
        else
        {
            GuageRegen(5);
        }
    }

    void GuageRegen(int Unit)
    {
        for (int i = 0; i < guageBull.Length; i++)
        {
            if (i < Unit) guageBull[i].color = Color.white;
            else
            {
                guageBull[i].color = new Color(0,0,0,0);
            }
        }
    }
}
