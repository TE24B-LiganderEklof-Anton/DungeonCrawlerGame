using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManaHandler : MonoBehaviour
{
    [SerializeField]
    float maxMana = 100;
    [SerializeField]
    float regenRate = 5;
    float currentMana;
    Slider slider;

    void Awake()
    {
        currentMana = maxMana;
        slider = transform.Find("Canvas").Find("Slider").GetComponent<Slider>();
        slider.maxValue = maxMana;
        slider.value = currentMana;
    }
    void Update()
    {
        if (currentMana < maxMana)
        {
            currentMana += regenRate * Time.deltaTime;
            slider.value = currentMana;
        }
        if (currentMana > maxMana)
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



