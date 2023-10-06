using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject doorClassroomCue;
    public GameObject doorOfficeCue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ClassroomDoor"))
        {
            SceneManager.LoadScene("HouseNight");
        }

        if(other.gameObject.CompareTag("OfficeDoor"))
        {
            SceneManager.LoadScene("HouseNight");
        }
    }

}
