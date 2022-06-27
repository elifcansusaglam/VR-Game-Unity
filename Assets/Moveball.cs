using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moveball : MonoBehaviour {

    private Rigidbody rb;
    public int ballspeed = 0;
    public int jumpspeed = 0;
    private bool ballistouching = true;
    public AudioSource audioSource;
    public AudioClip audioClip;
    private int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        score = 17;
        updateScore();
	}
	
	// Update is called once per frame
	void Update () {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 ballmove = new Vector3(hmove,0.0f,vmove);

        rb.AddForce(ballmove*ballspeed);

        if (Input.GetKey (KeyCode.Space) && ballistouching )
        {
            Vector3 balljump = new Vector3(0.0f, 6.0f, 0.0f);
            rb.AddForce(balljump * jumpspeed);
            ballistouching = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ballistouching = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Page"))
        { 
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(audioClip);
            score--;
            updateScore();
            if (score == 0)
                SceneManager.LoadScene("FinalScene");
        }
    }

    private void updateScore()
    {
        scoreText.text = "                                 Remain Pages : " + score;
    }
}
