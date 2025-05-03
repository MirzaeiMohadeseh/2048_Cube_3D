using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class TouchSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityAction onpointerDownEvent;
    public UnityAction onpointerUpEvent;
    public UnityAction<float> onpointerDragEvent;
    public Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
       if (onpointerDownEvent != null)
        {
            onpointerDownEvent.Invoke();
        }
       if (onpointerDragEvent != null) 
        {
            onpointerDragEvent.Invoke(slider.value);

        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {if (onpointerUpEvent != null)
        {
            onpointerUpEvent.Invoke();
        }
        // reset slider value when finger is up
        slider.value = 0f;
    }
    public void OnSliderValueChanged(float value)
    {

        if (onpointerDragEvent != null)
        {
            onpointerDragEvent.Invoke(value);

        }
    }
    private void OnDestroy()
    {
            slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}
