using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStatsUI : MonoBehaviour
{
    private Label hpLabel;
    private Label manaLabel;

    [SerializeField]
    private HealthPointStats hpStats;
    [SerializeField]
    private ManaPointStats manaStats;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        hpLabel = root.Q<Label>("hpLabel");
        manaLabel = root.Q<Label>("manaLabel");

        ChangeHp(hpStats.GetValue);
        ChangeMana(manaStats.GetValue);

        hpStats.AddOnChangeAction(ChangeHp);
        manaStats.AddOnChangeAction(ChangeMana);
    }

    private void ChangeHp(float newHp)
    {
        hpLabel.text = $"HP: {newHp}";
    }

    private void ChangeMana(float newMana)
    {
        manaLabel.text = $"Mana: {newMana}";
    }
}