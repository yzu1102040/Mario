using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mario : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float moveSpeed = 8f;
    float horizontalMove;
    public bool isJump;

    public GameObject FlagPole;
    public GameObject Castle;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            horizontalMove=Input.GetAxisRaw("Horizontal")*moveSpeed;
            animator.SetBool("isMove", true);
        }
        else 
        {
            horizontalMove=0;
            animator.SetBool("isMove", false);
        }
        if(Input.GetButtonDown("Jump"))
        {
            isJump=true;
        }
        animator.SetBool("isJump",isJump);
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove*Time.fixedDeltaTime,false,isJump);
    }
    public void Onland()
    {
        isJump=false;
    }
    public void Die()
    {
        animator.SetBool("isDie", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        GameManager.Instance.DelayReset(3f);
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("DeathArea"))
        {
            Die();
        }
        if(other.CompareTag("FlagPole"))
        {
            other.GetComponent<Animator>().SetTrigger("isWin");
            StartCoroutine(Win());
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(transform.DotTest(other.transform, Vector2.down))
            {
                controller.velocity = new Vector2(controller.velocity.x, 1000);
                isJump = true;
            }
            else
                Die();
        }
    }
    public IEnumerator MoveTo(Transform _target, Transform _destination, float _speed)
    {
        while (Vector3.Distance(_target.position, _destination.position) > 0.125f)
        {
            _target.position = Vector3.MoveTowards(_target.position, _destination.position, _speed * Time.deltaTime);
            animator.SetBool("isMove", true);
            yield return null;
        }
        _target.position = _destination.position;
    }
    

    public IEnumerator Win() {
        GameManager.Instance.DelayReset(6f);
        GetComponent<Rigidbody2D>().simulated = false;
        yield return MoveTo(transform, FlagPole.transform, 8f);
        yield return MoveTo(transform, Castle.transform, 4f);
        transform.gameObject.SetActive(false);
    }
    
}
