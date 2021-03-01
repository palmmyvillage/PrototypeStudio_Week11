using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Sprite[] mask;
    public int maskNum = 0;

    private SpriteMask spMask;
    
    // Start is called before the first frame update
    void Start()
    {
        spMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeMask()
    {
        maskNum++;
        spMask.sprite = mask[maskNum];
    }

    void selfDestroy()
    {
        Destroy(gameObject);
    }
}
