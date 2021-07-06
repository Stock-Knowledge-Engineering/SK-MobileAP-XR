using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARModule1_Tuitorial : MonoBehaviour
{
    public Sprite[] tuitorialImageSource;
    public Image tuitorialImageContatainer;
    int currentImage;
    public GameObject instructionHolder;
    public AudioClip[] instructionAudio;
    public AudioSource audioSource;

    public void Awake()
    {
        //instructionAudio[currentImage]
        audioSource.clip = instructionAudio[currentImage];
        audioSource.Play();
    }

        public void Next()
    {
        currentImage++;
        if (tuitorialImageSource.Length <= currentImage)
        {
            FinishedTuitorial();
        }
        tuitorialImageContatainer.sprite = tuitorialImageSource[currentImage];
        audioSource.clip = instructionAudio[currentImage];
        audioSource.Play();
    }
    public void Prev()
    {
        if (currentImage > 0)
        {
            currentImage--;
            tuitorialImageContatainer.sprite = tuitorialImageSource[currentImage];
            audioSource.clip = instructionAudio[currentImage];
            audioSource.Play();
        }
    }

    public void OpenTuitorial()
    {
        instructionHolder.SetActive(true);
    }

    public void FinishedTuitorial()
    {
        currentImage = 0;
        audioSource.Stop();
        instructionHolder.SetActive(false);
    }
}
