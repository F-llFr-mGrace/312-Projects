using Cinemachine;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public delegate void DelWeAreWinning();

    public event DelWeAreWinning WeAreWinningSignal;

    [Header("Center of world default camera view")]
    [SerializeField] GameObject camCenter;
    [Header("Text displaying name of selected Town/Area")]
    [SerializeField] TextMeshProUGUI textPOI;
    [Header("What gameObject is the camera")]
    [SerializeField] CinemachineVirtualCamera camera;

    [Header("What is selected")]
    [SerializeField] GameObject[] allPOI;
    GameObject selectedPOI;
    PoiBehavior PoiScript;

    [Header("All UI Elements and Presets")]
    [SerializeField] GameObject[] allUiElements;
    [SerializeField] GameObject[] AlwaysInclude;
    [SerializeField] GameObject[] CenteredView;
    [SerializeField] GameObject[] SelectedTown;
    [SerializeField] GameObject[] MoveUnitsHere;
    [SerializeField] GameObject[] BuyUnitsHere;

    [Header("Player Resources")]
    public int money;
    [SerializeField] TextMeshProUGUI moneyTxt;
    [SerializeField] TextMeshProUGUI blueforAssetListText;
    [SerializeField] TextMeshProUGUI redforAssetListText;

    [SerializeField] TextMeshProUGUI buyOrMoveText;

    [SerializeField] TMP_Dropdown TownsToPickFrom;
    [SerializeField] TMP_Dropdown AssetsToPickFrom;

    bool moveIfTrue = true;

    List<GameObject> tmpPOI = new List<GameObject>();

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
        checkForWin();
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
        if (!cityToClick.CompareTag("FOB"))
        {
            SelectedTown[2].SetActive(false);
        }

        camera.m_Lens.FieldOfView = 20;
        textPOI.text = cityToClick.name;
        camera.Follow = cityToClick.transform;
        camera.LookAt = cityToClick.transform;
        selectedPOI = cityToClick;

        PoiScript = cityToClick.GetComponent<PoiBehavior>();
        UpdatePlayerMoneyAndAssetCount(); //Has to go past new POI Script
    }

    public void moveUnitsHere()
    {
        UiElementsPreset(MoveUnitsHere);
        buyOrMoveText.text = "Move";
        moveIfTrue = true;


        TownsToPickFrom.ClearOptions();
        tmpPOI.Clear();
        foreach (GameObject POI in allPOI)
        {
            if (POI == selectedPOI) { continue; }
            TownsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"{POI.name} - {Mathf.Round(Vector3.Distance(selectedPOI.transform.position, POI.transform.position))} km"));
            tmpPOI.Add(POI);
        }

        AssetsToPickFrom.ClearOptions();
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Inf"));
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Mech Inf"));
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Tank"));
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Heli"));
    }

    public void buyUnitsHere()
    {
        UiElementsPreset(BuyUnitsHere);
        buyOrMoveText.text = "Buy";
        moveIfTrue = false;

        AssetsToPickFrom.ClearOptions();
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Inf"));
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Mech Inf"));
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Tank"));
        AssetsToPickFrom.options.Add(new TMP_Dropdown.OptionData($"Heli"));
    }

    public void buyMove()
    {
        if (moveIfTrue)
        {
            var targetPOIScript = tmpPOI[TownsToPickFrom.value].GetComponent<PoiBehavior>();
            var selectedPOIScript = selectedPOI.GetComponent<PoiBehavior>();
            
            if (AssetsToPickFrom.value == 0)
            {
                MoveAssets(targetPOIScript, selectedPOIScript, 0);
            }
            else if (AssetsToPickFrom.value == 1)
            {
                MoveAssets(targetPOIScript, selectedPOIScript, 1);
            }
            else if (AssetsToPickFrom.value == 2)
            {
                MoveAssets(targetPOIScript, selectedPOIScript, 2);
            }
            else if (AssetsToPickFrom.value == 3)
            {
                MoveAssets(targetPOIScript, selectedPOIScript, 3);
            }
            else
            {
                Debug.Log("No assets moved");
            }
        }
        else
        {
            if (AssetsToPickFrom.value == 0)
            {
                if (money >= 2)
                {
                    PoiScript.BluforAsset[0] += 1;
                    money -= 2;
                }
            }
            else if (AssetsToPickFrom.value == 1)
            {
                if (money >= 3)
                {
                    PoiScript.BluforAsset[1] += 1;
                    money -= 3;
                }
            }
            else if (AssetsToPickFrom.value == 2)
            {
                if (money >= 4)
                {
                    PoiScript.BluforAsset[2] += 1;
                    money -= 4;
                }
            }
            else if (AssetsToPickFrom.value == 3)
            {
                if (money >= 5)
                {
                    PoiScript.BluforAsset[3] += 1;
                    money -= 5;
                }
            }
            else
            {
                Debug.Log("No assets moved");
            }
        }
        UpdatePlayerMoneyAndAssetCount();
    }

    private void MoveAssets(PoiBehavior targetPOIScript, PoiBehavior selectedPOIScript, int assetType)
    {
        if (targetPOIScript.BluforAsset[assetType] > 0)
        {
            targetPOIScript.BluforAsset[assetType] -= 1;
            selectedPOIScript.BluforAsset[assetType] += 1;
        }
        else
        {
            Debug.Log("Not enough assets to move!");
        }
    }

    public void BackButton()
    {
        TownClicked(selectedPOI);
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

    void checkForWin()
    {
        foreach (GameObject POI in allPOI)
        {
            var script = POI.GetComponent<PoiBehavior>();
            foreach (float asset in script.RedforAsset)
            {
                if (asset > 0)
                {
                    return;
                }
            }
        }
        WeAreWinningSignal?.Invoke();
    }
}
