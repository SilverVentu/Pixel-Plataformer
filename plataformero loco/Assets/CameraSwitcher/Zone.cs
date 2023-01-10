using System;
using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Camera zoneCamera;
    [SerializeField] private GameObject zonePerspective;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zoneCamera.enabled = false;
            zoneCamera.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Input.anyKey)
        {
            var walker = other.GetComponent<AdvancedWalkerController>();
            if (walker != null) walker.cameraTransform = zonePerspective.transform;
            Debug.Log("nopresionaste nada");
        }
    }
    
}
