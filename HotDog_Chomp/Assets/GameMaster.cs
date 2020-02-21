using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
    public GameObject[] hotDogs;
    int score;
    public Text scoreDisplay, timeDisplay;
    AudioSource audioSFX;
    
    void Start() {
        scoreCanvis.enabled = false;
        audioSFX = gameObject.AddComponent<AudioSource>();
        moveMouse.enabled = false;
    }

    public int biteCount = 0;
    float displayTime; 
    void Update() {
        if (time > 0) {
            time -= Time.deltaTime;
            displayTime = Mathf.CeilToInt(time);
        } else {
            time = 0;
            ScoreDisplayed();
            if (!canLoad) {
                canEat = false;
                Invoke("LoadNow", 2f);
            }
        } 

        if (biteCount >= 5) {
            ResethotDog();
            biteCount = 0;
            //Bite();
            
        }
        Display();
        
    }

    public string levelToLoad;
    public Canvas scoreCanvis;
    public Text yourScore;
    bool canLoad = false; 
    void ScoreDisplayed() {
        canvis.enabled = false; 
        scoreCanvis.enabled = true;
        yourScore.text = score.ToString(); 
        float mouse = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mouse) > 0.2f && canLoad) {
            SceneManager.LoadScene(levelToLoad);
        }

    }
    public Text moveMouse; 
    void LoadNow() {
        canLoad = true;
        moveMouse.enabled = true;

    } 
    void Display() {
        scoreDisplay.text = score.ToString();
        timeDisplay.text = displayTime.ToString();

    } 
    void ResethotDog() {
        foreach (GameObject g in hotDogs) {

            g.transform.position = g.GetComponent<Hotdog>().startingPos;
            g.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public float biteDistace;
    public GameObject partialEffect;
    public Transform muzzlePoint;

    bool canEat = true;
    public void Bite() {

        if (canEat) {
            if (biteCount < 5) {
                Instantiate(partialEffect, muzzlePoint.transform.position, Quaternion.identity);
                Score();
                foreach (GameObject g in hotDogs) {

                    g.transform.position = new Vector3(g.transform.position.x + biteDistace, g.transform.position.y, g.transform.position.z);

                }
                hotDogs[biteCount].GetComponent<SpriteRenderer>().enabled = false;
            }

            biteCount++;

        }

    }
    float time = 30;
    public GameObject TextToScore;
    public Transform canvisPos; 
    public Canvas canvis;
    public AudioClip addPoints; 
    void Score() {

        
        float x = 100 ;
        audioSFX.PlayOneShot(addPoints, 0.6f);
        x = (int)x; 
        score += (int)x;
        GameObject y = Instantiate(TextToScore, canvisPos.transform.position, Quaternion.identity);
        y.GetComponent<Text>().text ="+" + x.ToString(); 
        y.transform.SetParent(canvis.transform);

    }
}
