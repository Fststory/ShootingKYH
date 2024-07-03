using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoAction : MonoBehaviour
{

    void Start()
    {
        
    }

    public void NextScene()
    {
        // 버튼을 누를 시..

        // 1번 씬을 로드한다.
        SceneManager.LoadScene(1);
    }
}
