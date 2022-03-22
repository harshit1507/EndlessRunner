using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool deactivationScheduled = false;
    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player" && !deactivationScheduled)
        {
            deactivationScheduled = true;
            StartCoroutine(SetInactive());
        }
    }

    IEnumerator SetInactive()
    {
        yield return new WaitForSeconds(4.0f);
        this.gameObject.SetActive(false);
        deactivationScheduled = false;
    }
}
