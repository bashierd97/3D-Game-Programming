// Bashier Dahman 2D Project
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    public Rigidbody2D rb2d;
    SpriteRenderer spriteR;

    public int attackDamage = 2, playerHealth = 5;
    public Transform attackPointRight, attackPointLeft;
    public float attackRange = 0.65f;
    public LayerMask enemyLayers;

    bool isGrounded, hitBySpikes, swingingSword, killedByEnemy;
    public bool swordEquip;

    public int numExpiredCandy;
    
    public GameObject gameOverText, restartButton, mainMenuButton, gameOverBackground;

    public GameObject heart1, heart2, heart3, heart4, heart5;
 
    int playerLayer, enemyLayer;
    bool coroutineAllowed = true;
    Color color;
    Renderer rend;

    public Collider2D c_collider;

    public AudioSource[] soundFX;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float runSpeed = 3;

    [SerializeField]
    private float jumpHeight = 5.5f;

    // Start is called before the first frame update
    void Start()   {

        playerLayer = this.gameObject.layer;
        enemyLayer = LayerMask.NameToLayer("Enemy Layer");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        heart1 = GameObject.Find("heart1");
        heart2 = GameObject.Find("heart2");
        heart3 = GameObject.Find("heart3");
        heart4 = GameObject.Find("heart4");
        heart5 = GameObject.Find("heart5");
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(true);
        heart5.gameObject.SetActive(true);
        rend = GetComponent<Renderer> ();
        color = rend.material.color;

        swordEquip = false;
        gameOverBackground.SetActive(false);
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()   {
        if (swordEquip == false)
        {
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground_Layer")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                if(!hitBySpikes && !killedByEnemy)
                    animator.Play("Player_Jump_Front");
            }

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                if (isGrounded)
                    animator.Play("Walk_Right");
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                if (isGrounded)
                    animator.Play("Walk_Left");
            }
            else
            {
                if (isGrounded && !killedByEnemy)
                    animator.Play("Idle_Animation");
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            /* Tried making it where it switch animation dependent on where 
             * the character was facing, tried many things including variables
             * and much more... but i give up
            if (Input.GetButton("d") && Input.GetButtonDown("Space") && isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                animator.Play("Player_Jump_Right");
            }
            */
            if (Input.GetKey("space") && isGrounded == true)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                animator.Play("Player_Jump_Front");
            }
        }
        else if (swordEquip == true)
        {
            //anim2.SetTrigger("SwordEquip");

            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground_Layer")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                if(!hitBySpikes && !killedByEnemy)
                    animator.Play("Player_Jump_Front");
            }

            if(Input.GetKey("m")) {
                if(isGrounded)
                    swingingSword = true;
                    animator.Play("SlashRight");
                    swingingSword = false;

                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);

                    foreach(Collider2D enemy in hitEnemies) {
                        enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
                    }
            }
            else if(Input.GetKey("n")) {
                if(isGrounded)
                    swingingSword = true;
                    animator.Play("SlashLeft");
                    swingingSword = false;
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);

                    foreach(Collider2D enemy in hitEnemies) {
                        enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
                    }
            }
            else if (Input.GetKey("d") || Input.GetKey("right"))  {
                if(!swingingSword) {
                    rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                    if (isGrounded)
                        animator.Play("Walk_Right_Sword");
                }
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))     {
                if(!swingingSword) {
                    rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                    if (isGrounded)
                        animator.Play("Walk_Left_Sword");
                }
            }   else   {
                if (isGrounded && swingingSword == false && !killedByEnemy) 
                    animator.Play("Idle_Sword");
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }

            if (Input.GetKey("space") && isGrounded == true)    {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                animator.Play("Player_Jump_Front");
            }
        }
    }

    // this function is used for the spikes, if its detected they'll kill the user if he hits them
    // it is also if the enemy harms the user 
    void OnCollisionEnter2D(Collision2D col)  {

        // if the user touches a spike the game will automatically end
        if(col.gameObject.tag.Equals("Spike"))    {
            hitBySpikes = true;
            gameOverBackground.SetActive(true);
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            if (swordEquip == false)
            {
                playDeathSound();
                animator.Play("Death_Animation");
            } else if (swordEquip == true)
            {
                playDeathSound();
                animator.Play("Death_Animation_Sword");
            }
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        // if the enemy touches user, it'll hurt the user
        else if (col.gameObject.tag.Equals("Enemy") && !col.gameObject.GetComponent<EnemyScript>().isDead) {
            playerHealth -= 1;
            switch (playerHealth) {
            case 4:
                heart5.gameObject.SetActive(false);
                if (coroutineAllowed)
                    StartCoroutine("Immortal");
                break;
            case 3:
                heart4.gameObject.SetActive(false);
                if (coroutineAllowed)
                    StartCoroutine("Immortal");
                break;
            case 2:
                heart3.gameObject.SetActive(false);
                if (coroutineAllowed)
                    StartCoroutine("Immortal");
                break;
            case 1:
                heart2.gameObject.SetActive(false);
                if (coroutineAllowed)
                    StartCoroutine("Immortal");
                break;
            case 0:
                heart1.gameObject.SetActive(false);

                killedByEnemy = true;
                gameOverBackground.SetActive(true);
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                mainMenuButton.SetActive(true);
                if (swordEquip == false)  {
                    playDeathSound();
                    animator.Play("Death_Animation");
                    c_collider.enabled = false;
                } else if (swordEquip == true)   {
                    playDeathSound();
                    animator.Play("Death_Animation_Sword");
                    c_collider.enabled = false;
                }
                rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            break;
            }


        }
    }
    
    IEnumerator Immortal() {
        
        coroutineAllowed = false;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        // color.a = 0.5f;
        color.r = 1f;
        color.g = 0f;
        color.b = 0f;
        rend.material.color = color;
        playHurtSound();
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(playerLayer,enemyLayer,false);
        // color.a = 1f;
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;
        rend.material.color = color;
        coroutineAllowed = true;
    }

    void OnDrawGizmosSelected() {

        if (attackPointRight == null)
            return;
        
        if (attackPointLeft == null)
            return;

        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }

    // this will specifically play the sound of slashing the sword
    void playSwordsound() {
        soundFX[0].Play();
    }

    void playHurtSound() {
        soundFX[1].Play();
    }

    void playDeathSound() {
        soundFX[2].Play();
    }

    void playGameOverSound() {
        soundFX[3].Play();
    }




} // class
