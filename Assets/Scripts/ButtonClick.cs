using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource audio;

    public void PlaySound()
    {
        audio.Play();
    }
}
