using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

// 상대 타일 중 맞출 타일 하나를 선택하는 단계의 스크립트
public class PT1 : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject[] NTTile = new GameObject[14];
    public GameObject[] NTTiletxt = new GameObject[14];

    public GameObject pt1txt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        ntview();
    }
    
    // 상대 카드 띄워주는 함수
    void ntview()
    {

        pt1txt.GetComponent<Text>().text = "Player " + d_gamescene.player_turn + "의 차례입니다\n상대 타일 중 하나를 골라주세요";

        for (int i = 0; i < 14; i++)
        {
            if (d_gamescene.player_turn == 1)
            {
                // Black 3, 4
                if (d_gamescene.p2_tile_state[i] >= 3)
                {
                    if (d_gamescene.p2_tile_state[i] == 3)
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "";
                    }
                    else
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p2_tile[i] + "</color>";
                    }
                }
                // White 1, 2
                else if (d_gamescene.p2_tile_state[i] >= 1)
                {
                    if (d_gamescene.p2_tile_state[i] == 1)
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "";
                    }
                    else
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p2_tile[i] + "</color>";
                    }
                }
                // None 0
                else
                {
                    NTTile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                    NTTiletxt[i].GetComponent<Text>().text = "";
                }
                
            }
            else
            {
                // Black 3, 4
                if (d_gamescene.p1_tile_state[i] >= 3)
                {
                    if (d_gamescene.p1_tile_state[i] == 3)
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "";
                    }
                    else
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p1_tile[i] + "</color>";
                    }
                }
                // White 1, 2
                else if (d_gamescene.p1_tile_state[i] >= 1)
                {
                    if (d_gamescene.p1_tile_state[i] == 1)
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "";
                    }
                    else
                    {
                        NTTile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                        NTTiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p1_tile[i] + "</color>";
                    }
                }
                // None 0
                else
                {
                    NTTile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                    NTTiletxt[i].GetComponent<Text>().text = "";
                }
            }
        }
    }

    // Pt1 패널에서 타일을 선택했을 때 실행되는 함수
    public void choice_num(int num)
    {
        // 1플레이어의 턴
        if (d_gamescene.player_turn == 1)
        {
            // 선택한 타일이 이미 열린 타일일 경우 다른 기능 없이 리턴
            if (d_gamescene.p2_tile[num] == -2 || d_gamescene.p2_tile_state[num] == 2 || d_gamescene.p2_tile_state[num] == 4)
            {
                Debug.Log("return");
                return;
            }
        }
        // 2플레이어의 턴
        else
        {
            // 선택한 타일이 이미 열린 타일일 경우 다른 기능 없이 리턴
            if (d_gamescene.p1_tile[num] == -2 || d_gamescene.p1_tile_state[num] == 2 || d_gamescene.p1_tile_state[num] == 4)
            {
                Debug.Log("return");
                return;
            }
        }

    // 위의 경우에 해당되지 않는경우 실행되는 게임 진행 코드

        d_gamescene.game_state = 3;

        // 선택한 상대 타일의 정보를 저장해두어 다음 단계에서 타일의 숫자를 맞추는지 확인 및 맞추고나서 타일의 상태를 열린 타일로 바꿀 때 사용되는 변수들의 값 저장
        d_gamescene.choiceidx = num;
        if (d_gamescene.player_turn == 1)
        {
            d_gamescene.choicecolor = d_gamescene.p2_tile_state[num];
            d_gamescene.choiceNum = d_gamescene.p2_tile[num];
        }
        else
        {
            d_gamescene.choicecolor = d_gamescene.p1_tile_state[num];
            d_gamescene.choiceNum = d_gamescene.p1_tile[num];
        }
        Debug.Log(d_gamescene.choiceidx + " " + d_gamescene.choiceNum);
    }

}
