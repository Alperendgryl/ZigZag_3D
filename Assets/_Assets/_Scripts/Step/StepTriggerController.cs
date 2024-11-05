using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTriggerController : MonoBehaviour
{
    [HideInInspector] public StepGenerator stepGenerator;
    private UIManager UIManager;
    private float waitForSec = 1f;

    private void Awake()
    {
        stepGenerator = FindObjectOfType<StepGenerator>();   
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AddRBWithDelay());
            UIManager = FindObjectOfType<UIManager>();
            UIManager.UpdateScore();
        }
    }

    private IEnumerator AddRBWithDelay()
    {
        stepGenerator.SpawnNewStep();

        yield return new WaitForSeconds(waitForSec);

        if (gameObject.GetComponent<Rigidbody>() == null) gameObject.AddComponent<Rigidbody>();

        yield return new WaitForSeconds(waitForSec * 3f);

        AddToPool(stepGenerator.stepPool, gameObject);
    }

    private void AddToPool(Queue<GameObject> stepPool, GameObject step)
    {
        step.SetActive(false);

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Destroy(rb);

        stepPool.Enqueue(gameObject);
    }
}
