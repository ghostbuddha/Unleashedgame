using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
    {

        public void StartGame()
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LevelSelect(int level)
        {
          SceneManager.LoadScene(level);
        }
    

        public void QuitGame()
        {
            Debug.Log("END GAME");
        
        //EditorApplication.isPlaying = false;

        Application.Quit();
        }
    }
