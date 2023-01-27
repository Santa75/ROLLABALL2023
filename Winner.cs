using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Winner : MonoBehaviour
{

    public static Winner instance;


    //this variable will be used in both the door object and the collectables we will use it to trigger the opening of the door
    [HideInInspector]
    public int collectiblesCount;
    public Text countText;
    public Text winText;
    public GameObject next;
    public GameObject Player;


    void Awake()
    {
        //This creates the door instance
        MakeInstance();
        winText.text = "";
        countText.text = "PELLETS: 0/6";
        collectiblesCount = collectiblesCount - 6;
        next.gameObject.SetActive(false);
        Player = GameObject.Find("Player");
    }

    void MakeInstance()
    {
        //this creates the door in the frame
        if (instance == null)
            instance = this;

    }
    //This is a function that lowers the value of collectiblesCount which will be used in the collectible objects
    public void DecrementCollectibles()
    {
        //lower the value of collectiblesCount by one
        collectiblesCount++;

        countText.text = "PELLETS: " + collectiblesCount.ToString() + "/6";
       
    }



    //this constantly checks for a collision with the Player object
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            //if a collision with the player occurs, do this.  This can be used to load the next scene.
            Debug.Log("Level Finished");
            next.gameObject.SetActive(true);
            Destroy(Player);

        }
    }
}

