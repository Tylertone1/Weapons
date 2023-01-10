using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private GameObject[] ores;
    private GameObject[] awards;
    private GameObject[] enemys;
    
    


    // Start is called before the first frame update
    void Start()
    {

        ores = Resources.LoadAll<GameObject>("Ore");
        awards = Resources.LoadAll<GameObject>("Award");
        enemys = Resources.LoadAll<GameObject>("Enemy");
        InvokeRepeating("CreateAll", 0, 3f);
        InvokeRepeating("CreateEnemy", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }


        

       


    }


    private void CreateAll()//generate components.
    {
        int rangeNum = Random.Range(0, 6);
        GameObject temObject = null;
        if (0== rangeNum)//D
        {
            temObject = ores[2];

        }
        else 
        {
            temObject = ores[Random.Range(0, ores.Length - 1)];
        }
        GameObject ore = Instantiate(temObject, new Vector3(Random.Range(-5, 5), 5, 0), Quaternion.identity);
        
        GameObject award = CreateAward();
        if (award != null)
        {
            Instantiate(award, new Vector3(Random.Range(-5, 5), 5, 0), Quaternion.identity);
        }



    }


    private GameObject CreateAward()
    {
        int num = Random.Range(0, 9);
        GameObject temp = null;
        if (0 == num)
        {
            temp = awards[0];
        }
        else if (0 < num & num < 4)
        {
            temp = awards[1];
        }
        else
        {
            temp = null;
        }
        return temp;
        
       

    }

    private void CreateEnemy()//generate components.
    {
        int rangeNum = Random.Range(0, 9);
        GameObject temObject = null;
        
        if (0 < rangeNum & rangeNum < 4)//D
        {
            temObject = enemys[0];

        }
        else
        {
            temObject = enemys[1];
        }

        GameObject enemy = Instantiate(temObject, new Vector3(Random.Range(-5, 5), -3, 0), Quaternion.identity);
        
        enemy.AddComponent<move>();








    }


}
