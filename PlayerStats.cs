using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    private int gold;
    public int Gold
    {
        get { return gold; }
        set {
                goldText.color = newColor;
                goldText.text = value.ToString() + " Gold";
                gold = value;
            }
    }

    public Text goldText;
    public Color newColor;


    private void Start()
    {
        newColor = new Color();
        ColorUtility.TryParseHtmlString("#323232FF", out newColor);

        Gold = 0;
        goldText.text = Gold.ToString() + " Gold";
        goldText.color = newColor;

    }
}