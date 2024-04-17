using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakRocks : MonoBehaviour
{
    public AudioClip RockHit;

    int rockHealth = 2;

    private BotTracker tracker;

    void Start()
    {
        GameObject botTrackerObject = GameObject.FindWithTag("GameController");

        if (botTrackerObject != null)
        {
            tracker = botTrackerObject.GetComponent<BotTracker>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rockHealth == 0)
        {
            RockBroken();
            tracker.RockBroke();
        }
    }

    public void RockDamage()
    {
        rockHealth -= 1;
    }


    void RockBroken()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            tracker.PlaySound(RockHit);
            RockDamage();
        }
    }
}
