using UnityEngine;

public class SmoothColorChanger : MonoBehaviour, IColorChanger
{
    [SerializeField] private Material stepMaterial;
    [SerializeField] private Color targetColor;
    [SerializeField] private float colorLerp;

    public void ChangeColor()
    {
        stepMaterial.color = Color.Lerp(stepMaterial.color, targetColor, colorLerp * Time.deltaTime);
    }

    public void SetTargetColor(Color newColor)
    {
        targetColor = newColor;
    }
}