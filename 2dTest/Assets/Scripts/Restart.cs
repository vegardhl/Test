using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Spilleren");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }

    //Test for github
    void test()
    {

    }
}
