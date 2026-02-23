using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStatsUI : MonoBehaviour
{
    private Label hpLabel;
    private Label manaLabel;

    private int hp = 100;
    private int mana = 50;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        hpLabel = root.Q<Label>("hpLabel");
        manaLabel = root.Q<Label>("manaLabel");

        Refresh();
    }

    public void SetStats(int newHp, int newMana)
    {
        hp = newHp;
        mana = newMana;
        Refresh();
    }

    private void Refresh()
    {
        hpLabel.text = $"HP: {hp}";
        manaLabel.text = $"Mana: {mana}";
    }
}