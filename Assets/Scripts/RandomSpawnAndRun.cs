using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class RandomSpawnAndRun : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float runningSpeed = 3;
    [SerializeField] private float walkBackwardsSpeed = 0.1f;
    [SerializeField] private float divingSpeed = 6;
    [SerializeField] private float chargeUpTime = 2;

    private Vector2 playerEnemyDelta;
    private bool runTowardsPlayer = true;
    private bool alive = true;
    private SpriteRenderer SpriteRenderer;
    private float alpha = 1f;
    private float colorChange;



    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        colorChange = SpriteRenderer.color.r;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            if (runTowardsPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, runningSpeed);
                playerEnemyDelta = player.transform.position - transform.position;


                if (playerEnemyDelta.magnitude < player.localScale.x / 2)
                {
                    runTowardsPlayer = false;
                }
            }
            else if (chargeUpTime > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -walkBackwardsSpeed);
                chargeUpTime -= Time.deltaTime;
                colorChange = Mathf.Lerp(colorChange, Color.white.a, 0.01f);
                SpriteRenderer.color = new Color(colorChange, SpriteRenderer.color.g, SpriteRenderer.color.b, alpha);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, divingSpeed);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -walkBackwardsSpeed);
            SpriteRenderer.color = Color.white;
            SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, alpha);
            alpha = Mathf.Lerp(alpha, 0, 0.1f);
            if (alpha < 0.05)
            {
                Destroy(gameObject);    
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided with: " + collision);
        if (collision.transform.CompareTag("Spear"))
        {
            alive = false;
        }
    }
}
