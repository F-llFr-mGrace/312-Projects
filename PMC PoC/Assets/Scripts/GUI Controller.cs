using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [Header("Center of world default camera view")]
    [SerializeField] GameObject camCenter;
    [Header("Text displaying name of selected Town/Area")]
    [SerializeField] TextMeshProUGUI textPOI;
    [Header("What gameObject is the camera")]
    [SerializeField] CinemachineVirtualCamera camera;

    [Header("What is selected")]
    GameObject selectedPOI;
    PoiBehavior PoiScript;

    [Header("All UI Elements and Presets")]
    [SerializeField] GameObject[] allUiElements;
    [SerializeField] GameObject[] AlwaysInclude;
    [SerializeField] GameObject[] CenteredView;
    [SerializeField] GameObject[] SelectedTown;

    void Start()
    {
        CenterCam(); 
    }

    public void CenterCam()
    {
        UiElementsPreset(CenteredView);
        camera.m_Lens.FieldOfView = 50;
        textPOI.text = camCenter.name;
        camera.Follow = camCenter.transform;
        camera.LookAt = camCenter.transform;
        selectedPOI = camCenter;

        PoiScript = null;
        Debug.Log($"PoiScript is --{PoiScript}--");
    }

    public void TownClicked(GameObject cityToClick)
    {
        UiElementsPreset(SelectedTown);

        camera.m_Lens.FieldOfView = 20;
        textPOI.text = cityToClick.name;
        camera.Follow = cityToClick.transform;
        camera.LookAt = cityToClick.transform;
        selectedPOI = cityToClick;

        PoiScript = cityToClick.GetComponent<PoiBehavior>();
        Debug.Log($"PoiScript is --{PoiScript}--");
    }

    private void UiElementsPreset(GameObject[] preset)
    {
        foreach (GameObject gObj in allUiElements)
        {
            gObj.SetActive(false);
        }

        foreach (GameObject gObj in AlwaysInclude)
        {
            gObj.SetActive(true);
        }

        foreach (GameObject gObj in preset)
        {
            gObj.SetActive(true);
        }
    }
}
