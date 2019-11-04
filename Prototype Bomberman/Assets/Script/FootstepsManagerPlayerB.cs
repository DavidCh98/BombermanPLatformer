﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManagerPlayerB : MonoBehaviour
{
    FMOD.Studio.EventInstance FootstepsInst;

    public bool playerismoving;
    public bool playerisgrounded;
    public bool playerisnormal;
    public bool playerisslimed;
    public bool playerisfast;
    public float walkingspeed;
    public GameObject bottomCollider;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerismoving = true;
        }
        else
        {
            playerismoving = false;
        }
    }

    //sets the FMOD parameter to the correct sound
    void UpdateStatus()
    {
        if (playerisnormal == true)

        {
            walkingspeed = 0.23f;
            FootstepsInst.setParameterByName("Normal", 1f, false);
            FootstepsInst.setParameterByName("Slimed", 0f, false);
            FootstepsInst.setParameterByName("Fast", 0f, false);
        }
        else if (playerisslimed == true)
        {
            walkingspeed = 0.6f;
            FootstepsInst.setParameterByName("Normal", 0f, false);
            FootstepsInst.setParameterByName("Slimed", 1f, false);
            FootstepsInst.setParameterByName("Fast", 0f, false);
        }
        else if (playerisfast == true)

        {
            walkingspeed = 0.12f;
            FootstepsInst.setParameterByName("Normal", 0f, false);
            FootstepsInst.setParameterByName("Slimed", 0f, false);
            FootstepsInst.setParameterByName("Fast", 1f, false);
        }
    }

    //updates the surface, then plays a footstep event if the player is moving
    void CallFootsteps()
    {
        if(bottomCollider.GetComponent<BottomCollision>().collided == true){
            playerisgrounded = true;
        }else{
            playerisgrounded = false;
        }
        if (playerismoving == true && playerisgrounded == true)
        {
            UpdateStatus();
            FootstepsInst.start();

        }
    }

    //sets the footstep FMOD event path
    void Start()
    {
        walkingspeed = 0.23f;
        playerisnormal = true;
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
        FootstepsInst = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Footsteps");
    }
    void OnDisable()
    {
        playerismoving = false;
    }
}
