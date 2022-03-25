using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StateMachineh : MonoBehaviour
{
   
    public enum State
    {
        
        Attack,
        FollowTrail,
        Defence,
        RunAway,
        GotoIdlePoint,

        

    }

    public State currentState;

    public AIMovement aiMovement;

    public GameObject waypointPrefab;

    private Transform waypointPos;

    private void Start()
    {
       aiMovement = GetComponent<AIMovement>();
      
       waypointPos = waypointPrefab.transform;

        NextState();
    }
    
    private void NextState()
    {
        switch (currentState)
        {
            case State.Attack:
                StartCoroutine(AttackState());
                break;
            case State.Defence:
                StartCoroutine(DefenceState());
                break;
            case State.RunAway:
                StartCoroutine(RunAwayState());
                break;
            case State.GotoIdlePoint:
                StartCoroutine(GotoIdlePoint());
                break;
            case State.FollowTrail:
                StartCoroutine(FollowTrail());
                break;

        }
    }

    private IEnumerator AttackState()
    {
        Debug.Log("Attack: Enter");
        while (currentState == State.Attack)
        {
            aiMovement.AIMoveTowards(aiMovement.player);
            if (!aiMovement.IsPlayerInRange())
            {
                currentState = State.GotoIdlePoint;
            }
            
            yield return null;
        }
        Debug.Log("Attack: Exit");
        NextState();
    }
    
    private IEnumerator DefenceState()
    {
        Debug.Log("Defence: Enter");
        
        float timeOfLastSpawn = Time.time; 
        while (currentState == State.Defence)
        {
            Debug.Log("Currently Defending");
            
           
                
            if ( timeOfLastSpawn + 3f  < Time.time)
            {
                timeOfLastSpawn = Time.time;
            }
            
            yield return null;
            Debug.Log("next frame Currently Defending");
        }
        Debug.Log("Defence: Exit");
        NextState();
    }
    
    private IEnumerator RunAwayState()
    {
        Debug.Log("RunAway: Enter");
        while (currentState == State.RunAway)
        {
            Debug.Log("Currently Running Away");
            
            yield return null;
        }
        Debug.Log("RunAway: Exit");
        NextState();
    }
    
    private IEnumerator GotoIdlePoint()
    {
        Debug.Log("GotoIdlePoint: Enter");
        
        aiMovement.FindClosestWaypoint();
        
        while (currentState == State.GotoIdlePoint)
        {
            aiMovement.WaypointUpdate();
            aiMovement.AIMoveTowards(aiMovement.position[aiMovement.positionIndex].transform);
            if (aiMovement.IsPlayerInRange())
            {
                currentState = State.Attack;
            }
            else
            {
                currentState = State.FollowTrail;
            }

            yield return null;
        }
        Debug.Log("GotoIdlePoint: Exit");
        NextState();
    }

    private IEnumerator FollowTrail()
    {
        Debug.Log("Follow Trail: Enter");
            aiMovement.AIMoveTowardsPWP(waypointPos);
            
        yield return null;
        Debug.Log("Follow Trail: Exit");
        
    }


}
