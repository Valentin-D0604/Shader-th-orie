using UnityEngine;

public class ChameleonScript : MonoBehaviour
{
    [Header("ChangeColor")]
    [SerializeField] private Color color;
    [SerializeField] private string name = "_Color";
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float ChangeDuration;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    [ContextMenu("Change Color")]
    async void changeColorAsync()
    {
        float elapsedTime = 0.0f;
        Color startColor = _renderer.material.GetColor(name);
        while (elapsedTime < ChangeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            float lerpFactor = Mathf.Clamp01(elapsedTime / ChangeDuration);
            Color currentColor = Color.Lerp(startColor, color, lerpFactor);
            _renderer.material.SetColor(name, currentColor);

            await Awaitable.NextFrameAsync();
        }
        _renderer.material.SetColor(name, color);
    }
}
