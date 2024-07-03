using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // UI 클래스 관련 네임스페이스
using UnityEngine.SceneManagement;  // Scene을 다루고 관리하는 클래스 관련 네임스페이스
using UnityEditor;          // Unity Editor 관련 기능을 다루는 클래스 관련 네임스페이스

public class GameManager : MonoBehaviour
{
    // Singletone Pattern class
    // static 변수
    public static GameManager gm;

    public ScoreUI scoreUI;
    public GameObject gameOverUI;
        
    int currentScore;

    public int BestScore { get { return bestScore; } }
    int bestScore;

    void Awake()
    {
        // 씬에 단 한개만 존재하도록 처리
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 현재 점수 표시 초기화
        AddScore(0);

        // 최고 점수 표시
        // 만일, "BestScore"라는 키로 저장된 데이터가 있다면...
        //print(PlayerPrefs.HasKey("BestScore"));
        if (PlayerPrefs.HasKey("BestScore"))
        {
            // "BestScore"라는 키로 저장된 데이터를 불러온다.
            bestScore = PlayerPrefs.GetInt("BestScore");
            scoreUI.text_bestScore.text = bestScore.ToString();
        }
        else
        {
            scoreUI.text_bestScore.text = "0";
        }

        // 게임오버 UI를 끈 상태로 시작
        //gameOverUI.SetActive(false);
    }

    // 점수를 추가하고, 변경된 점수를 UI에 출력한다.
    public void AddScore(int point)
    {
        // 1. 현재 점수를 누적한다.
        currentScore += point;

        // 2. 현재 점수를 UI에 출력한다.
        scoreUI.text_currentScore.text = currentScore.ToString();

        // 3. 만일, 현재 점수가 최고 점수보다 더 높다면...
        if(currentScore>bestScore)
        {
            // 3-1. 현재 점수를 최고 점수로 갱신한다.
            bestScore = currentScore;

            // 3-2. 변경된 최고점수를 UI에 출력한다.
            scoreUI.text_bestScore.text = bestScore.ToString();
        }
    }

    // 게임 오버가 되면 실행할 함수
    public void ShowGameOverUI()
    {
        // 게임 오버 UI 오브젝트를 활성화한다.
        gameOverUI.SetActive(true);

        // 업데이트 시간을 0배속으로 한다. (시간을 멈춘다)
        Time.timeScale = 0;
    }

    // 계속하기 버튼을 눌렀을 때 실행할 함수
    public void ContinueGame()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    
    // 게임을 처음부터 다시 시작하는 함수
    public void RestartGame()
    {
        // 업데이트 시간을 다시 1배율로 변경한다.
        Time.timeScale = 1.0f;

        // 현재 씬을 다시 시작한다.
        SceneManager.LoadScene(0);
    }

    // 어플리케이션을 종료하는 함수
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 1. 에디터일 경우
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. 어플리케이션일 경우
        Application.Quit();
#endif
    }

}
