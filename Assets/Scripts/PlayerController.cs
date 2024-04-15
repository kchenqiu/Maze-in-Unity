using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /*Player settings:
        Capsule Collider 2D:
            Offset: X: -0.04, Y: 0.16
            Size: X: 0.7, Y: 0.7
        
        RigidBody 2D:
            Body Type: Dynamic
            Collision Detection: Continuous
            Sleeping Mode: Never Sleep
            Interpolate: Interpolate
            Gravity Scale: 0
            Freeze Rotation: Z: true
    */
    private Rigidbody2D rb;
    private bool IsDead = false;
    //public HealthManager HealthManagerPrefab;
    private HealthManager healthManager;
    //public GameObject HealthBarPrefab;
    private GameObject HealthBar;
    private Vector2 MovementInput;
    public float MovementSpeed;

    /*
    private bool facingUP = false;
    private bool facingDown = false;
    private bool facingRight = false;
    private bool facingLeft = false;
    */

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //todo find good movement speed
        MovementSpeed = 100;        
        //HealthBar = Instantiate(HealthBarPrefab);
        //healthManager = Instantiate(HealthManagerPrefab);
    }

    // Unused (can be used for future animations)
    /*public void Update()
    {   
        if(Input.GetKeyDown("q")){
            Attack();
        }
        else if(Input.GetKeyDown("e")){
            Defend();
        }
        else if(Input.GetKeyDown("t")){
            healthManager.TakeDamage(1);
        }
        else if(Input.GetKeyDown("w")){
            facingUP = true;
            facingDown = false;
            facingRight = false;
            facingLeft = false;        
        }
        else if(Input.GetKeyDown("s")){
            facingUP = false;
            facingDown = true;
            facingRight = false;
            facingLeft = false;
        }
        else if(Input.GetKeyDown("a")){
            facingUP = false;
            facingDown = false;
            facingRight = true;
            facingLeft = false;
        }
        else if(Input.GetKeyDown("d")){
            facingUP = false;
            facingDown = false;
            facingRight = false;
            facingLeft = true;
        }
    }
*/
    public void Update(){
        Move();
    }

    private void Move(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal == 0 && vertical == 0){
            rb.velocity = new Vector2(0, 0);
            return;
        }

        MovementInput = new Vector2(horizontal, vertical);
        rb.velocity = MovementInput * MovementSpeed * Time.fixedDeltaTime;
    }

    private void Attack(){

    }

    private void Defend(){

    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Congrats");
        rb.position = new Vector3(0, 0 , -.2f);
        GameManager.Instance.Levelup();
    }
}
