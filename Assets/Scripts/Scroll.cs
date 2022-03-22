using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += PlayerController.player.transform.forward * -0.1f;

        if(PlayerController.currentPlatform == null)
        {
            return;
        }

        if(PlayerController.currentPlatform.tag == "StairsUp")
        {
            this.transform.Translate(0, -0.06f, 0);
        }
        else if (PlayerController.currentPlatform.tag == "StairsDown")
        {
            this.transform.Translate(0, 0.06f, 0);
        }
    }
}
