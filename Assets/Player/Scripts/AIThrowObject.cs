using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThrowObject : MonoBehaviour
{
    public GameObject explosion;
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject exp = Instantiate(explosion,this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.right = rb.velocity;
    }
}
