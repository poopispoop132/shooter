using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public bool hastriggered = false;
    public float force;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame 
    void Update()
    {

    }
}
