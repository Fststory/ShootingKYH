using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    public Text text_res;

    Camera myCam;

    void Start()
    {
        // 해상도를 변경하기
        Screen.SetResolution(540, 960, false);

        // 카메라의 Orthographic size도 같이 조정한다.
        myCam = GetComponent<Camera>();
        myCam.orthographicSize = (float)Screen.height / 200.0f;
    }

    void Update()
    {
        // 현재 스크린의 너비와 높이 해상도 값을 출력한다.
        int res_x = Screen.width;
        int res_y = Screen.height;

        string resText = "Width: " + res_x.ToString() + "\nHeight: " + res_y.ToString();
        text_res.text = resText;
    }
}
