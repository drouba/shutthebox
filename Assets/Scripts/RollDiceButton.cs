using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDiceButton : MonoBehaviour
{

    public Image image;

    public Button button;

    private bool isOpen = true;

    // animation variables
    public Sprite open;
    public Sprite middle;
    public Sprite closed;

    // audio
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if(button.IsInteractable() && !isOpen)
        {
            StartCoroutine("Open");
            isOpen = true;
        }
        else if(!button.IsInteractable() && isOpen)
        {
            StartCoroutine("Close");
            isOpen = false;
        }
    }

    public IEnumerator Open()
    {
        image.sprite = middle;
        audioSource.time = 1.1f;
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        image.sprite = open;
    }

    public IEnumerator Close()
    {
        image.sprite = middle;
        audioSource.time = 1.1f;
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        image.sprite = closed;
    }
}
