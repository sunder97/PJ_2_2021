using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main_btn : MonoBehaviour
{
    Game_state gamestate;

    public GameObject m_prev, m_next, m1, m2, m3;
    // Start is called before the first frame update
    void Start()
    {
        gamestate = GameObject.Find("Canvas").GetComponent<Game_state>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate.menual_page_num == 1)
        {
            m_prev.SetActive(false);
            m_next.SetActive(true);
            m1.SetActive(true);
            m2.SetActive(false);
            m3.SetActive(false);
        }
        else if (gamestate.menual_page_num == 2)
        {
            m_prev.SetActive(true);
            m_next.SetActive(true);
            m1.SetActive(false);
            m2.SetActive(true);
            m3.SetActive(false);
        }
        else if (gamestate.menual_page_num == 3)
        {
            m_next.SetActive(false);
            m1.SetActive(false);
            m2.SetActive(false);
            m3.SetActive(true);
        }
    }

    public void pup_btn()
    {
        if (gamestate.pnum < 6) gamestate.pnum += 1;
    }

    public void pdown_btn()
    {
        if (gamestate.pnum > 4) gamestate.pnum -= 1;
    }

    public void quit_btn()
    {
        Application.Quit();
    }

    public void start_btn()
    {
        PlayerPrefs.SetInt("player_num", gamestate.pnum);
        SceneManager.LoadScene("Game_Scene");
    }

    public void menual_next_btn()
    {
        gamestate.menual_page_num += 1;
    }
    public void menual_prev_btn()
    {
        gamestate.menual_page_num -= 1;
    }

    public void menual_quit_btn()
    {
        gamestate.menual_page_num = 1;
    }

    public void name_change_x_btn()
    {
        return;
    }
    public void name_change_ok_btn()
    {
        return;
    }
}
