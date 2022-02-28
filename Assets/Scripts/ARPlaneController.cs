using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]

public class ARPlaneController : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;

    void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        PlaceObjectOnPlane.onPlacedObject += DisablePlaneDetection;
    }

    void OnDisable()
    {
        PlaceObjectOnPlane.onPlacedObject -= DisablePlaneDetection;
    }

    void DisablePlaneDetection()
    {
        SetAllPlanesActive(false);
        m_ARPlaneManager.enabled = !m_ARPlaneManager.enabled;
    }

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }
}
