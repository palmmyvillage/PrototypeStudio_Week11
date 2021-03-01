using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public static ResetButton instance;
    
    public KeyCode resetScene, resetGame, quitgame, nextScene;
    public bool enableNextScene;

    void Awoke()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetScene();
        ResetGame();
        QuitGame();

        if (enableNextScene == true)
        {
            NextScene();
        }
    }

    void ResetScene()
    {
        if (Input.GetKeyDown(resetScene))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void ResetGame()
    {
        if (Input.GetKeyDown(resetGame))
        {
            SceneManager.LoadScene(0);
        }
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(quitgame))
        {
            Application.Quit();
        }
    }

    public void NextScene()
    {
        if (Input.GetKeyDown(nextScene))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
