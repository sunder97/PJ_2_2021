using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 메인 Scene에서 1Player 및 2Player 버튼 클릭 시 Scene 이동
    public void SingleChange()
    {
        SceneManager.LoadScene("SingleGameScene");
    }
    public void DoubleChange()
    {
        SceneManager.LoadScene("DoubleGameScene");
    }
}
