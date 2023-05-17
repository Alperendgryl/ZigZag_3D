using System.Collections.Generic;
using UnityEngine;

public class StepGenerator : MonoBehaviour, IStep
{
    [SerializeField] private GameObject stepsParent;
    [SerializeField] private GameObject stepPrefab;
    [SerializeField] private Transform startStep;
    [SerializeField] private Vector3 firstStepPosition;

    //Step Pool
    [SerializeField] private int poolSize = 50;
    [HideInInspector] public Queue<GameObject> stepPool;
    private Vector3 lastStepPosition;

    private void Awake()
    {
        InitializePool();
    }

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            SpawnNewStep();
        }
    }

    public void SpawnNewStep()
    {
        if (stepPool.Count == 0) return;

        GameObject step = stepPool.Dequeue();
        step.SetActive(true);

        SetStepPosition(step);
    }

    private void SetStepPosition(GameObject step)
    {
        Vector3 newPosition;

        if (Random.Range(0, 2) == 0)
        {
            newPosition = lastStepPosition + Vector3.right;
        }
        else
        {
            newPosition = lastStepPosition + Vector3.forward;
        }

        step.transform.position = newPosition;
        step.transform.rotation = transform.rotation;
        lastStepPosition = newPosition;
    }

    private void InitializePool()
    {
        stepPool = new Queue<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject step = Instantiate(stepPrefab, stepsParent.transform);
            step.GetComponent<StepTriggerController>().stepGenerator = this;
            step.SetActive(false);
            stepPool.Enqueue(step);
        }
        lastStepPosition = startStep.position + firstStepPosition;
    }
}
