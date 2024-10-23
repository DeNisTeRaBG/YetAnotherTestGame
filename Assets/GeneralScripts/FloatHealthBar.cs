using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class FloatHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private Camera look;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        look = Camera.main.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = look.transform.rotation;
        transform.position = target.position + offset;
    }
}
