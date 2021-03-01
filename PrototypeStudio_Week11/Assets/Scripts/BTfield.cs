using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTfield : MonoBehaviour
{
    public SpriteRenderer BTbody;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BTbody.color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BTbody.color = new Color(0,0,0,0);
        }
    }
}
