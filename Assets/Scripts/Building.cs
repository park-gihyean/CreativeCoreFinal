using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int hp;
    public int attack;


    Rigidbody rb;
    public Unit.Force force;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(hp < 1)
        {

            RandomNum.easyRef.ChangePoint(force);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Unit enemyUnit = collision.collider.GetComponent<Unit>();

        if (enemyUnit != null)
        {
            if (enemyUnit.force != this.force)
            {
                enemyUnit.hp -= this.attack;
                Debug.Log(enemyUnit.hp + "BuildingBuildingBuilding enemyUnit.hp -= this.attack");
            }
        }
    }

}
