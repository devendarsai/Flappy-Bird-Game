using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicManager logic;
    public bool isBirdAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )) && isBirdAlive){
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        CheckIfBirdIsOutOfScreen();
    }
    private void CheckIfBirdIsOutOfScreen(){
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            logic.gameOver();
            isBirdAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        logic.gameOver();
        isBirdAlive = false;
    }
}
