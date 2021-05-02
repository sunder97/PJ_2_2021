using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어가 선택한 타일의 예상되는 숫자를 입력하는 단계의 스크립트
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

    void Update()
    {

    }

    /*
     * 확인 버튼을 눌렀을 때, 입력된 숫자가 없을 경우 혹은 입력된 문자가 숫자가 아닐 경우에 안내 패널이 실행되어야 합니다.
     */

    // 아직 미구현

    // 플레이어가 타일의 숫자를 입력 후 버튼 터치 시 실행되는 함수
    public void pt2_btn()
    {
        // 일치했을 때
        if (d_gamescene.choiceNum == int.Parse(input_num.text))
        {
            // 맞춘 상대의 타일을 공개하고, pt3o로 이동

            // 플레이어 1
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
            // 플레이어 2
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
        // 일치하지 않았을 때
        else
        {
            // 자신이 이번 턴에 가져온 타일을 공개하고, pt3x로 이동

            // 플레이어 1
            if (d_gamescene.player_turn == 1)
            {
                d_gamescene.p1_tile_state[d_gamescene.turnidx]++;
                if (d_gamescene.p1_tile_state[d_gamescene.turnidx] == 2) d_gamescene.p1_wcount--;
                else d_gamescene.p1_bcount--;
            }
            // 플레이어 2
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
