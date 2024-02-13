using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;

    void Update()
    {
        score.text = "" + Enemy.score;
    }
}
