using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTs : MonoBehaviour
{
    public Sprite[] shape;
    private SpriteRenderer self;

    public int spriteCoolDown;
    private int currentSpriteCool;

    private State state;

    public GameObject player;

    private int dValue;
    public int dValueCap;

    private int fValue;
    public int fValueCap;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpriteCool--;

        if (currentSpriteCool <= 0)
        {
            //self.sprite = shape[Random.Range(0, shape.Length)];
            currentSpriteCool = spriteCoolDown;
        }


        switch (state)
        {
            case State.detecting
                : btDetecting();
                break;
            case State.found
                : btFinding();
                break;
        }
    }

    void btPeace()
    {
        self.color = new Color(1,1,1,0);
        
        if (dValue > 0)
        {
            dValue -= 1;
        }
    }

    void btDetecting()
    {
        self.color = Color.white;

        if (dValue < dValueCap)
        {
            dValue += 2;
        }
        else
        {
            state = State.found;
        }
        
    }

    void btFinding()
    {
        if (fValue < fValueCap)
        {
            fValue++;
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * 3;
            fValue = 0;
        }
    }
    
    
    
    enum State
    {
        peace,
        detecting,
        found
    }
}
