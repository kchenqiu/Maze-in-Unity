using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Control : MonoBehaviour
{
    public bool done;
    public int MovementSpeed = 20;
    private Rigidbody2D rb;
    private Vector2 Movement;


    private bool facingUp, facingDown, facingRight, facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        rb = GetComponent<Rigidbody2D>();
        facingUp = true;
        facingDown = false;
        facingRight = false;
        facingLeft = false;
    }
 
    // Update is called once per frame
    public void Update()
    {
        Move();
    }
 
    public void Move()
    {
        if(facingUp){
            Movement = new Vector2(0, 1);
            rb.velocity = Movement * MovementSpeed * Time.fixedDeltaTime;
        }
        else if(facingLeft){
            Movement = new Vector2(-1, 0);
            rb.velocity = Movement * MovementSpeed * Time.fixedDeltaTime;
        }
        else if(facingDown){    
            Movement = new Vector2(0, -1);        
            rb.velocity = Movement * MovementSpeed * Time.fixedDeltaTime;
        }
        else if(facingRight){
            Movement = new Vector2(1, 0);
            rb.velocity = Movement * MovementSpeed * Time.fixedDeltaTime;
        }
        else{
            int rand = Random.Range(0,4);
            if(rand == 0){
                facingUp = true;
            }
            else if(rand == 1){
                facingLeft = true;
            }
            else if(rand == 2){
                facingDown = true;
            }
            else if(rand == 3){
                facingRight = true;
            }
        }
    }
 
    public void TurnCCW()
    {
        Debug.Log("Turning...");
        if(facingUp){
            facingUp = false;
            facingLeft = true;
        }
        else if(facingLeft){
            facingLeft = false;
            facingDown = true;
        }
        else if(facingDown){
            facingDown = false;
            facingRight = true;
        }
        else if(facingRight){
            facingRight = false;
            facingUp = true;
        }
    }
 
    //future for killing enemies
    public void turnOff()
    {
        done = true;
    }

    public void OnCollisionEnter2D(Collision2D collider){
        Debug.Log("Hit a wall");
        if(facingUp){
            transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
        }
        else if(facingLeft){
            transform.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
        }
        else if(facingDown){    
            transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        }
        else if(facingRight){
            transform.position = new Vector3(transform.position.x - .1f, transform.position.y , transform.position.z);
        }
        TurnCCW();
        return;
    }
}