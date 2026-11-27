using UnityEngine;
using TMPro;

public class RankPanel_RankLine : MonoBehaviour
{
    [SerializeField] TMP_Text rankNoTextField;
    [SerializeField] TMP_Text themeNameTextField;
    [SerializeField] TMP_Text nameTextField;
    [SerializeField] TMP_Text clearTimerTextField;

    [SerializeField] string rankNoString;
    [SerializeField] Color rankColor;


    void Start()
    {
        rankNoTextField.text = rankNoString;

        rankNoTextField.color = rankColor;
        themeNameTextField.color = rankColor;
        nameTextField.color = rankColor;
        clearTimerTextField.color = rankColor;
    }

    public void SetRankLine(string themeName, string name, float clearTime)
    {
        themeNameTextField.text = themeName;
        nameTextField.text = name;
        clearTimerTextField.text = Timer.FormatTime(clearTime);
    }


    public void SetRankEmptyLine()
    {
        SetRankLine("----", "----", 0);
    }


}
