using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGame_state : MonoBehaviour
{
    // 기본 변수
    public GameObject game_txt;                                                         // 전체적인 진행 단계를 보여주는 텍스트
    public GameObject p0f, p0fs, p1, p01, p2pc, p2c, p2r, p3, p4r;                      // 패널
    public GameObject Cf1, Cf2, Cf3, Cf4, Cf5, Cfs1, Cfs2, Cfs3, Cfs4, Cfs5, Cfs6;      // 초기화에 필요한 오브젝트
    public string[] p_name;                                                             // 플레이어 이름
    int players = 0;                                                                    // 플레이어 수
    int turn_player = 0;                                                                // 플레이어의 턴 체크
    public int game_state = 0;                                                          // game 시작 후, game의 상태
    public int[] role_card = new int[6];                            // 역할 카드. 1이 해적, 2가 스켈레톤


    // 0단계
    public GameObject p0r_txt;                                  // 진행 0단계 텍스트 변경을 위한 오브젝트
    public int[] player_team = new int[] { 0, 0, 0, 0, 0, 0 };  // 플레이어 세력 넣는 변수


    // 1단계
    public GameObject p1_txt_tr, p1_txt_ntk, p1_txt_box;    // 진행 1단계 텍스트 변경을 위한 오브젝트
    public int player_card_check = 0;                       // 플레이어가 자신의 카드를 확인하는 단계, 0은 바로 뜨는 것을 방지하기 위해 미리 뜨는 화면
    public int[] game_card;                                 // 플레이어 수에 따른 탐험카드 개수
    public int[] game_card_s;                               // 셔플용 플레이어 체크 함수
    public int[,] player_card = new int[6, 5];              // 플레이어 소지 카드 변수
                                                            // 플레이어 소지 카드 개수 변수
    public int[,] player_card_num = new int[6, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };


    // 2단계
    public GameObject p2_txt, p2_nc_txt;                    // 진행 2단계 텍스트 변경을 위한 오브젝트
    public GameObject p2c1, p2c2, p2c3, p2c4, p2c5;         // 뽑을 카드
    public GameObject p2r_txt, p2r_img;
    public int[] choose_card = new int[3] { 0, 0, 0 };      // 현재까지 뽑힌 카드
    int p_cnum = 0;                                         // 진행 2단계 플레이어 선택에 쓰일 변수
    public int round_count = 1;                             // 현재 라운드의 수
    public int take_card_num = 0;                           // 현재 라운드에서 공개된 카드의 개수



    // Start is called before the first frame update
    void Start()
    {
        players = PlayerPrefs.GetInt("player_num");
        // Debug.Log(players);

        game_card = new int[] { 15 + (PlayerPrefs.GetInt("player_num") - 4) * 4, PlayerPrefs.GetInt("player_num"), 1 };
        // Debug.Log(game_card[0] + " " + game_card[1] + " " + game_card[2]);

        p_name = new string[] { PlayerPrefs.GetString("p1"), PlayerPrefs.GetString("p2"), PlayerPrefs.GetString("p3"), PlayerPrefs.GetString("p4"), PlayerPrefs.GetString("p5"), PlayerPrefs.GetString("p6") };


        role_card = new int[] { 1, 1, 1, 2, 2, 1 };
        Debug.Log(role_card[0] + " " + role_card[1] + " " + role_card[2] + " " + role_card[3] + " " + role_card[4] + " " + role_card[5]);
        turn_player = 1;
        game_ready();
        shuffle(1);
        Debug.Log(role_card[0] + " " + role_card[1] + " " + role_card[2] + " " + role_card[3] + " " + role_card[4] + " " + role_card[5]);
    }

    // Update is called once per frame
    // 게임의 상태를 파악해, 텍스트를 바꾸는 것으로 활용하려고 합니다.
    void Update()
    {
        if (game_state == -1)
            game_txt.GetComponent<Text>().text = "";
        else if (game_state == 0)
            game_txt.GetComponent<Text>().text = "0. 게임 준비  자신의 세력을 고를 차례입니다.\n" + p_name[turn_player - 1] + "의 차례입니다.";
        else if (game_state == 1)
            game_txt.GetComponent<Text>().text = "1. 카드 분배  현재 " + round_count + "라운드 입니다.\n" + p_name[turn_player - 1] + "가 가진 카드는 다음과 같습니다.";
        else if (game_state == 2)
            game_txt.GetComponent<Text>().text = "2. 라운드 진행  현재 " + round_count + "라운드 입니다.\n" + p_name[turn_player - 1] + "님, 카드를 뽑을 플레이어를 선택해주세요.";
        else if (game_state == 3)
            game_txt.GetComponent<Text>().text = "3. 라운드 진행 결과  현재 " + round_count + "라운드의 진행 결과,\n 빈 상자 " + choose_card[0] + "장, 보물 상자 " + choose_card[1] + "장이 나왔습니다.";
        else if (game_state == 4)
            game_txt.GetComponent<Text>().text = "0. 게임 준비\n자신의 세력을 고를 차례입니다. Player " + turn_player + "의 차례입니다.";

    }

    // Game Reset 함수
    void game_reset()
    {
        shuffle(0);
    }


    // Game_state 0. 게임 준비      게임 시작 전, 세력을 나누는 단계

    // 롤 카드 섞기/초기화          게임이 끝나면 다시 원래대로 초기화 시키기 위한 함수
    void shuffle(int num)
    {
        if (num == 1)
        {
            for (int i = 0; i < players; i++)
            {
                int ran1 = Random.Range(0, players+1);
                int ran2 = Random.Range(0, players+1);

                int t;

                t = role_card[ran1];
                role_card[ran1] = role_card[ran2];
                role_card[ran2] = t;


                Debug.Log("i는 " + i + "이고, " + ran1 + " " + ran2 + "/" + role_card[0] + " " + role_card[1] + " " + role_card[2] + " " + role_card[3] + " " + role_card[4] + " ");
            }
        }
        else
        {
            role_card = new int[] { 1, 1, 1, 2, 2, 1 };
        }
    }

    // 플레이어 수에 맞는 패널 띄우기
    void game_ready()
    {
        if (players == 4)
        {
            p0f.SetActive(true);
        }
        else
        {
            p0fs.SetActive(true);
        }
    }

    // 카드 클릭 시에, 그 카드에 맞는 세력을 플레이어에게 부여
    public void Team_Choice()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Card1") { Debug.Log("card1"); player_team[turn_player-1] = role_card[0]; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card2") { Debug.Log("card2"); player_team[turn_player - 1] = role_card[1]; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card3") { Debug.Log("card3"); player_team[turn_player - 1] = role_card[2]; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card4") { Debug.Log("card4"); player_team[turn_player - 1] = role_card[3]; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card5") { Debug.Log("card5"); player_team[turn_player - 1] = role_card[4]; }
        else player_team[5] = role_card[5];

        if (player_team[turn_player - 1] == 1)
            p0r_txt.GetComponent<Text>().text = "Player " + turn_player + "의 세력은\n해적입니다.";
        else
            p0r_txt.GetComponent<Text>().text = "Player " + turn_player + "의 세력은\n스켈레톤입니다.";


        if (players == turn_player)
        {
            p0f.SetActive(false);
            p0fs.SetActive(false);
        }
    }

    // 플레이어 전부 역할 선정이 끝났을 경우 게임 시작 상태로 넘기고 그렇지 않을 경우에는 다음 플레이어 차례로 넘긴다.
    public void role_check()
    {
        if (players == turn_player)
        {
            turn_player = 0;
            game_state = -1;
            p01.SetActive(true);
            return;
        }

        turn_player++;
    }

    // Game_state 1. 카드 분배      각 라운드 시작 전 카드를 자동으로 나누어 자신의 카드를 확인하는 단계

    // 카드를 셔플하여 플레이어에게 배정하는 함수
    public void play_card_shuffle()
    {
        game_card_s = game_card;
        for (int i = 0; i < players; i++)
        {
            for (int j = 0; j < 5 - round_count; j++)
            {
                int ran_num = Random.Range(0, game_card_s[0] + game_card_s[1] + game_card_s[2]);

                if (ran_num < game_card_s[0])
                {
                    player_card[i,j] = 0;
                    player_card_num[i,0]++;
                    game_card_s[0]--;
                }
                else if (ran_num < game_card_s[0] + game_card_s[1])
                {
                    player_card[i,j] = 1;
                    player_card_num[i,1]++;
                    game_card_s[1]--;
                }
                else
                {
                    player_card[i,j] = 2;
                    player_card_num[i,2]++;
                    game_card_s[2]--;
                }

                Debug.Log("d: " + game_card[0] + " " + game_card[1] + " " + game_card[2]);
                Debug.Log("s: " + game_card_s[0] + " " + game_card_s[1] + " " + game_card_s[2]);
            }
        }

        game_state = 1;
        play_card_check();
    }

    // 플레이어에게 보여주는 정보를 띄워주는 함수, 턴 넘기기 및 다음 상태로 넘어가기 위한 함수
    public void play_card_check()
    {
        turn_player++;

        if (turn_player > players)
        {
            turn_player = 1;
            game_state = 2;
            p1.SetActive(false);
            p2pc.SetActive(true);
            p2_txt.GetComponent<Text>().text = p_name[p_cnum];
            return;
        }

        p1_txt_box.GetComponent<Text>().text = "x " + player_card_num[turn_player - 1, 0];
        p1_txt_tr.GetComponent<Text>().text = "x " + player_card_num[turn_player - 1, 1];
        p1_txt_ntk.GetComponent<Text>().text = "x " + player_card_num[turn_player - 1, 2];
    }

    // Game_state 2. 라운드 진행    라운드를 진행하며, 플레이어의 인원수에 맞추어 뽑을 카드를 선택하고 뽑는 단계

    // 플레이어 선택용 버튼1
    public void player_choice_prev()
    {
        if (p_cnum == 0) p_cnum = players - 1;
        else p_cnum--;
        p2_txt.GetComponent<Text>().text = p_name[p_cnum];
    }

    // 플레이어 선택용 버튼2
    public void player_choice_next()
    {
        if (p_cnum == players - 1) p_cnum = 0;
        else p_cnum++;
        p2_txt.GetComponent<Text>().text = p_name[p_cnum];
    }

    // 플레이어 선택후 Ok 버튼
    public void player_choice_ok()
    {
        if (p_cnum + 1 == turn_player)
        {
            p2_nc_txt.GetComponent<Text>().text = "자신의 카드를 선택할 수 없습니다. 다시 선택해주세요.";
        }

        if (player_card[p_cnum, 0] == -1) p2c1.SetActive(false);
        else p2c1.SetActive(true);
        if (player_card[p_cnum, 1] == -1) p2c2.SetActive(false);
        else p2c2.SetActive(true);
        if (player_card[p_cnum, 2] == -1) p2c3.SetActive(false);
        else p2c3.SetActive(true);
        if (player_card[p_cnum, 3] == -1) p2c4.SetActive(false);
        else p2c4.SetActive(true);
        if (player_card[p_cnum, 4] == -1) p2c5.SetActive(false);
        else p2c5.SetActive(true);
    }

    // 플레이어 카드 선택
    public void play_card_choice()
    {
        take_card_num++;

        if (EventSystem.current.currentSelectedGameObject.name == "Card1") { PlayerPrefs.SetInt("choice_card", player_card[p_cnum, 0]); player_card[p_cnum, 0] = -1; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card2") { PlayerPrefs.SetInt("choice_card", player_card[p_cnum, 1]); player_card[p_cnum, 1] = -1; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card3") { PlayerPrefs.SetInt("choice_card", player_card[p_cnum, 2]); player_card[p_cnum, 2] = -1; }
        else if (EventSystem.current.currentSelectedGameObject.name == "Card4") { PlayerPrefs.SetInt("choice_card", player_card[p_cnum, 3]); player_card[p_cnum, 3] = -1; }
        else { PlayerPrefs.SetInt("choice_card", player_card[p_cnum, 4]); player_card[p_cnum, 4] = -1; }

        int card_num = PlayerPrefs.GetInt("choice_card");

        if (card_num == 0) {
            choose_card[0]++; player_card_num[p_cnum, 0]--;
            p2r_txt.GetComponent<Text>().text = "뽑은 카드는\n 빈 상자입니다. 현재 라운드에서 뽑은 카드는 " + take_card_num + "장이며, " + p_name[p_cnum] + "의 차례로 넘어갑니다.";
        }
        else if (card_num == 1) {
            choose_card[1]++; player_card_num[p_cnum, 1]--;
            p2r_txt.GetComponent<Text>().text = "뽑은 카드는\n 보물 상자입니다. 현재 라운드에서 뽑은 카드는 " + take_card_num + "장이며, " + p_name[p_cnum] + "의 차례로 넘어갑니다.";
        }
        else {
            choose_card[2]++; player_card_num[p_cnum, 2]--;
            p2r_txt.GetComponent<Text>().text = "뽑은 카드는\n 크라켄입니다. 결과창으로 넘어갑니다.";
        }

        turn_player = p_cnum + 1;
    }

    // 라운드에서 뽑은 카드 개수를 확인하고 현재 라운드를 종료할지, 다음 턴을 이어갈지 결정합니다.
    public void round_check()
    {
        if (choose_card[2] == 1) { p4r.SetActive(true); return; }       // 크라켄 뽑았을 때 결과창 이동

        p2_nc_txt.GetComponent<Text>().text = "";

        if (take_card_num == players) { game_state++; p3.SetActive(true); }
        else p2pc.SetActive(true);
    }

    // Game_state 3. 현재 진행사항  라운드가 종료되고, 현재 뽑힌 보물상자의 개수를 확인하는 단계
    // Game_state 4. 결과창         크라켄 혹은 보물상자가 전부 뽑혔을 때, 승리 세력 플레이어와 패배 세력 플레이어를 확인시켜주는 단계

}
