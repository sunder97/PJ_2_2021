using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CT2 : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject[] ct2Tile = new GameObject[14];
    public GameObject[] ct2Tiletxt = new GameObject[14];

    public GameObject ct2txt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        cpu_endview();
    }

    // cpu 상태 보여주고 턴 넘기기
    public void cpu_endview()
    {
        if (d_gamescene.cpu_oorc == true) ct2txt.GetComponent<Text>().text = "CPU는 " + d_gamescene.cpucnt + "개의 타일을 맞추었고\n턴을 종료했습니다";
        else ct2txt.GetComponent<Text>().text = "CPU는 " + d_gamescene.cpucnt + "개의 타일을 맞추었고\n실패하여 1개의 타일을 공개합니다";

        for (int i = 0; i < 14; i++)
        {
            // Black 3, 4
            if (d_gamescene.p2_tile_state[i] >= 3)
            {
                if (d_gamescene.p2_tile_state[i] == 3)
                {
                    ct2Tile[i].GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
                    ct2Tiletxt[i].GetComponent<Text>().text = "";
                }
                else
                {
                    ct2Tile[i].GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;
                    ct2Tiletxt[i].GetComponent<Text>().text = "<color=#ffffff>" + d_gamescene.p2_tile[i] + "</color>";
                }
            }
            // White 1, 2
            else if (d_gamescene.p2_tile_state[i] >= 1)
            {
                if (d_gamescene.p2_tile_state[i] == 1)
                {
                    ct2Tile[i].GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
                    ct2Tiletxt[i].GetComponent<Text>().text = "";
                }
                else
                {
                    ct2Tile[i].GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
                    ct2Tiletxt[i].GetComponent<Text>().text = "<color=#000000>" + d_gamescene.p2_tile[i] + "</color>";
                }
            }
            // None 0
            else
            {
                ct2Tile[i].GetComponent<Image>().sprite = Resources.Load("None", typeof(Sprite)) as Sprite;
                ct2Tiletxt[i].GetComponent<Text>().text = "";
            }
        }
    }

    public void cpu_turnend()
    {
        d_gamescene.game_state = 1;
    }
}
