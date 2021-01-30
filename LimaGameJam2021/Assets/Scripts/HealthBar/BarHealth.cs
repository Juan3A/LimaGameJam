using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHealth : MonoBehaviour
{
    public Image HealthBar;

    void Start()
    {
        HealthBar.fillAmount = (float)(HealthValue.GetActualHealth() * 0.01f);

        //HealthValue.ReceiveDamage(80);
    }

    // Update is called once per frame
    void Update()
    {

        float aH = HealthValue.GetActualHealth() * 0.01f;

        HealthBar.fillAmount = aH;
    }
}

public static class HealthValue
{

    private static int maxHealth = 100;
    private static int actualHealth = 100;

    public static int GetActualHealth()
    {
        return actualHealth;
    }

    public static bool ReceiveDamage(int damage)
    {
        actualHealth = Mathf.Clamp(actualHealth-damage,0,maxHealth);

        return actualHealth <= 0;
    }

}

public static class Blade
{

    private static float Integrity = 100.0f;

    public static float BladeIntegrity()
    {
        return Integrity;
    }

    public static void DamageBlade(float damage)
    {

        Integrity = Mathf.Clamp(Integrity-damage,0,100);

    }

}
