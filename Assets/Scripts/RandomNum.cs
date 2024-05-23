using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNum : MonoBehaviour
{
    public TextMeshProUGUI lightText;
    public TextMeshProUGUI darkText;

    public GameObject lightUnit;
    public GameObject lightUnit2;

    public GameObject darkUnit;
    public GameObject darkUnit2;

    public GameObject lightSpawnPoint;
    public GameObject darkSpawnPoint;

    public GameObject lightAttackPoint;
    public GameObject darkAttackPoint;


    private int lightPower;
    private int darkPower;





    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateNum", 5, 5);
    }


    public void GenerateNum()
    {
        GameObject temp = null;
        lightPower = Random.Range(15, 56);
        darkPower = Random.Range(15, 56);

        lightText.SetText($"{lightPower}");
        darkText.SetText($"{darkPower}");

        for (int i = 0; i < lightPower % 10; i++)
        {
            temp = Instantiate(lightUnit, lightSpawnPoint.transform.position, lightUnit.transform.rotation);
            temp.GetComponent<Unit>().destination = lightAttackPoint;
            temp.SetActive(true);

            temp = Instantiate(darkUnit, darkSpawnPoint.transform.position, darkUnit.transform.rotation);
            temp.GetComponent<Unit>().destination = darkAttackPoint;
            temp.SetActive(true);
        }

        for (int i = 0; i < lightPower / 10; i++)
        {
            temp = Instantiate(lightUnit2, lightSpawnPoint.transform.position, lightUnit2.transform.rotation);
            temp.GetComponent<Unit>().destination = lightAttackPoint;
            temp.SetActive(true);

            temp = Instantiate(darkUnit2, darkSpawnPoint.transform.position, darkUnit2.transform.rotation);
            temp.GetComponent<Unit>().destination = darkAttackPoint;
            temp.SetActive(true);
        }

    }



}
