using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAutoAttack : MonoBehaviour
{
    public Transform axeTransform; // Referência ao machado
    public float rotationSpeed = 360f; // graus por segundo
    public float attackInterval = 1f; // tempo entre ataques


    // private AxeHit axeHit;
    private float timer;

    void Start()
    {
        if (axeTransform == null)
            axeTransform = transform.Find("AxeHolder/axe");

        // axeHit = axeTransform.GetComponent<AxeHit>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackInterval)
        {
            StartCoroutine(PerformAttack());
            timer = 0f;
        }
    }

    IEnumerator PerformAttack()
    {
        // axeHit.StartAttack();

        float totalRotation = 360f; // graus
        float rotated = 0f;

        while (rotated < totalRotation)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            // axeTransform.RotateAround(transform.position, Vector3.back, rotationThisFrame);
            axeTransform.RotateAround(axeTransform.parent.position, Vector3.back, rotationThisFrame);

            rotated += rotationThisFrame;
            yield return null;
        }

        // axeHit.EndAttack();
    }
}