using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {
    public GameObject GM;
    AudioSource audioSFX;
    void Start() {

        audioSFX = gameObject.AddComponent<AudioSource>();
    }


    void Update() {

        MovementDetection();
        LimitMovement();

    }

    public float openCheckDistace;
    private void MovementDetection() {

        float vert = Input.GetAxis("Mouse Y");

        Vector3 moveTo = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + vert, transform.position.z), 0.2f);
        transform.position = moveTo;
        if (transform.localPosition.y < openCheckDistace) {
            jawOpen = true;
        }
        Debug.Log(transform.localPosition.y);

    }
    public bool jawOpen = true;
    public Vector2 movementConstaints;
    public AudioClip[] bite; 
    void LimitMovement() {

        if (transform.position.y > movementConstaints.x) {
            if (jawOpen) {
                jawOpen = false;
                audioSFX.PlayOneShot(bite[Random.Range(0, bite.Length)], 0.8f);
                GM.GetComponent<GameMaster>().Bite();
            }
            transform.position = new Vector3(transform.position.x, movementConstaints.x, transform.position.z); 
        }
        if (transform.position.y < movementConstaints.y) {


            transform.position = new Vector3(transform.position.x, movementConstaints.y, transform.position.z);
        }



    } 
 }
