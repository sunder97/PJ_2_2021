﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_state : MonoBehaviour
{
    public Text pnum_txt;

    public int pnum = 4;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1440, 2960, false);
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
