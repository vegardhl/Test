using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlowerCounter : MonoBehaviour
{

    //GUIText scoreText;
    public GameController gameController;

    void Start() {
        //scoreText = GetComponent<GUIText>();
        //scoreText.text += " " + 3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Spilleren");
            Destroy(gameObject);
            gameController.UpdateScore();
        }
    }
    


}
