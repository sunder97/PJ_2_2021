using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_state : MonoBehaviour
{
    public Text pnum_txt;

    public int pnum = 4;                // player 수
    public int menual_page_num = 1;            // menual 페이지

    public string[] player_name = new string[] { "player 1", "player 2", "player 3", "player 4", "player 5", "player 6" };

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1440, 2960, true);
    }

    // Update is called once per frame
    void Update()
    {
        pnum_txt.GetComponent<Text>().text = "" + pnum;
    }

    public static implicit operator Game_state(GameObject v)
    {
        throw new NotImplementedException();
    }
}
