using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wan : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.Die();
        }
    }
}