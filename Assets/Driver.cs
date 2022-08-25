using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 35f;
    float destroyDelay = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        

        if(moveAmount != 0){
            transform.Rotate(0, 0, -steerAmount);
        }

        transform.Translate(0, moveAmount, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Slow Speed"){
            moveSpeed = slowSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
        else if(other.tag == "Boost Speed"){
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
