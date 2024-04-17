using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpeed : MonoBehaviour
{
    public AudioClip collectedClip;

   void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                //speed = 6; (can't work, won't exist in current context.)

                controller.PlaySound(collectedClip);
            }
        }

    }
}