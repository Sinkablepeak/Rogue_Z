using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRocks : MonoBehaviour
{
    [SerializeField] private GameObject parentTrigger;
    [SerializeField] private GameObject particle;
    public void InstantiateRock()
    {
        parentTrigger.SetActive(false);
        Instantiate(particle, parentTrigger.transform.position, Quaternion.identity);
    }
}
