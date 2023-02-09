using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;

    [SerializeField] protected float speed;

    [SerializeField] protected float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Attack()
    {
        
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
