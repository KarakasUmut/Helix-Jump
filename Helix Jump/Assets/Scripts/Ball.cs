using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    private GameManager gm;
    public float jumpForce;
    public GameObject splashPrefab;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f,-0.2f, 0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);


        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("metarialadý" + metarialName);

       
        if (metarialName == "UnSafeColor (Instance)")
        {
            gm.RestartGame();
            
        }
        else if (metarialName == "last (Instance)")
        {
            
        }
    }

}
