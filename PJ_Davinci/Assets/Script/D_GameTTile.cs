using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 시작 전 카드 4장 뽑기 단계 및 플레이어 턴 시작 시 카드 1장을 뽑는 단계 노출
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
        // 1플레이어의 턴일 때, 해당 플레이어가 가진 색상별 타일의 개수를 보여줌
        if (d_gamescene.player_turn == 1)
        {
            White_num.GetComponent<Text>().text = "x " + d_gamescene.p1_wcount;
            Black_num.GetComponent<Text>().text = "x " + d_gamescene.p1_bcount;
        }
        // 2플레이어의 턴일 때, 해당 플레이어가 가진 색상별 타일의 개수를 보여줌
        else
        {
            White_num.GetComponent<Text>().text = "x " + d_gamescene.p2_wcount;
            Black_num.GetComponent<Text>().text = "x " + d_gamescene.p2_bcount;
        }

        // 게임 시작 전 각 플레이어가 타일 4장을 뽑는 단계
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
        
        // 게임 시작 후 플레이어가 턴을 시작하고 나서 처음 타일 1장을 뽑는 단계
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
        }
        
    }

    /* 
     * 타일을 뽑는 단계에서 생기는 버그
     * 한 색상의 모든 타일을 다 뽑은 경우에 더 이상 해당 아이콘 클릭 시 함수가 실행되지 않게 해야합니다.
     * 간단히 함수를 실행되지 않게 하는 것 보다, UI적인 측면에서 플레이어에게 더 이상 타일이 존재하지 않는 다는 것을 보여줘야 합니다.
     * 따라서, 아이콘의 변경이나 안내 패널 등의 코드가 필요합니다.
     */

    // 아직 미구현

}
