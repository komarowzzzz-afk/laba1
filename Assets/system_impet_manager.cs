
using UnityEngine;

public class System_Input : MonoBehaviour
{
    [Header("Canvas выбора")]
    [SerializeField] public Canvas System_Input_Canvas;

    [Header("Варианты XR игрока")]
    [SerializeField] public GameObject XR_base_device;
    [SerializeField] public GameObject XR_action_base;

    [Header("Симулятор")]
    [SerializeField] public GameObject XR_device_simulator;

    private void Start()
    {
        // До выбора режима оба игрока выключены
        XR_base_device.SetActive(false);
        XR_action_base.SetActive(false);

        // Симулятор должен оставаться включённым
        XR_device_simulator.SetActive(true);

        // Останавливаем игровое время до выбора
        Time.timeScale = 0;
    }

    public void OnClick(int indecs)
    {
        // Сначала выключаем оба варианта игрока
        XR_base_device.SetActive(false);
        XR_action_base.SetActive(false);

        // Включаем только выбранный вариант
        if (indecs == 1)
        {
            XR_base_device.SetActive(true);
            Debug.Log("Выбран XR Device-Based");
        }
        else if (indecs == 2)
        {
            XR_action_base.SetActive(true);
            Debug.Log("Выбран XR Action-Based");
        }
        else
        {
            Debug.LogWarning("Неизвестный режим управления");
            return;
        }

        // Симулятор оставляем включённым
        XR_device_simulator.SetActive(true);

        // Скрываем меню выбора
        System_Input_Canvas.gameObject.SetActive(false);

        // Возобновляем игровое время
        Time.timeScale = 1;
    }
}
