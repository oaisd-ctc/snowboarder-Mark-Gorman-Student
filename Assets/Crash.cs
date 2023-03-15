using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float LoadDelay = 2f;
    [SerializeField] ParticleSystem  deathEffect;
    bool crash = false;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !crash){
            FindObjectOfType<PlayerControl>().DisableControls();
            deathEffect.Play();
            GetComponent<AudioSource>().Play();
            crash = true;
            Invoke("ReloadScene", LoadDelay);
        }
    }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
