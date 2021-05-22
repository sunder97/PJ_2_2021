using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_state_2 : MonoBehaviour
{
    public GameObject p0f, p0fs, p1;

    public int game_state = 0;          // game 시작 후, game의 상태
    public int player_card_check = 0;   // 플레이어가 자신의 카드를 확인하는 단계, 0은 바로 뜨는 것을 방지하기 위해 미리 뜨는 화면
    public int round_count = 0;         // 현재 라운드의 수
    public int take_card_num = 0;       // 현재 라운드에서 공개된 카드의 개수

    public int[] role_card = new int[] { 1, 1, 1, 1, 2, 2 };      // 역할 카드. 1이 해적, 2가 스켈레톤
    public int[] game_card = new int[] { 15 + (PlayerPrefs.GetInt("player_num")-4)*4, PlayerPrefs.GetInt("player_num"), 1 };    // 플레이어 수에 따른 탐험카드 개수


    public int[] player1 = new int[] { -1, -1, -1, -1, -1, -1 };
    public int[] player2 = new int[] { -1, -1, -1, -1, -1, -1 };
    public int[] player3 = new int[] { -1, -1, -1, -1, -1, -1 };
    public int[] player4 = new int[] { -1, -1, -1, -1, -1, -1 };
    public int[] player5 = new int[] { -1, -1, -1, -1, -1, -1 };
    public int[] player6 = new int[] { -1, -1, -1, -1, -1, -1 };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Game_state 0. 게임 준비      게임 시작 전, 세력을 나누는 단계
    // UI 해결

    // Game_state 1. 카드 분배      각 라운드 시작 전 카드를 자동으로 나누어 자신의 카드를 확인하는 단계
    // UI 해결
    
    // Game_state 2. 라운드 진행    라운드를 진행하며, 플레이어의 인원수에 맞추어 뽑을 카드를 선택하고 뽑는 단계
    // Game_state 3. 현재 진행사항  라운드가 종료되고, 현재 뽑힌 보물상자의 개수를 확인하는 단계
    // Game_state 4. 결과창         크라켄 혹은 보물상자가 전부 뽑혔을 때, 승리 세력 플레이어와 패배 세력 플레이어를 확인시켜주는 단계

}
