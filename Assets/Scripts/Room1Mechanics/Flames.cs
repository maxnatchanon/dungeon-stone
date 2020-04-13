﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
	private float lifetime = 3f;
	void Awake(){
	Destroy(this.gameObject, lifetime);	
}
	void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Player"){
            GameManager.instance.ReduceHealth(10);
        }

    }

}
