using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private EnemyFollow enemyFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyFollow = GetComponentInParent<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyFollow.SetChase(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyFollow.SetChase(false);
        }
    }
}
