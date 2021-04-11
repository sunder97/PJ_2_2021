using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_GameTTile : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject take_tile_txt;
    public GameObject White_num;
    public GameObject Black_num;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
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
            if (d_gamescene.player_turn == 1)
            {
                take_tile_txt.GetComponent<Text>().text = "Player 1의 차례 입니다\n 숫자 타일을 4장 골라주세요";
                if (d_gamescene.p1_count == 4) d_gamescene.player_turn = 2;
            }
            else
            {
                take_tile_txt.GetComponent<Text>().text = "Player 2의 차례 입니다\n 숫자 타일을 4장 골라주세요";
                if (d_gamescene.p2_count == 4)
                {
                    d_gamescene.game_state = 1;
                    d_gamescene.player_turn = 1;
                }
            }
        }
        else if (d_gamescene.game_state == 1)
        {
            if (d_gamescene.player_turn == 1)
            {
                take_tile_txt.GetComponent<Text>().text = "Player 1의 차례 입니다\n 숫자 타일을 1장 골라주세요";
            }
            else
            {
                take_tile_txt.GetComponent<Text>().text = "Player 2의 차례 입니다\n 숫자 타일을 1장 골라주세요";
            }
        }
        
    }
}
