using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject gotxt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (d_gamescene.game_state == 6) gotxt.GetComponent<Text>().text = "축하합니다!\nPlayer " + d_gamescene.player_turn + "이 승리했습니다!";
    }

    public void gomain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
