using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerDancer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject[] target;
    private Animator animator;
    int n;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        n = Random.Range(0, target.Length);
        agent.destination = target[n].transform.position;
    }
    IEnumerator Dislokacia()
    {
        yield return new WaitForSeconds(20f);
        animator.SetTrigger("Walk");
        n = Random.Range(0, target.Length);
        agent.destination = target[n].transform.position;
    }
    void Update()
    {
        if (agent.remainingDistance <3 && agent.remainingDistance > 2)
        {
            if (target[n] == target[0] || target[n] == target[1] || target[n] == target[2] || target[n] == target[3] || target[n] == target[4])
                animator.SetTrigger("Dancer");
            if (target[n] == target[5] || target[n] == target[6] || target[n] == target[7])
                animator.SetTrigger("Stoika");
            if (target[n] == target[8] || target[n] == target[9] || target[n] == target[10] || target[n] == target[11])
                animator.SetTrigger("Sitting");
            StartCoroutine(Dislokacia());
        }
    }
    
}
