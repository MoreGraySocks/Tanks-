using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    
    public float m_CloseDistance = 8f;
    public Transform m_Turret;

    private GameObject m_Player;
    private UnityEngine.AI.NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;

    private bool m_Follow;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start function has run");
        m_Follow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Follow == false)
        {
            return;
        }

        float distance = (m_Player.transform.position - transform.position).magnitude;
        if (distance > m_CloseDistance)
        {
            //Debug.Log("AI should be moving now");
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            //Debug.Log("AI should have stopped moving");
            m_NavAgent.isStopped = true;
        }

        if (m_Turret != null)
        {
            //Debug.Log("AI should be looking at player with turret");
            m_Turret.LookAt(m_Player.transform);
        }
    }

    private void Awake()
    {
       // Debug.Log("Awake function has run");
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnEnable()
    {
        //Debug.Log("On enable has run");
        m_Rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        //Debug.Log("On disable has run");
        m_Rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger has been entered");
        if (other.tag == "Player")
        {
            //Debug.Log("Colliding entity is player");
            m_Follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger has been exited");
        if (other.tag == "Player")
        {
            //Debug.Log("Colliding entity is player");
            m_Follow = false;
        }
    }


}
