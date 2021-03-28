using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Slider BGMslider, SEslider;
    public AudioSource bgm, se;

    private float bgmvolGage = 1f;
    private float sevolGage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bgmvolGage = PlayerPrefs.GetFloat("bgmvolGage", 1f);
        BGMslider.value = bgmvolGage;
        bgm.volume = BGMslider.value;

        sevolGage = PlayerPrefs.GetFloat("sevolGage", 1f);
        SEslider.value = sevolGage;
        se.volume = SEslider.value;
    }

    // Update is called once per frame
    void Update()
    {
        BGMSliderF();
        SESliderF();
    }

    public void BGMSliderF()
    {
        bgm.volume = BGMslider.value;
        bgmvolGage = BGMslider.value;
        PlayerPrefs.SetFloat("bgmvolGage", 1f);
    }

    public void SESliderF()
    {
        se.volume = SEslider.value;
        sevolGage = SEslider.value;
        PlayerPrefs.SetFloat("sevolGage", 1f);
    }
}
