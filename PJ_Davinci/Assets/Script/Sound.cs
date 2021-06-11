using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// 사운드 스크립트, 아직 미구현
public class Sound : MonoBehaviour
{
    public Slider BGMslider;
    private AudioSource bgm;
    private GameObject[] musics;

    private float bgmvolGage = 1f;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        bgmvolGage = PlayerPrefs.GetFloat("bgmvolGage", 1f);
        BGMslider.value = bgmvolGage;
        bgm.volume = BGMslider.value;
    }

    // Update is called once per frame
    void Update()
    {
        BGMSliderF();
    }

    public void BGMSliderF()
    {
        bgm.volume = BGMslider.value;
        bgmvolGage = BGMslider.value;
        PlayerPrefs.SetFloat("bgmvolGage", 1f);
    }
}
