using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odradek : MonoBehaviour
{
    public GameObject player;
    
    private AudioSource myAudio;
    private Animator myAnim;
    private bool isAlert;
    
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlert == true)
        {
            RaycastHit2D Hit = Physics2D.CircleCast(transform.position, 10, Vector2.up);
            if (Hit != null)
            {
                if (Hit.collider.gameObject.CompareTag("BT"))
                {
                    Debug.Log("Palmmy");
                    
                    Vector3 direction = Hit.collider.gameObject.transform.position - player.transform.position;

                    float x_pos = 0;
                    float y_pos = 0;
                
                    if (direction.x >= 0)
                    {
                        x_pos = player.transform.position.x + 3;
                    }
                    else
                    {
                        x_pos = player.transform.position.x - 3;
                    }

                    if (direction.y > 0)
                    {
                        y_pos = player.transform.position.y + 3;
                    }
                    else
                    {
                        y_pos = player.transform.position.y - 3;
                    }
                    
                    transform.position = new Vector3(x_pos,y_pos,-5);
                }
            }   
        }
    }

    void PlaySound()
    {
        myAudio.Play();
    }

    public void EnterAlert()
    {
        isAlert = true;
        myAnim.SetBool("isAlert", true);
    }
    
    public void ExitAlert()
    {
        isAlert = false;
        myAnim.SetBool("isAlert", false);
    }
}
