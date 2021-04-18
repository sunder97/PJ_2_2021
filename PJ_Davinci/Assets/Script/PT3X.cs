using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT3X : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject[] pt3xTile = new GameObject[14];
    public GameObject[] pt3xTiletxt = new GameObject[14];

    public GameObject pt3xtxt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        turn_endView();
    }

    // 실패 시, 카드 보여주면서 턴 넘어가기 전 화면
    public void turn_endView()
    {
        pt3xtxt.GetComponent<Text>().text = "Player " + d_gamescene.player_turn + "의 차례 입니다\n틀렸습니다, 타일이 공개됩니다";

        for (int i = 0; i < 14; i++)
        {
            if (d_gamescene.player_turn == 1)
            {
                // Black 3, 4
                if (d_gamescene.p1_tile_state[i] >= 3)
                {
                    if (d_gamescene.p1_tile_state[i] == 3) pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                    else
                    {
                        pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                        pt3xTiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p1_tile[i] + "</color>";
                    }
                }
                // White 1, 2
                else if (d_gamescene.p1_tile_state[i] >= 1)
                {
                    if (d_gamescene.p1_tile_state[i] == 1) pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                    else
                    {
                        pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                        pt3xTiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p1_tile[i] + "</color>";
                    }
                }
                // None 0
                else
                {
                    pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                    pt3xTiletxt[i].GetComponent<Text>().text = "";
                }
            }
            else
            {
                // Black 3, 4
                if (d_gamescene.p2_tile_state[i] >= 3)
                {
                    if (d_gamescene.p2_tile_state[i] == 3) pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                    else
                    {
                        pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                        pt3xTiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p2_tile[i] + "</color>";
                    }
                }
                // White 1, 2
                else if (d_gamescene.p2_tile_state[i] >= 1)
                {
                    if (d_gamescene.p2_tile_state[i] == 1) pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                    else
                    {
                        pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                        pt3xTiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p2_tile[i] + "</color>";
                    }
                }
                // None 0
                else
                {
                    pt3xTile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                    pt3xTiletxt[i].GetComponent<Text>().text = "";
                }
            }
        }
    }

    // 실패 시, 턴 넘김
    public void turn_end()
    {
        if (d_gamescene.player_turn == 1) d_gamescene.player_turn = 2;
        else d_gamescene.player_turn = 1;
        d_gamescene.game_state = 1;
        d_gamescene.p_t3x.SetActive(false);
    }
}
