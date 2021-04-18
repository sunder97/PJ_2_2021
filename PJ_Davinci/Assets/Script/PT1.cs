using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

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

    // Pt1에서 카드를 선택했을 때
    public void choice_num(int num)
    {
        if (d_gamescene.player_turn == 1)
        {
            if (d_gamescene.p2_tile[num] == -2 || d_gamescene.p2_tile_state[num] == 2 || d_gamescene.p2_tile_state[num] == 4)
            {
                Debug.Log("return");
                return;
            }
        }
        else
        {
            if (d_gamescene.p1_tile[num] == -2 || d_gamescene.p1_tile_state[num] == 2 || d_gamescene.p1_tile_state[num] == 4)
            {
                Debug.Log("return");
                return;
            }
        }

        d_gamescene.game_state = 3;
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
