using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CT1 : MonoBehaviour
{
    D_GameScene d_gamescene;
    Take take_tile;
    // Start is called before the first frame update
    void Start()
    {
        d_gamescene = GameObject.Find("Canvas").GetComponent<D_GameScene>();
        take_tile = GameObject.Find("Canvas").GetComponent<Take>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cpuTurn()
    {
        int rn = Random.Range(0, 2);
        d_gamescene.player_turn = 2;
        if (rn == 0) take_tile.w_take();
        else take_tile.b_take();
        d_gamescene.player_turn = 1;

        // CPU의 AI를 만들어야 합니다.

        /* 대안 0
         * 그냥 무조건 1개 성공하고 턴넘기는지 안넘기는지만 체크하기
         */

        /*
        while (true)
        {
            while (true)
            {
                int oo = Random.Range(0, d_gamescene.p1_count + 1);

                if (d_gamescene.p1_tile_state[oo] % 2 == 1)
                {
                    d_gamescene.p1_tile_state[oo]++;
                    break;
                }
            }
            d_gamescene.cpucnt = 1;
            }
            int over = Random.Range(0, 2);

            if (over == 0)
            {
                d_gamescene.p2_tile_state[d_gamescene.turnidx]++;
                if (d_gamescene.turncolor == 3) d_gamescene.p2_bcount--;
                else d_gamescene.p2_wcount--;
                d_gamescene.cpu_oorc = false;
                break;
            }
            else
            {
                d_gamescene.cpu_oorc = true;
                break;
            }
        }
        */

        /* 대안 1
         * 전체 타일 개수는 28개이며 그 중 자신의 타일 개수+상대의 밝혀진 타일 개수를 제외한 나머지 타일의 숫자를 체크합니다.
         * 전체 개수 - 자신의 타일 개수+상대의 밝혀진 타일 개수를 A라 칭하면,
         * 랜덤으로 1~28까지의 숫자를 내보낸 후, 그 숫자가 A보다 클 경우에는 CPU가 타일을 맞춘 것으로 체크하여 진행합니다.
         */
        /*
        while (true)
        {
            int ox = Random.Range(1, 29);
            int A = 28 - d_gamescene.p2_count - (d_gamescene.p1_count - d_gamescene.p1_wcount - d_gamescene.p1_bcount);

            if (ox > A)
            {
                while (true)
                {
                    int oo = Random.Range(0, d_gamescene.p1_count + 1);

                    if (d_gamescene.p1_tile_state[oo] % 2 == 1)
                    {
                        d_gamescene.p1_tile_state[oo]++;
                        break;
                    }
                }
                d_gamescene.cpucnt++;
            }
            else
            {
                d_gamescene.p2_tile_state[d_gamescene.turnidx]++;
                if (d_gamescene.turncolor == 3) d_gamescene.p2_bcount--;
                else d_gamescene.p2_wcount--;
                d_gamescene.cpu_oorc = false;
                break;
            }

            if (ox % 2 == 0)
            {
                d_gamescene.cpu_oorc = true;
                break;
            }
        }
        */

        /* 대안 2
         * 대안 1과 동일하나, 대안 1에서 CPU가 이길 확률이 꽤 낮다는 생각이 들어 CPU가 못 맞추고 턴을 종료한 턴의 횟수를 세어 그마다 CPU가 맞출 확률을 높여주었습니다.
         */


        int count_check = 0;

        while (true)
        {
            int ox = Random.Range(1, 29);
            int A = 28 - d_gamescene.p2_count - (d_gamescene.p1_count - d_gamescene.p1_wcount - d_gamescene.p1_bcount) - (d_gamescene.cpu_notO*2);


            if (ox > A)
            {
                while (true)
                {
                    int oo = Random.Range(0, d_gamescene.p1_count + 1);

                    if (d_gamescene.p1_tile_state[oo] % 2 == 1)
                    {
                        d_gamescene.p1_tile_state[oo]++;
                        break;
                    }
                }
                count_check++;
                d_gamescene.cpucnt++;
            }
            else
            {
                d_gamescene.p2_tile_state[d_gamescene.turnidx]++;
                if (d_gamescene.turncolor == 3) d_gamescene.p2_bcount--;
                else d_gamescene.p2_wcount--;
                d_gamescene.cpu_oorc = false;

                if (count_check == 0) d_gamescene.cpu_notO++;       // cpu가 1개의 타일도 맞추지 못하고 턴이 넘어갈 경우, cpu가 맞출 확률을 조금 높여줌

                break;
            }

            if (ox % 2 == 0)
            {
                d_gamescene.cpu_oorc = true;
                break;
            }
        }

        /* 추가 보정안
         * 앞 타일들부터 체크해 밝혀진 타일의 숫자를 저장해둔 뒤,
         * 다음 밝혀진 타일까지의 사이의 타일 개수와 다음 밝혀진 타일의 숫자를 비교해 사이 숫자가 타이트하게 맞으면 (색상까지)
         * 그 사이의 타일들은 전부다 맞출 수 있게 합니다.
         */

        // 아직 미구현

    }

    // AI를 진행한 후, CPU 턴 진행을 보여주는 결과창으로 이동하는 함수
    public void ct2move()
    {
        cpuTurn();
        d_gamescene.game_state = -2;
    }
}
