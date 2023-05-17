using UnityEngine;

public class ColorCycler : MonoBehaviour
{
    [SerializeField] private Color[] materialColors;
    [SerializeField] private float cycleTime = 2f;

    private float currentTime;
    private int colorIndex = 0;

    private SmoothColorChanger smoothColorChanger;
    private void Awake()
    {
        smoothColorChanger = GetComponent<SmoothColorChanger>();
    }

    private void Update()
    {
        UpdateTimer();
        CheckColorChange();
        ApplyColorChange();
    }

    private void UpdateTimer()
    {
        currentTime -= Time.deltaTime;
    }

    private void CheckColorChange()
    {
        if (currentTime <= 0)
        {
            colorIndex = (colorIndex + 1) % materialColors.Length;
            currentTime = cycleTime;
        }
    }

    private void ApplyColorChange()
    {
        smoothColorChanger.SetTargetColor(materialColors[colorIndex]);
        smoothColorChanger.ChangeColor();
    }
}
