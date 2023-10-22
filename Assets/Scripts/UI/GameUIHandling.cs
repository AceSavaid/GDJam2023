using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameUIHandling : MonoBehaviour
{

    //different game result screens 
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject drawScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
    }

    void ShowLoseScreen()
    {
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }
    }

    void ShowDrawScreen()
    {
        if (drawScreen != null)
        {
            drawScreen.SetActive(false);
        }
    }

    void ToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    void ToGameScreen()
    {
        SceneManager.LoadScene(1);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
