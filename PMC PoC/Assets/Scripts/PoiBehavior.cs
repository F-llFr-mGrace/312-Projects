using UnityEngine;

public class PoiBehavior : MonoBehaviour
{
    public float[] BluforAsset = { 0, 0, 0, 0};
    float BluPower = 0;
    public float[] RedforAsset = { 0, 0, 0, 0};
    float RedPower = 0;

    public GUIController player;

    public int money;

    private void Start()
    {
        Invoke("CalcCasualty", 5);
    }

    private void CalcCasualty()
    {
        BluPower = CalcAssetListPower(BluforAsset);

        RedPower = CalcAssetListPower(RedforAsset);

        if (BluPower <= 0 || RedPower <= 0)
        {
            Invoke("CalcCasualty", 5);
            return;
        }

        float BluePowerOverRed = BluPower / (BluPower + RedPower);

        if (Random.value < BluePowerOverRed)
        {
            //Red casualty
            player.money += CauseCasAndCalcMoney(RedforAsset);
            player.UpdatePlayerMoneyAndAssetCount();
        }
        else
        {
            //Blue casualty
            money += CauseCasAndCalcMoney(BluforAsset);
            player.UpdatePlayerMoneyAndAssetCount();
        }

        Invoke("CalcCasualty", 5);
    }

    private int CauseCasAndCalcMoney(float[] AssetListToKill)
    {
        int randomAssetGroupIndex = Random.Range(0, AssetListToKill.Length);

        while (AssetListToKill[randomAssetGroupIndex] <= 0)
        {
            randomAssetGroupIndex = Random.Range(0, AssetListToKill.Length);
        }

        AssetListToKill[randomAssetGroupIndex] -= 1;

        if (randomAssetGroupIndex == 0)
        {
            return 2;
        }
        else if (randomAssetGroupIndex == 1)
        {
            return 3;
        }
        else if (randomAssetGroupIndex == 2)
        {
            return 4;
        }
        else if (randomAssetGroupIndex == 3)
        {
            return 5;
        }
        else
        {
            Debug.Log($"No money given!!");
            return 0;
        }
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
