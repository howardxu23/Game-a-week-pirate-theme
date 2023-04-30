using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIscript : shipMovement
{
    NavMeshAgent AIShip;
    [SerializeField]
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        AIShip = gameObject.GetComponent<NavMeshAgent>();
        AIShip.updateRotation = false;
        AIShip.updateUpAxis = false;
        //gets player pos
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        AIShip.SetDestination(player.transform.position);

        //faces towards player
        /*
        Vector3 targetDirection = player.transform.position - transform.position;
        targetDirection.z = 0;
        print(targetDirection+" target vector");
        float singlestep = rotatonSpeed * Time.deltaTime;

        var newDirection = Vector3.RotateTowards(transform.up, targetDirection, singlestep, 0.0f);
        print(newDirection+" new vector");
        transform.rotation = Quaternion.LookRotation(newDirection);*/

        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg-90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotatonSpeed);
    }
}
