using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT2 : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject choice_tile;
    public InputField input_num;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (d_gamescene.choicecolor == 1) choice_tile.GetComponent<Image>().sprite = Resources.Load("White", typeof(Sprite)) as Sprite;
        // else if (d_gamescene.choicecolor == 3) choice_tile.GetComponent<Image>().sprite = Resources.Load("Black", typeof(Sprite)) as Sprite;
    }

    public void pt2_btn()
    {
        if (d_gamescene.choiceNum == int.Parse(input_num.text))
        {
            if (d_gamescene.player_turn == 1)
            {
                if (d_gamescene.choicecolor == 1) d_gamescene.p2_wcount--;
                else if (d_gamescene.choicecolor == 3) d_gamescene.p2_bcount--;

                d_gamescene.p2_tile_state[d_gamescene.choiceidx]++;

                if (d_gamescene.p2_bcount == 0 && d_gamescene.p2_wcount == 0)
                {
                    d_gamescene.game_state = 6;
                    return;
                }
            }
            else
            {
                if (d_gamescene.choicecolor == 1) d_gamescene.p1_wcount--;
                else if (d_gamescene.choicecolor == 3) d_gamescene.p1_bcount--;

                d_gamescene.p1_tile_state[d_gamescene.choiceidx]++;

                if (d_gamescene.p1_bcount == 0 && d_gamescene.p1_wcount == 0)
                {
                    d_gamescene.game_state = 6;
                    return;
                }
            }
            d_gamescene.game_state = 4;
        }
        else
        {
            if (d_gamescene.player_turn == 1)
            {
                d_gamescene.p1_tile_state[d_gamescene.turnidx]++;
                if (d_gamescene.p1_tile_state[d_gamescene.turnidx] == 2) d_gamescene.p1_wcount--;
                else d_gamescene.p1_bcount--;
            }
            else
            {
                d_gamescene.p2_tile_state[d_gamescene.turnidx]++;
                if (d_gamescene.p2_tile_state[d_gamescene.turnidx] == 2) d_gamescene.p2_wcount--;
                else d_gamescene.p2_bcount--;
            }
            d_gamescene.game_state = 5;
        }
    }
}
