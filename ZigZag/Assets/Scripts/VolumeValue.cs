using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    [SerializeField] private Image img;
    [SerializeField] private Sprite cross;
    [SerializeField] private Sprite volume;
    [SerializeField] private Slider sl;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume");
        sl.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
        CheckVolume();

    }
    void CheckVolume()
    {
        if (musicVolume == 0)
        {
            img.sprite = cross;
        }
        else if (musicVolume > 0)
        {
            img.sprite = volume;
        }
    }

    public void SetVolue(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("volume", vol);
    }
}
