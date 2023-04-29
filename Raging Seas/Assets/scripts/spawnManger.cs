using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spawnManger : MonoBehaviour
{
    [SerializeField]
    int maxCoinsAmount;
    [SerializeField]
    GameObject spawnAreaGroup;
    [SerializeField]
    List<Transform> SpawnArea;
    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    List<GameObject> coinObject;
    [SerializeField]
    float respawnTimer=10;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnArea = spawnAreaGroup.transform.Cast<Transform>().ToList();
        spawncoins();
        timer = respawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        int coinlength = coinObject.Count;
        for (int i = 0; i < coinlength; i++)
        {//check for null values, then remove it
            if (coinObject[i] == null)
            {
                coinObject.Remove(coinObject[i]);
            }
        }
        //spawns new set of coins every timer reset
        timer-=Time.deltaTime;
        if(timer<=0)
        {
            spawncoins();
            timer = respawnTimer;
        }
    }
    public void spawncoins()//spawns dirt in an area specified by the areas in game
    {
        for (int i = 0; i <= maxCoinsAmount-coinObject.Count; i++)//how many coins it should spawn
        {
            //which spawnzone it should go
            var spawnzone = SpawnArea[Random.Range(0, SpawnArea.Count)];
            //which dirt type it uses for the instance
            //var dirtType = coinPrefab[Random.Range(0, coinPrefab.Count)];
            //get a random coodinate for the dirt item
            Vector3 origin = spawnzone.position;
            Vector3 range = spawnzone.localScale / 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),                                           
                                              Random.Range(-range.y, range.y),
                                              0);
            Vector3 dirtCoods = origin + randomRange;

            //spawn the dirt in the targeted zone and position, and add one to the list of dirt
            var dirtobject = Instantiate(coinPrefab, dirtCoods, Quaternion.identity);
            coinObject.Add(dirtobject);
        }
    }
}
