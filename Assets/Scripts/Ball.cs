using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;

    public GameObject splashPrefab;

    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        

        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Ladder 2 (Instance)" || materialName == "Ladder 3 (Instance)" || materialName == "Ladder 4 (Instance)")
        {
            gm.RestartGame();
        }

        else if(materialName== "Last Ring (Instance)")
        {
            // bir sonraki levele geç.
        }
    }
}
