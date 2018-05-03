using UnityEngine;
using System.Collections;
 
public class PlayerHealth : MonoBehaviour {
 
    public int maxHealth;
    public int currentHealth;
 
    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
    }
 
    // Update is called once per frame
    void Update() {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}