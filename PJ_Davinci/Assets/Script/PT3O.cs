using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어가 상대의 타일을 맞췄을 때 실행되는 스크립트
public class PT3O : MonoBehaviour
{
    D_GameScene d_gamescene;

    public GameObject pt3otxt;
    public GameObject corr_tile;
    public GameObject corr_txt;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
    }

    // 인게임 내 노출되는 텍스트 및 맞춘 상대의 타일 이미지
    void Update()
    {
        pt3otxt.GetComponent<Text>().text = "현재 Player " + d_gamescene.player_turn + "의 차례 입니다\n맞았습니다! 더 하시겠습니까?";

        if (d_gamescene.choicecolor == 1) corr_tile.GetComponent<Image>().sprite = Resources.Load("WhiteO", typeof(Sprite)) as Sprite;
        else corr_tile.GetComponent<Image>().sprite = Resources.Load("BlackO", typeof(Sprite)) as Sprite;

        corr_txt.GetComponent<Text>().text = "" + d_gamescene.choiceNum;
    }

    // 맞췄을 때 한번더
    public void one_more()
    {
        d_gamescene.game_state = 2;
        d_gamescene.p_t3o.SetActive(false);
    }

    // 맞췄을 때 턴 종료
    public void turn_over()
    {
        // 2P 모드일 때
        if (d_gamescene.game_mode == 2)
        {
            if (d_gamescene.player_turn == 1) d_gamescene.player_turn = 2;
            else d_gamescene.player_turn = 1;
            d_gamescene.game_state = 1;
        }
        // 1P 모드일 때
        else
        {
            d_gamescene.game_state = -1;
        }
    }
}
