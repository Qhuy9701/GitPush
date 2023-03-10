using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public float ManaPerSecond;
    public float maxMana;
    public float currentMana;
    public Slider playerManaSlider;
 
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        InvokeRepeating("RegenerateMana", 0f, 1f);
        Mana();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mana(){
        currentMana = maxMana;
        playerManaSlider.maxValue = maxMana;
        playerManaSlider.value = maxMana;
        
    }

    public void UseMana(float mana)
    {
        if(mana <= 0) return;
        currentMana -= mana;
        playerManaSlider.value = currentMana;
       
    }

    public void addMana(float manaAmount)
    {
        currentMana += manaAmount;
        if(currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        playerManaSlider.value = currentMana;
    }

    private void RegenerateMana()
    {
        currentMana = Mathf.Min(currentMana + ManaPerSecond, maxMana);
    }
}
