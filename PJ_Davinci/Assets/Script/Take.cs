using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

// 카드 선택 시 실행되는 스크립트
public class Take : MonoBehaviour
{
    D_GameScene d_gamescene;

    // Start is called before the first frame update

    int ran_num;
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 하얀색 타일 선택 시 실행되는 함수 :: 하얀색 타일 배열 내 랜덤 위치의 타일을 플레이어의 타일로 가져옴
    public void w_take()
    {
        Debug.Log(d_gamescene.white_tile.Count());
        if (d_gamescene.white_tile.Count() == 1)
        {
            d_gamescene.nob_tile.SetActive(true);
            d_gamescene.nob_tile_txt.GetComponent<Text>().text = "현재 남아있는\n백색 타일이 없습니다";
            return;
        }

        ran_num = Random.Range(1, d_gamescene.white_tile.Count());

        // 플레이어 1
        if (d_gamescene.player_turn == 1)
        {
            d_gamescene.p1_tile[d_gamescene.p1_count] = d_gamescene.white_tile[ran_num];
            d_gamescene.p1_tile_state[d_gamescene.p1_count] = 1;
            card_swap(1, d_gamescene.p1_count);
            d_gamescene.p1_count++;
            d_gamescene.p1_wcount++;
            d_gamescene.white_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1)
            {
                d_gamescene.game_state = 2;
            }
        }
        // 플레이어 2
        else
        {
            d_gamescene.p2_tile[d_gamescene.p2_count] = d_gamescene.white_tile[ran_num];
            d_gamescene.p2_tile_state[d_gamescene.p2_count] = 1;
            card_swap(2, d_gamescene.p2_count);
            d_gamescene.p2_count++;
            d_gamescene.p2_wcount++;
            d_gamescene.white_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1) d_gamescene.game_state = 2;
        }
    }

    // 검정색 타일 선택 시 실행되는 함수 :: 검정색 타일 배열 내 랜덤 위치의 타일을 플레이어의 타일로 가져옴
    public void b_take()
    {
        if (d_gamescene.black_tile.Count() == 1)
        {
            d_gamescene.nob_tile.SetActive(true);
            d_gamescene.nob_tile_txt.GetComponent<Text>().text = "현재 남아있는\n흑색 타일이 없습니다";
            return;
        }

        ran_num = Random.Range(1, d_gamescene.black_tile.Count());

        // 플레이어 1
        if (d_gamescene.player_turn == 1)
        {
            d_gamescene.p1_tile[d_gamescene.p1_count] = d_gamescene.black_tile[ran_num];
            d_gamescene.p1_tile_state[d_gamescene.p1_count] = 3;
            card_swap(1, d_gamescene.p1_count);
            d_gamescene.p1_count++;
            d_gamescene.p1_bcount++;
            d_gamescene.black_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1) d_gamescene.game_state = 2;
        }
        // 플레이어 2
        else
        {
            d_gamescene.p2_tile[d_gamescene.p2_count] = d_gamescene.black_tile[ran_num];
            d_gamescene.p2_tile_state[d_gamescene.p2_count] = 3;
            card_swap(2, d_gamescene.p2_count);
            d_gamescene.p2_count++;
            d_gamescene.p2_bcount++;
            d_gamescene.black_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1) d_gamescene.game_state = 2;
        }
    }
    
    // 가져온 타일을 숫자 및 색상에 따라 정렬해주는 함수
    void card_swap(int p_turn, int p_count)
    {
        int swap;

        for (int pc = p_count; pc > 0; pc--)
        {
            // 플레이어 1
            if (p_turn == 1)
            {
                if (d_gamescene.p1_tile[pc] > d_gamescene.p1_tile[pc - 1])
                {
                    d_gamescene.turncolor = d_gamescene.p1_tile_state[pc];
                    d_gamescene.turnidx = pc;
                    break;
                }
                else if ((d_gamescene.p1_tile[pc] == d_gamescene.p1_tile[pc - 1]) && (d_gamescene.p1_tile_state[pc] > d_gamescene.p1_tile_state[pc - 1]))
                {
                    d_gamescene.turncolor = d_gamescene.p1_tile_state[pc];
                    d_gamescene.turnidx = pc;
                    break;
                }


                swap = d_gamescene.p1_tile[pc];
                d_gamescene.p1_tile[pc] = d_gamescene.p1_tile[pc - 1];
                d_gamescene.p1_tile[pc - 1] = swap;

                swap = d_gamescene.p1_tile_state[pc];
                d_gamescene.p1_tile_state[pc] = d_gamescene.p1_tile_state[pc - 1];
                d_gamescene.p1_tile_state[pc - 1] = swap;

                if (pc == 1)
                {
                    d_gamescene.turncolor = d_gamescene.p1_tile_state[0];
                    d_gamescene.turnidx = 0;
                }
            }

            // 플레이어 2
            else
            {
                if (d_gamescene.p2_tile[pc] > d_gamescene.p2_tile[pc - 1])
                {
                    d_gamescene.turncolor = d_gamescene.p2_tile_state[pc];
                    d_gamescene.turnidx = pc;
                    break;
                }
                else if ((d_gamescene.p2_tile[pc] == d_gamescene.p2_tile[pc - 1]) && (d_gamescene.p2_tile_state[pc] > d_gamescene.p2_tile_state[pc - 1]))
                {
                    d_gamescene.turncolor = d_gamescene.p2_tile_state[pc];
                    d_gamescene.turnidx = pc;
                    break;
                }

                swap = d_gamescene.p2_tile[pc];
                d_gamescene.p2_tile[pc] = d_gamescene.p2_tile[pc - 1];
                d_gamescene.p2_tile[pc - 1] = swap;

                swap = d_gamescene.p2_tile_state[pc];
                d_gamescene.p2_tile_state[pc] = d_gamescene.p2_tile_state[pc - 1];
                d_gamescene.p2_tile_state[pc - 1] = swap;

                if (pc == 1)
                {
                    d_gamescene.turncolor = d_gamescene.p2_tile_state[pc];
                    d_gamescene.turnidx = 0;
                }
            }
        }
    }

}
