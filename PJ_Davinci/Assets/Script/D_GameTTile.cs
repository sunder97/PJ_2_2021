using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_GameTTile : MonoBehaviour
{
    D_GameScene d_gamescene;
    Take take_tile;

    public GameObject take_tile_txt;
    public GameObject White_num;
    public GameObject Black_num;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
        take_tile = GameObject.Find("Canvas").GetComponent<Take>();
    }

    // Update is called once per frame
    void Update()
    {
        if (d_gamescene.player_turn == 1)
        {
            White_num.GetComponent<Text>().text = "x " + d_gamescene.p1_wcount;
            Black_num.GetComponent<Text>().text = "x " + d_gamescene.p1_bcount;
        }
        else
        {
            White_num.GetComponent<Text>().text = "x " + d_gamescene.p2_wcount;
            Black_num.GetComponent<Text>().text = "x " + d_gamescene.p2_bcount;
        }


        if (d_gamescene.game_state == 0)
        {
            // 시작 전 1Player 차례
            if (d_gamescene.player_turn == 1)
            {
                take_tile_txt.GetComponent<Text>().text = "Player 1의 차례 입니다\n 숫자 타일을 4장 골라주세요";
                if (d_gamescene.p1_count == 4) d_gamescene.player_turn = 2;
            }
            // 2P 모드 시작 전 2Player 차례
            else if ( d_gamescene.game_mode == 2 )
            {
                take_tile_txt.GetComponent<Text>().text = "Player 2의 차례 입니다\n 숫자 타일을 4장 골라주세요";
                if (d_gamescene.p2_count == 4)
                {
                    d_gamescene.game_state = 1;
                    d_gamescene.player_turn = 1;
                }
            }
            // 1P 모드 시작 전 CPU 자동 진행
            else
            {
                // 카드 4장 랜덤 입력
                d_gamescene.player_turn = 2;
                for ( int i = 0; i < 4; i++)
                {
                    int ran_num = Random.Range(0, 2);
                    if (ran_num == 0) take_tile.w_take();
                    else take_tile.b_take();
                }
                d_gamescene.player_turn = 1;

                d_gamescene.game_state = 1;
            }
        }
        else if (d_gamescene.game_state == 1)
        {
            // 시작 후 1Player 차례
            if (d_gamescene.player_turn == 1)
            {
                take_tile_txt.GetComponent<Text>().text = "Player 1의 차례 입니다\n 숫자 타일을 1장 골라주세요";
            }
            // 2P 모드 시작 후 2Player 차례
            else if (d_gamescene.game_mode == 2)
            {
                take_tile_txt.GetComponent<Text>().text = "Player 2의 차례 입니다\n 숫자 타일을 1장 골라주세요";
            }
            // 1P 모드 시작 후 1Player 차례
            else
            {
                // CPU 진행 패널 만들어서 그 패널 띄워줘야 함
            }
        }
        
    }
}
