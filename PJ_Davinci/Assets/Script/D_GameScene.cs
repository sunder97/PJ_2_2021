using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_GameScene : MonoBehaviour
{
    public GameObject tcs, p_t1, p_t2, p_t3o, p_t3x, go, c_t1, c_t2;

    public GameObject t_player, nt_player, tp_wnum, tp_bnum, ntp_wnum, ntp_bnum;

    // 덱의 상태
    public List<int> white_tile = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    public List<int> black_tile = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

    // 플레이어의 상태, p2는 2P 모드에선 플레이어 1P 모드에선 CPU입니다.
    public int[] p1_tile = new int[] { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
    public int p1_count = 0;
    public int p1_wcount = 0;
    public int p1_bcount = 0;
    public int[] p2_tile = new int[] { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
    public int p2_count = 0;
    public int p2_wcount = 0;
    public int p2_bcount = 0;

    // state 0은 빈 것, 1,2 는 white / 3,4는 black 구분은 //2로
    public int[] p1_tile_state = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] p2_tile_state = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    // 게임의 상태 및 필요 변수들 선언
    public int game_state = 0;
    public int player_turn = 1;
    public int choiceNum, choiceidx, choicecolor;
    public int turnidx, turncolor;
    public int cpucnt = 0;
    public bool cpu_oorc;

    // 게임 모드 숫자에 따라 1P, 2P
    public int game_mode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player_turn == 1)
        {
            t_player.GetComponent<Text>().text = "Player 1";
            tp_wnum.GetComponent<Text>().text = "x " + p1_wcount;
            tp_bnum.GetComponent<Text>().text = "x " + p1_bcount;
            if (game_mode == 2) nt_player.GetComponent<Text>().text = "Player 2의 남은 타일";
            else nt_player.GetComponent<Text>().text = "CPU의 남은 타일";
            ntp_wnum.GetComponent<Text>().text = "x " + p2_wcount;
            ntp_bnum.GetComponent<Text>().text = "x " + p2_bcount;
        }
        else
        {
            if (game_mode == 2) t_player.GetComponent<Text>().text = "Player 2";
            else t_player.GetComponent<Text>().text = "CPU";
            tp_wnum.GetComponent<Text>().text = "x " + p2_wcount;
            tp_bnum.GetComponent<Text>().text = "x " + p2_bcount;
            nt_player.GetComponent<Text>().text = "Player 1의 남은 타일";
            ntp_wnum.GetComponent<Text>().text = "x " + p1_wcount;
            ntp_bnum.GetComponent<Text>().text = "x " + p1_bcount;
        }

        if (game_state == -2)
        {
            c_t2.SetActive(true);
            c_t1.SetActive(false);
        }
        else if (game_state == -1)
        {
            c_t1.SetActive(true);
            p_t3o.SetActive(false);
            p_t3x.SetActive(false);
        }
        else if (game_state <= 1)
        {
            tcs.SetActive(true);
            c_t1.SetActive(false);
            c_t2.SetActive(false);
            p_t1.SetActive(false);
            p_t2.SetActive(false);
            p_t3o.SetActive(false);
            p_t3x.SetActive(false);
            go.SetActive(false);
        }
        else if (game_state == 2)
        {
            p_t1.SetActive(true);
            tcs.SetActive(false);
        }
        else if (game_state == 3)
        {
            p_t2.SetActive(true);
            p_t1.SetActive(false);
        }
        else if (game_state == 4)
        {
            p_t3o.SetActive(true);
            p_t2.SetActive(false);
        }
        else if (game_state == 5)
        {
            p_t3x.SetActive(true);
            p_t2.SetActive(false);
        }
        else
        {
            go.SetActive(true);
            p_t2.SetActive(false);
        }
    }
}
