using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    
    static public GameObject dummyTraveller;
    static public GameObject lastPlatform;
    // Start is called before the first frame update
    void Awake()
    {
        dummyTraveller = new GameObject("Dummy");
       
        //for (int i=0;i<20;i++)
        //{

        //    GameObject platform = Pool.singleton.GetRandom();
        //    if (platform == null)
        //        return;

        //    platform.SetActive(true);
        //    platform.transform.position = dummyTraveller.transform.position;
        //    platform.transform.rotation = dummyTraveller.transform.rotation;

        //    if(platform.tag == "StairsUp")
        //    {
        //        dummyTraveller.transform.Translate(0, 5, 0);
        //    }
        //    else if(platform.tag == "StairsDown")
        //    {
        //        dummyTraveller.transform.Translate(0, -5, 0);
        //        platform.transform.Rotate(Vector3.up * 180);
        //        platform.transform.position = dummyTraveller.transform.position;
        //    }
        //    else if(platform.tag == "PlatformTSection")
        //    {
        //        if(Random.Range(0,2) == 0)
        //            dummyTraveller.transform.Rotate(Vector3.up * 90);
        //        else
        //            dummyTraveller.transform.Rotate(Vector3.up * -90);

        //        dummyTraveller.transform.Translate(Vector3.forward * -10);
        //    }
        //    dummyTraveller.transform.Translate(Vector3.forward * -10);
        //}
    }

    public static void RunDummy()
    {
        GameObject platform = Pool.singleton.GetRandom();
        if (platform == null)
            return;

        if(lastPlatform != null)
        {
            if (lastPlatform.tag == "PlatformTSection")
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 20;
            }
            else
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 10;
            }

            if(lastPlatform.tag == "StairsUp")
            {
                dummyTraveller.transform.Translate(0, 5, 0);
            }
        }

        lastPlatform = platform;
        platform.SetActive(true);
        platform.transform.position = dummyTraveller.transform.position;
        platform.transform.rotation = dummyTraveller.transform.rotation;

        if(platform.tag == "StairsDown")
        {
            dummyTraveller.transform.Translate(0, -5, 0);
            platform.transform.Rotate(0, 180, 0);
            platform.transform.position = dummyTraveller.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
