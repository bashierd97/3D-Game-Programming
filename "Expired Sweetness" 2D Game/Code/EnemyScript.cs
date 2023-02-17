using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int maxHealth = 50;

    public Animator animaton1;

    public GameObject lwP, rwP;

    public AudioSource explosion, bossDeath;

    public bool isBoss, isDead;

    public float moveSpeed = 0.20f;
    Transform leftWayPoint, rightWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;

    int currentHealth;
    // Start is called before the first frame update
    void Start()  {

        if(isBoss) {
            currentHealth = 350;
            moveSpeed = 0.1f;
        } else {
            // set the current health of the enemy to the total max health
            currentHealth = maxHealth;
        }

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
        leftWayPoint = lwP.GetComponent<Transform> ();
        rightWayPoint = rwP.GetComponent<Transform> ();

    }

    void Update() {

        if (transform.position.x > rightWayPoint.position.x)
            movingRight = false;
        if (transform.position.x < leftWayPoint.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();
    }


    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if(currentHealth <= 0) {
            isDead = true;
            if(isBoss)
                bossDeathSound();
            Die();
        }
    }

    void Die() {
        animaton1.SetTrigger("Destroyed");
        // instead of destroying the gameobject here, 
        // I used a script in the animator and destroyed after the explosion
        // animation is played. Much more cleaner
        //Destroy(gameObject);
    }

    void moveRight() {
        movingRight = true;
        if(isBoss)
            localScale.x = 8;
        else
            localScale.x = 3;
        transform.localScale = localScale;
        rb.velocity = new Vector2 (localScale.x * moveSpeed, rb.velocity.y);
    }

    void moveLeft() {
        movingRight = false;
        if(isBoss)
            localScale.x = -8;
        else
            localScale.x = -3;
        transform.localScale = localScale;
        rb.velocity = new Vector2 (localScale.x * moveSpeed, rb.velocity.y);
    }

    void explosionSound() {
        explosion.Play();
    }
    void bossDeathSound() {
        bossDeath.Play();
    }


} // class
