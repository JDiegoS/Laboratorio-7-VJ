using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpspeed;
    private Rigidbody2D player;
    public GameObject pl, star, enemigo;
    private bool onFloor = true;
    private bool super = false;
    private bool right = true;
    private SpriteRenderer rend;
    public Sprite jumps, supers, normal, supersj;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.velocity = new Vector2(-1 * speed, player.velocity.y);
            if(right == true)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                right = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.velocity = new Vector2(speed, player.velocity.y);
            if (right == false)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                right = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && onFloor == true)
        {
            player.velocity = new Vector2(player.velocity.x, jumpspeed);
            if (super == false)
            {
                rend.sprite = jumps;
            }
            else
            {
                rend.sprite = supersj;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            onFloor = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            onFloor = true;
            if (super == false)
            {
                rend.sprite = normal;
            }
            else
            {
                rend.sprite = supers;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (super == true)
            {
                Destroy(enemigo);
                
            }
            else
            {
                Destroy(pl);
            }
        }
        if (collision.gameObject.tag == "Powerup")
        {
            Destroy(star);
            rend.sprite = supers;
            super = true;
        }
    }

}
