using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

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

    
    public void w_take()
    {
        ran_num = Random.Range(0, d_gamescene.white_tile.Count());

        if (d_gamescene.player_turn == 1)
        {
            d_gamescene.p1_tile[d_gamescene.p1_count] = d_gamescene.white_tile[ran_num];
            d_gamescene.p1_count++;
            d_gamescene.p1_wcount++;
            d_gamescene.white_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1)
            {
                d_gamescene.game_state = 2;
            }
        }
        else
        {
            d_gamescene.p2_tile[d_gamescene.p2_count] = d_gamescene.white_tile[ran_num];
            d_gamescene.p2_count++;
            d_gamescene.p2_wcount++;
            d_gamescene.white_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1) d_gamescene.game_state = 2;
        }
    }
    public void b_take()
    {
        ran_num = Random.Range(0, d_gamescene.black_tile.Count());

        if (d_gamescene.player_turn == 1)
        {
            d_gamescene.p1_tile[d_gamescene.p1_count] = d_gamescene.black_tile[ran_num];
            d_gamescene.p1_count++;
            d_gamescene.p1_bcount++;
            d_gamescene.black_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1) d_gamescene.game_state = 2;
        }
        else
        {
            d_gamescene.p2_tile[d_gamescene.p2_count] = d_gamescene.black_tile[ran_num];
            d_gamescene.p2_count++;
            d_gamescene.p2_bcount++;
            d_gamescene.black_tile.RemoveAt(ran_num);
            if (d_gamescene.game_state == 1) d_gamescene.game_state = 2;
        }
    }
    
}
