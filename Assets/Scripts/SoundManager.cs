using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    public Slider slide;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audio.volume = slide.value;
    }

}

