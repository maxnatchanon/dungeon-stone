﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurst : MonoBehaviour
{

    public Transform FirePos1;
    public Transform FirePos2;
    public GameObject Flame1;
    public GameObject Flame2;
    public Animator animator;
    public GameObject player;
    public Transform CrossFirePos;
    //Cross fire pos will always be at center and simply shows effects.
    public GameObject CrossFire;
    //Crossfire will do nothing except show effects.
    public GameObject WarnFire;
    private int mode;
    

    private float currentCD = 1f;


    void Start()
    {
        mode = 0;
    }

    // Update is called once per frame
    void Update()
    {
	currentCD+= Time.deltaTime;
	if (currentCD >= 4){
	currentCD = 0;
	if (mode == 0){
		mode = 1;
		launchFire();
	}
	else if (mode == 1){
		mode = 2;
		launchFire();
	}
	else if (mode == 2){
		mode = 3;
		launchFire();
	}
	else if (mode == 3){
		mode = 4;
		launchWarnFire();
		launchFire();
	}
	else{
		mode = 0;
		launchFire();
		launchCrossFire();
}
}
        //if (currentCD < 600f){
	//currentCD+= Time.deltaTime;}
	//else{currentCD = 0f;}
	//if (currentCD % 20f == 0f && currentCD != 0f){launchFire();}
        //if ((currentCD+1f) % 30f == 0f && (currentCD+1f) != 0f){launchWarnFire();}
        //if (currentCD % 30f == 0f && currentCD != 0f){launchCrossFire();}
    }

    void launchFire()
    {
        GameObject fire1 = Instantiate(Flame1, FirePos1.position, FirePos1.rotation);
        Rigidbody2D rb = fire1.GetComponent<Rigidbody2D>();
	GameObject fire2 = Instantiate(Flame2, FirePos2.position, FirePos2.rotation);
        Rigidbody2D rb2 = fire2.GetComponent<Rigidbody2D>();
        //rb.AddForce(FirePos1.up * -1 * arrowForce, ForceMode2D.Impulse);
    }

    void launchCrossFire()
    {
    GameObject crossfire = Instantiate(CrossFire, CrossFirePos.position, CrossFirePos.rotation);
    Rigidbody2D rb3 = crossfire.GetComponent<Rigidbody2D>();
    if ((player.transform.position.x >= -4.5 && player.transform.position.x <= -3.5) || (player.transform.position.y >= -0.5 && player.transform.position.y <= 0.5)){
        GameManager.instance.ReduceHealth(15);
}
    }

    void launchWarnFire()
    {
    GameObject warnfire = Instantiate(WarnFire, CrossFirePos.position, CrossFirePos.rotation);
    Rigidbody2D rb4 = warnfire.GetComponent<Rigidbody2D>();
    if ((player.transform.position.x >= -4.5 && player.transform.position.x <= -3.5) || (player.transform.position.y >= -0.5 && player.transform.position.y <= 0.5)){
        GameManager.instance.ReduceHealth(5);
	}   
	
    }


}
