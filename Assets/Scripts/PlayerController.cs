using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = this.gameObject;
        startPosition = player.transform.position;
        GenerateWorld.RunDummy();
    }
    private void OnCollisionEnter(Collision other)
    {
        currentPlatform = other.gameObject;

        if(other.gameObject.tag == "Fire")
        {
            animator.SetTrigger("isDead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "PlatformTSection")
            GenerateWorld.RunDummy();

        if (other is BoxCollider && GenerateWorld.lastPlatform.tag != "PlatformTSection")
            GenerateWorld.RunDummy();

        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other is SphereCollider)
        {
            canTurn = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            animator.SetBool("isMagic", true);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
            canTurn = false;
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();
            if(GenerateWorld.lastPlatform.tag != "PlatformTSection")
                GenerateWorld.RunDummy();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
            canTurn = false;
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();
            if (GenerateWorld.lastPlatform.tag != "PlatformTSection")
                GenerateWorld.RunDummy();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isMagic", false);
        }
    }

    public void StopJump()
    {
        //animator.SetBool("isJumping", false);
    }
    public void StopMagic()
    {
        //animator.SetBool("isMagic", false);
    }
}
