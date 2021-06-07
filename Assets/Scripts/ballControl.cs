using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballControl : MonoBehaviour
{
    public GameObject Kegels;
    public GameObject Rdoor;
    public GameObject Ldoor;
    public bool doorOpen = false;
    Rigidbody pys;
    public int speed;
    public int score = 0;
    public Text scoreBoard;
    public Text winText;
    void Start()
    {
        pys = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(horizontalMove, 0, verticalMove);
        pys.AddForce(vec * speed);

        scoreBoard.text = "Score= " + score;
        if (score == 10)
        {
            winText.text = "YOU WIN";
            scoreBoard.gameObject.SetActive(false);
        }
       
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Kegel")
        {
            Destroy(other.gameObject);
            score++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Sensor")
        {
            doorOpen = true;
            Debug.Log(doorOpen);
            if (doorOpen == true)
            {
                Vector3 left = new Vector3(7.5f, 2.5f, -12.823f);
                Vector3 right = new Vector3(-7.5f, 2.5f, -12.823f);
                Ldoor.transform.position = left;
                Rdoor.transform.position = right;
            }


        }

    }
    private void OnTriggerExit(Collider other)
    {
        doorOpen = false;
        if (doorOpen == false)
        {
            Ldoor.transform.position = new Vector3(2.61f, 2.5f, -12.823f);
            Rdoor.transform.position = new Vector3(-2.41f, 2.5f, -12.823f);

        }

    }


}
