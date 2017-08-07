using MonsterLove.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    public enum States
    {
        Idle,
        Alert,
        Chase, //keep checking for visual
        //LastSighting,
        LookingAround,
        ReturnToPost,
        Dead,
    }

    public NavMeshAgent navAgent;

    //public GameObject lastTimSpotted;
    public Vector3 ourPost, targetPos;


    //ray casts for vision cone
    public float maxDist = 10;
    public float visionConeAngle = 45f;
    public float closeEnough = 1;

    public float lookingAroundSpinSpeed = 1;
    public float lookingAroundTime = 1;
    private float counter = 0;


    StateMachine<States> fsm;

	void Start ()
    {
        fsm = StateMachine<States>.Initialize(this);

        fsm.ChangeState(States.Idle);

        ourPost = transform.position;
    }

    public bool CanSeeTim()
    {
        var ourForward = transform.forward;

        var dif = Tim.main.transform.position - transform.position;

        var distToTim = dif.magnitude;
        var dirToTim = dif.normalized;

        if (distToTim > maxDist)
            return false;
        //if (Vector3.Dot(ourForward, dirToTim) < visionConeAngle) //this is comparing against raw dot product not angle
        //    return;
        var angleBetween = Mathf.Abs(Vector3.Angle(ourForward, dirToTim));
        if (angleBetween > visionConeAngle)
            return false;

        //behind a wall check would go here


        targetPos = Tim.main.transform.position;
        targetPos.y = transform.position.y;
        return true;
    }

    void Idle_Enter()
    {
        Debug.Log("Just Chillin'");
    }

    void Idle_Update()
    {
        Debug.Log("Looking out for Tim.");
        //vision cone for tims

       
        if(CanSeeTim())
            fsm.ChangeState(States.Alert);
    }

    void Alert_Enter()
    {
        Debug.Log("TIM IS HERE!");
        
        navAgent.SetDestination(targetPos);
        fsm.ChangeState(States.Chase);
    }

    void Chase_Update()
    {
        if(CanSeeTim())
        {
            navAgent.SetDestination(targetPos);
        }

        //if at destination
        if(Vector3.Distance(transform.position, targetPos) < closeEnough)
        {
            fsm.ChangeState(States.LookingAround);
        }
    }

    void LookingAround_Enter()
    {
        transform.Rotate(0, lookingAroundSpinSpeed * lookingAroundTime / 2, 0);
    }

    void LookingAround_Update()
    {
        transform.Rotate(0, lookingAroundSpinSpeed * Time.deltaTime, 0);
        counter += Time.deltaTime;

        if(CanSeeTim())
        {
            fsm.ChangeState(States.Chase);
        }

        if(counter > lookingAroundTime)
        {
            fsm.ChangeState(States.ReturnToPost);
        }
    }

    void ReturnToPost_Enter()
    {
        Debug.Log("Sad, no tim.");

        navAgent.SetDestination(ourPost);
    }


    void ReturnToPost_Update()
    {
        if (CanSeeTim())
        {
            fsm.ChangeState(States.Chase);
        }

        if (Vector3.Distance(transform.position, ourPost) < closeEnough)
        {
            fsm.ChangeState(States.Idle);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * maxDist);
        var rot = Quaternion.Euler(0, visionConeAngle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rot * maxDist);
        var negRot = Quaternion.Euler(0, -visionConeAngle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, negRot * maxDist);
    }
}
