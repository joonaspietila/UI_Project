using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{

    [SerializeField] Button openBtn;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openBook;


    private Vector3 rotationVector;
    private bool isOpenCLicked;
    private DateTime startTime;
    private DateTime endTime;

    void Start()
    {
        if (openBtn != null)
            openBtn.onClick.AddListener(() => openBtn_Click());
    }

    
    void Update()
    {
        if (isOpenCLicked)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if ((endTime - startTime).TotalSeconds >= 1)
            {
                isOpenCLicked = false;
            }

        }
    }

    private void openBtn_Click()
    {
        isOpenCLicked = true;
        startTime = DateTime.Now;


        rotationVector = new Vector3(0, 180, 0);

        PlaySound();
    }

    private void PlaySound()
    {
        if ((audioSource != null) && (openBook != null))
        {
            audioSource.PlayOneShot(openBook);
        }
    }
}
