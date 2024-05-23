using System.Collections;
using System.Collections.Generic;
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

    public RandomNum easyRef;

    public GameObject destination;

    Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        easyRef = RandomNum.easyRef;




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
        if (force == Force.Dark)
        {
            destination = easyRef.darkAttackPoint;
        }
        if (force == Force.Light)
        {
            destination = easyRef.lightAttackPoint;
        }
        rb.AddForce((destination.transform.position - this.transform.position).normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Unit enemyUnit = collision.collider.GetComponent<Unit>();

        if (enemyUnit != null)
        {
            if(enemyUnit.force != this.force)
            {
                enemyUnit.hp -= this.attack;
                Debug.Log(enemyUnit.hp + "enemyUnit.hp -= this.attack");
                rb.AddForce(-(collision.collider.transform.position - this.transform.position).normalized * 3, ForceMode.VelocityChange);
            }
        }

        Building enemyBuilding = collision.collider.GetComponent<Building>();

        if (enemyBuilding != null)
        {
            if (enemyBuilding.force != this.force)
            {
                enemyBuilding.hp -= this.attack;
                Debug.Log(enemyBuilding.hp + "enemyBuilding.hp -= this.attack");

                rb.AddForce(-(collision.collider.transform.position - this.transform.position).normalized * 10, ForceMode.VelocityChange);

            }
        }


    }

}
