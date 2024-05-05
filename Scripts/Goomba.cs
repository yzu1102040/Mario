using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;

    Vector2 velocity;
    Rigidbody2D rigidbody;
    bool isDie;
    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        if(isDie)
            return;
        velocity.x = direction.x*speed;
        velocity.y += Physics2D.gravity.y*Time.fixedDeltaTime;

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);

        if (rigidbody.Raycast(direction))
        {
            direction = -direction;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")&& other.transform.DotTest(transform, Vector2.down))
        {
            isDie = true;
            GetComponent<Collider2D>().enabled = false;
            Destroy(rigidbody);
            GetComponent<Animator>().SetBool("isDie", true);
            Destroy(gameObject, 0.5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
