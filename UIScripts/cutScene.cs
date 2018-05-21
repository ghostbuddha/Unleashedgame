using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutScene : MonoBehaviour {
    public float delay;
    [SerializeField] private string nextScene;

    public void Start()
    {
        
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    public void SkipScene()
    {
        Debug.Log("We're trying fam");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {

        Debug.Log("Loading scene " + SceneManager.GetActiveScene().buildIndex + 1 + "...");
        yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
