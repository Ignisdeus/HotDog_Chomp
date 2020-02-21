using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveingTextDown : MonoBehaviour {



    public bool isText = true; 
	void Start () {
        white = Color.white;
	}
	
	public float speed;
    Color white;
    float colorChange = 1f; 
	void Update () {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(isText){
            
            colorChange -= Time.deltaTime * 2;
            white = new Color(1,1,1, colorChange);
            GetComponent<Text>().color = white;
        }
		
	}
}
