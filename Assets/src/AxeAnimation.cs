using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator axeAnimator;
    private AxeHit axeHit;

    void Start()
    {
        axeAnimator = transform.Find("axe").GetComponent<Animator>();
        axeHit = transform.Find("axe").GetComponent<AxeHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            axeAnimator.SetTrigger("attack");
            axeHit.StartAttack();
            Invoke("StopAttack", 0.5f);
        }
    }

    void StopAttack()
    {
        axeHit.EndAttack();
    }

   
}
