using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public int cargoNum = 0;

    public int[] coolDown;
    public int currentCoolDown;

    private bool scannerEnable;
    public int scannerCoolDown, scannerCurrentCoolDown;

    public bool holdBreath;
    private bool enableHold;

    public Odradek oda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCoolDown >= 0)
        {
            currentCoolDown--;
        }

        movement(cargoNum);

        if (Input.GetKey(KeyCode.C))
        {
            if (enableHold == true)
            {
                holdBreath = true;
                scannerCurrentCoolDown++;
            }
            else
            {
                if (scannerCurrentCoolDown >= 0)
                {
                    enableHold = false;
                    scannerCurrentCoolDown-=3;
                }
            }
        }
        else
        {
            holdBreath = false;
            if (scannerCurrentCoolDown >= 0)
            {
                enableHold = false;
                scannerCurrentCoolDown-=3;
            }
            else
            {
                enableHold = true;
            }
        }
        
        callScanner();
    }

    void movement(int weight)
    {
        //check if can move or not
        if (currentCoolDown <= 0)
        {
            //make Var to store H-Axis
            float hPress = Input.GetAxis("Horizontal");
            float vPress = Input.GetAxis("Vertical");

            Vector3 move =  new Vector3(0,0,0);

            //Cast ray to see if there are any obstacle
            RaycastHit2D h_Hit = Physics2D.Raycast(transform.position, Vector2.right * hPress ,1);
            RaycastHit2D v_Hit = Physics2D.Raycast(transform.position, Vector2.up * vPress ,1);
            RaycastHit2D both_Hit = Physics2D.Raycast(transform.position, new Vector2(hPress, vPress).normalized, 1);

            if (hPress != 0 && vPress == 0)
            {
                if (h_Hit.collider != null)
                {
                    if (h_Hit.collider.gameObject.CompareTag("Obs") != true)
                    {
                        transform.position += new Vector3(hPress,0,0).normalized;
                        currentCoolDown = coolDown[weight];
                    }
                }
                else
                {
                    transform.position += new Vector3(hPress,0,0).normalized;
                    currentCoolDown = coolDown[weight];
                }
                
            }

            if (vPress != 0 && hPress == 0)
            {
                if (v_Hit.collider != null)
                {
                    if (v_Hit.collider.gameObject.CompareTag("Obs") != true)
                    {
                        transform.position += new Vector3(0,vPress,0).normalized;
                        currentCoolDown = coolDown[weight];
                    }
                }
                else
                {
                    transform.position += new Vector3(0,vPress,0).normalized;
                    currentCoolDown = coolDown[weight];
                }
            }
            
            if (vPress != 0 && hPress != 0)
            {
                if (both_Hit.collider != null)
                {
                    if (both_Hit.collider.gameObject.CompareTag("Obs") != true)
                    {
                        transform.position += new Vector3(hPress,vPress,0).normalized;
                        currentCoolDown = coolDown[weight];
                    }
                }
                else
                {
                    transform.position += new Vector3(hPress,vPress,0).normalized;
                    currentCoolDown = coolDown[weight];
                }
            }
        }
    }

    void callScanner()
    {
        if (Input.GetKeyDown(KeyCode.Space) && holdBreath != true)
        {
            if (scannerCurrentCoolDown <= 0)
            {
                Instantiate(Resources.Load("Prefabs/Scanner"), transform.position + new Vector3(0,0,-3), new Quaternion(0,0,0,0));
                scannerCurrentCoolDown = scannerCoolDown;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BT"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (other.gameObject.CompareTag("BTfield"))
        {
            oda.EnterAlert();
        }
        else if (other.gameObject.CompareTag("Cargo"))
        {
            cargoNum++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("UCA"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BTfield"))
        {
            oda.ExitAlert();
        }
    }
}
