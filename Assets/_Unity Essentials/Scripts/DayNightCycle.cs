using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day Length Settings")]
    [Tooltip("How many real-world seconds a full 24-hour cycle takes.")]
    [SerializeField] private float dayLengthInSeconds = 300f;

    private float rotationSpeed;

    private void Start()
    {
        UpdateRotationSpeed();
    }

    private void Update()
    {
        // Rotate around the X-axis to simulate the sun moving across the sky
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void UpdateRotationSpeed()
    {
        // 360 degrees per full day cycle
        rotationSpeed = 360f / dayLengthInSeconds;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (dayLengthInSeconds < 1f)
            dayLengthInSeconds = 1f;

        UpdateRotationSpeed();
    }
#endif
}
