using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject gotxt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        // 2P 모드일 때
        if (d_gamescene.game_state == 6 && d_gamescene.game_mode == 2) gotxt.GetComponent<Text>().text = "축하합니다!\nPlayer " + d_gamescene.player_turn + "이 승리했습니다!";
        // 1P 모드일 때
        else if (d_gamescene.game_state == 6 && d_gamescene.game_mode == 1)
        {
            if (d_gamescene.p2_bcount == 0 && d_gamescene.p2_wcount == 0) gotxt.GetComponent<Text>().text = "축하합니다!\nPlayer가 승리했습니다!";
            else gotxt.GetComponent<Text>().text = "CPU의 승리입니다..\n아쉬워요. 다음엔 더 잘해봐요!";
        }
    }

    public void gomain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
