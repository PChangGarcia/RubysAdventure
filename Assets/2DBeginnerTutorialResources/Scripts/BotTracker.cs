using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotTracker : MonoBehaviour
{
    public Text botNumber;
    public int numBot = 0;

    public GameObject winText;
    public AudioClip winSound;

    AudioSource audioSource;

    private void Start()
    {
        botNumber.text = "Fixed Robots: 0";

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        botNumber.text = "Fixed Robots: " + numBot;

        if (numBot == 4)
        {
            GameWin();
            
        }
    }

    public void ChangeNum(int amount)
    {
        numBot += amount;
    }

    public void GameWin()
    {
            winText.SetActive(true);

            PlaySound(winSound);

            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
}
