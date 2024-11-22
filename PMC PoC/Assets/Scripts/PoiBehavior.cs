using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiBehavior : MonoBehaviour
{
    public float[] BluforAsset = { 0, 0, 0, 0};
    float BluPower = 0;
    public float[] RedforAsset = { 0, 0, 0, 0};
    float RedPower = 0;

    private void Start()
    {
        Invoke("CalcCasualty", 5);
    }

    private void CalcCasualty()
    {
        BluPower = CalcAssetListPower(BluforAsset);
        Debug.Log($"{gameObject}'s BluPower is : {BluPower}");

        RedPower = CalcAssetListPower(RedforAsset);
        Debug.Log($"{gameObject}'s RedPower is : {RedPower}");

        if (BluPower <= 0 || RedPower <= 0)
        {
            Invoke("CalcCasualty", 5);
            return;
        }

            float BluePowerOverRed = BluPower / (BluPower + RedPower);

        if (Random.value < BluePowerOverRed)
        {
            //Red casualty
            Debug.Log("Red casualty");
        }
        else
        {
            //Blue casualty
            Debug.Log("Blue casualty");
        }

        Invoke("CalcCasualty", 5);
    }

    private float CalcAssetListPower(float[] AssetList)
    {
        float power = 0;
        float powerCalcIndex = 1;
        foreach (float i in AssetList)
        {
            power += i * powerCalcIndex;
            powerCalcIndex += .5f;
        }

        return power;
    }
}
