using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMaker : MonoBehaviour
{
    public CameraLook scores;
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Beetle: " + scores.scores[0] + "pts \n"
            + "Turtle: " + scores.scores[1] + "pts \n"
            + "Worm: " + scores.scores[2] + "pts";
    }
}
