using System.Collections;
using System.Collections.Generic;
using Unity.Play.Publisher.Editor;
using UnityEngine;


public class Unit : MonoBehaviour
{
    public enum Force
    {
        Light, Dark
    }

    public int hp;
    public int attack;
    public int speed;
    public Force force;

    public GameObject destination;

    Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackDirection();
        if (this.hp < 1)
        {
            Debug.Log("has Destoryed");
            Destroy(gameObject);
        }

    }

    void AttackDirection()
    {
        rb.AddForce((destination.transform.position - this.transform.position).normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Unit enemyUnit = collision.collider.GetComponent<Unit>();

        if (enemyUnit != null)
        {
            Debug.Log("enemyUnit != null is Active");
            if(enemyUnit.force != this.force)
            {
                enemyUnit.hp -= this.attack;
                Debug.Log(enemyUnit.hp + "enemyUnit.hp -= this.attack");
                rb.AddForce(-(collision.collider.transform.position - this.transform.position).normalized * 500);
            }
        }
    }

}
