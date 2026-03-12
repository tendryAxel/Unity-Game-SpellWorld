using UnityEngine;
using UnityEngine.UIElements;
using MyUILibrary;

public class PlayerStatsUI : MonoBehaviour
{
    private Label hpLabel;
    private Label manaLabel;
    private RadialProgress chargeProgress;

    [SerializeField]
    private HealthPointStats hpStats;
    [SerializeField]
    private ManaPointStats manaStats;
    [SerializeField]
    private PlayerSpellSc playerSpell;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        hpLabel = root.Q<Label>("hpLabel");
        manaLabel = root.Q<Label>("manaLabel");
        chargeProgress = root.Q<RadialProgress>("chargeProgress");

        ChangeHp(hpStats.GetValue);
        ChangeMana(manaStats.GetValue);

        hpStats.AddOnChangeAction(ChangeHp);
        manaStats.AddOnChangeAction(ChangeMana);
        playerSpell.RegisterOnHandedManaPercentageChange(ChangeHandedPercentage);
    }

    private void ChangeHp(float newHp)
    {
        hpLabel.text = $"HP: {newHp}";
    }

    private void ChangeMana(float newMana)
    {
        manaLabel.text = $"Mana: {newMana}";
    }

    private void ChangeHandedPercentage(int value)
    {
        chargeProgress.progress = value;
    }
}