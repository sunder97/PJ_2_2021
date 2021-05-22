using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_btn : MonoBehaviour
{
    Game_state gamestate;
    // Start is called before the first frame update
    void Start()
    {
        gamestate = GameObject.Find("Canvas").GetComponent<Game_state>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pup_btn()
    {
        if (gamestate.pnum < 6) gamestate.pnum += 1;
    }

    public void pdown_btn()
    {
        if (gamestate.pnum > 4) gamestate.pnum -= 1;
    }
}
