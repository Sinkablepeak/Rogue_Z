using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBlood : MonoBehaviour
{
    [SerializeField] private GameObject parentTrigger;
    [SerializeField] private GameObject particle;
    public void SplashBlood()
    {
        parentTrigger.SetActive(false);
        Instantiate(particle, parentTrigger.transform.position, Quaternion.identity);
    }
}
