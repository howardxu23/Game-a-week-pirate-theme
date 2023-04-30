using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIscript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotatonSpeed;

    public int maxHealth = 100;
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
