using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 현재 자신이 가진 타일들의 상태를 확인하는 인게임 내 버튼용 스크립트
public class Deck_update : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject[] Tile = new GameObject[14];
    public GameObject[] Tiletxt = new GameObject[14];
    public GameObject Decktxt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        Deck_upt();
    }

    // 현재 턴인 플레이어가 가진 타일의 숫자를 보여주는 함수
    public void Deck_upt()
    {
        // 1P 모드에선 내부 변수인 player_turn이 바뀌지 않아 따로 추가할 코드가 없습니다.


        Decktxt.GetComponent<Text>().text = "현재 Player " + d_gamescene.player_turn + "이\n 가지고 있는 숫자입니다";

        // 최대 14장의 타일을 가지고 있을 수 있기 때문에, 14개의 타일을 확인해 소지한 타일만 노출
        for ( int i = 0; i < 14; i++ )
        {
            if (d_gamescene.player_turn == 1 )
            {
                // Black 3, 4
                if ( d_gamescene.p1_tile_state[i] >= 3 )
                {
                    if (d_gamescene.p1_tile_state[i] == 3) Tile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                    else Tile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                    Tiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p1_tile[i] + "</color>";
                }
                // White 1, 2
                else if (d_gamescene.p1_tile_state[i] >= 1 )
                {
                    if (d_gamescene.p1_tile_state[i] == 1) Tile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                    else Tile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                    Tiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p1_tile[i] + "</color>";
                }
                // None 0
                else
                {
                    Tile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                    Tiletxt[i].GetComponent<Text>().text = "";
                }
            }
            else
            {
                // Black 3, 4
                if (d_gamescene.p2_tile_state[i] >= 3)
                {
                    if (d_gamescene.p2_tile_state[i] == 3) Tile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                    else Tile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                    Tiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p2_tile[i] + "</color>";
                }
                // White 1, 2
                else if (d_gamescene.p2_tile_state[i] >= 1)
                {
                    if (d_gamescene.p2_tile_state[i] == 1) Tile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                    else Tile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                    Tiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p2_tile[i] + "</color>";
                }
                // None 0
                else
                {
                    Tile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                    Tiletxt[i].GetComponent<Text>().text = "";
                }
            }
        }
    }
}
