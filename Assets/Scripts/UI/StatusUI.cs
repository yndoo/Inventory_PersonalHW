using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    public TextMeshProUGUI AttackValue;
    public TextMeshProUGUI DefenseValue;
    public TextMeshProUGUI HealthValue;
    public TextMeshProUGUI CriticalValue;
    public TextMeshProUGUI CuteValue;

    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerStat playerS = GameManager.Instance.Player.Stat;
        AttackValue.text = playerS.Attack.ToString();
        DefenseValue.text = playerS.Defense.ToString();
        HealthValue.text = playerS.Health.ToString();
        CriticalValue.text = playerS.CriticalRate.ToString();
        CuteValue.text = playerS.Cute.ToString();
    }
}
