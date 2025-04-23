using UnityEngine;
using TMPro;

public class UıManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreCount;

    public int score = 0;

    private void Update()
    {
        ScoreCount.text = $"{score}";
    }
}
