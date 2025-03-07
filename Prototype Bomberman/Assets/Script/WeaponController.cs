﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 playerPos;    
    
    
    // Start is called before the first frame update
    void Start()
    {
        MovementCharacter mvChar = player.GetComponent<MovementCharacter>();
        playerPos = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        Instantiate(mvChar.weapon,new Vector3(playerPos.x + 1,playerPos.y,playerPos.z), Quaternion.identity);
    }

    // Update is called once per frame
            
    void Update()
    {
        MovementCharacter mvChar = player.GetComponent<MovementCharacter>();
        if(player.GetComponent<SpriteRenderer>().flipX == true)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector3(player.transform.position.x -0.4f,player.transform.position.y,player.transform.position.z); 
        }
        else if (player.GetComponent<SpriteRenderer>().flipX == false)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(player.transform.position.x +0.4f,player.transform.position.y,player.transform.position.z); 
        }
    }
}
