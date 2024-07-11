using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Legacy Text 클래스 사용 시
using TMPro;        // Text Mesh Pro 클래스를 사용 시

public class ScoreUI : MonoBehaviour
{
    public Text text_currentScore;
    public Text text_bestScore;
    public TMP_Text tmp_currentScore;

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
