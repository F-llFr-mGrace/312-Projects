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

    [Header("Player Resources")]
    public int money;
    [SerializeField] TextMeshProUGUI moneyTxt;
    [SerializeField] TextMeshProUGUI blueforAssetListText;
    [SerializeField] TextMeshProUGUI redforAssetListText;

    void Start()
    {
        CenterCam(); 
    }

    public void UpdatePlayerMoneyAndAssetCount()
    {
        moneyTxt.text = $"Your funds: ${money}";
        if (PoiScript != null)
        {
            UpdateAssetCount(PoiScript.BluforAsset, blueforAssetListText);
            UpdateAssetCount(PoiScript.RedforAsset, redforAssetListText);
        }
    }

    private void UpdateAssetCount(float[] TeamAssetList, TextMeshProUGUI textToUpdate)
    {
        int index = 0;
        foreach (float i in TeamAssetList)
        {
            if (index == 0)
            {
                textToUpdate.text = $"Inf -> {TeamAssetList[index]}\n";
            }
            else if (index == 1)
            {
                textToUpdate.text += $"Mech Inf -> {TeamAssetList[index]}\n";
            }
            else if (index == 2)
            {
                textToUpdate.text += $"Tank -> {TeamAssetList[index]} \n";
            }
            else if (index == 3)
            {
                textToUpdate.text += $"Heli -> {TeamAssetList[index]}";
            }
            else
            {
                Debug.Log("Unrecognised asset type!");
            }

            index++;
        }
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
        UpdatePlayerMoneyAndAssetCount(); //Has to go past new POI Script
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
