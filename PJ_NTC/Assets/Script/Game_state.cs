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

    public InputField p1_str, p2_str, p3_str, p4_str, p5_str, p6_str;
    public GameObject p1_txt, p2_txt, p3_txt, p4_txt, p5_txt, p6_txt;

    public GameObject nc_check_txt;
    public int nc_check_ver;

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
