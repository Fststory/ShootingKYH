using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text text_currentScore;
    public Text text_bestScore;

    void Start()
    {
        // 폰트 색상
        //text_bestScore.color = new Color(1, 1, 0, 0.5f);
        // 폰트 크기
        //text_bestScore.fontSize = 100;
    }

    void Update()
    {

    }
}
