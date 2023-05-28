using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    NavMeshAgent meshAgent;
    float timer;
    Animator anim;

    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomDirection = Player.Instance.transform.position + Random.insideUnitSphere * 30f;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 30f, 1);
        meshAgent.SetDestination(hit.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 20f)
        {
            meshAgent.isStopped = true;
            Destroy(gameObject);
            NPCManager.Instance.DecreaseCounter();
        }
    }

    private void OnAnimatorMove()
    {
        meshAgent.velocity = anim.velocity; 
    }
}
