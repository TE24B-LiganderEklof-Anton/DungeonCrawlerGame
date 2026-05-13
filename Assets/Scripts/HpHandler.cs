using UnityEngine;
using UnityEngine.UI;

public class HpHandler : MonoBehaviour
{
    [SerializeField]
    float maxHp = 100;
    float currentHp;
    Slider hpSlider;
    void Start()
    {
        currentHp = maxHp;
        hpSlider = transform.Find("Canvas").transform.Find("HpSlider").GetComponent<Slider>();
    }

    public void ChangeHp(float amount)
    {
        //calculate and apply new Hp
        float newHp = currentHp + amount;
        newHp = Mathf.Clamp(newHp, 0, maxHp);
        currentHp = newHp;
        //update ui
        hpSlider.value = currentHp / maxHp;
    }
}
