using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text score;
    private int scoreTeller;

    void Start() {

        score.text += "  0";
        scoreTeller = 0;

    }

    public void UpdateScore()
    {
        scoreTeller += 1;
        score.text = "Score: " + scoreTeller;
    }

}
