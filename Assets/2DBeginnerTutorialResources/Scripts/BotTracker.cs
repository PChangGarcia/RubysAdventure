using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotTracker : MonoBehaviour
{
    public Text botNumber;
    public Text rockNumber;
    public int numBot = 0;
    public int numRock = 0;

    public GameObject winText;
    
    private RubyController rubyController;

    AudioSource audioSource;
    public AudioClip winSound;

    private void Start()
    {
        GameObject rubyControllerObject = GameObject.FindWithTag("RubyController");

        if (rubyControllerObject != null)
        {

            rubyController = rubyControllerObject.GetComponent<RubyController>(); 

        }

        audioSource = GetComponent<AudioSource>();
        botNumber.text = "Fixed Robots: 0";
        rockNumber.text = "Rocks Destroyed: 0";
        
    }

    private void Update()
    {
        botNumber.text = "Fixed Robots: " + numBot;
        rockNumber.text = "Rocks Destroyed: " + numRock;

        if (numBot == 4 && numRock == 2)
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

        rubyController.ChangeSpeed();

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }

   public void RockBroke()
    {
        numRock += 1;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
