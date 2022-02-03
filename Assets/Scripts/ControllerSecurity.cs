using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerSecurity : MonoBehaviour
{
    [SerializeField] private GameObject[] dancer;
    private Animator animator;
    private NavMeshAgent security;
    int n;
    void Start()
    {
        security = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        dancer = GameObject.FindGameObjectsWithTag("Dancer");
        StartCoroutine(Dislokacia());
    }
    IEnumerator Dislokacia()
    {
        yield return new WaitForSeconds(15f);
        animator.SetTrigger("Walking");
        n = Random.Range(0, dancer.Length);
        security.destination = dancer[n].transform.position;
    }
    void Update()
    {
        if (security.remainingDistance < 3 && security.remainingDistance > 2)
        {
            animator.SetTrigger("Touch");
            StartCoroutine(Dislokacia());
        }
    }
}
