using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] public int Damage = 10;

    [SerializeField] private float timeToSelfDestruct = 5.0f;

    void OnEnable()
    {
        Destroy(gameObject, timeToSelfDestruct);
    }
}