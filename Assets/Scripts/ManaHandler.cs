using UnityEngine;
using UnityEngine.UI;

public class ManaHandler : MonoBehaviour// handles regeneration and usage of mana
{
    [SerializeField]
    float maxMana = 100;
    [SerializeField]
    float regenRate = 50;
    float currentMana;
    Slider slider;

    void Awake()
    {
        currentMana = maxMana;
        //apply value to ui
        slider = transform.Find("Canvas").Find("Slider").GetComponent<Slider>();
        slider.maxValue = maxMana;
        slider.value = currentMana;
    }
    void Update()
    {
        if (currentMana < maxMana)// increase mana if below max, and update ui
        {
            currentMana += regenRate * Time.deltaTime;
            slider.value = currentMana;
        }
        if (currentMana > maxMana)//decrease mana if above max, and update ui
        {
            currentMana = maxMana;
            slider.value = currentMana;
        }
    }
    public bool UseMana(float amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            slider.value = currentMana;
            return true;
        }
        else
        {
            return false;
        }
    }
}



