using UnityEngine;
using UnityEngine.Events;

public class ComponentSlot : MonoBehaviour
{
    GameObject slot;
    [SerializeField] private EComponent correctComponentName;
    [SerializeField] UnityEvent OnDropComponent;
    [SerializeField] public GameObject particleEffectPrefab; // Префаб для системы частиц
    [SerializeField] public AudioClip placementSound; // Звуковой эффект
    private AudioSource audioSource;

    private void Start()
    {
        slot = gameObject;
        EnebledChildren(false);
        slot.GetComponent<MeshRenderer>().enabled = false;

        // Создание AudioSource компонента
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        DragObject dragObject = other.GetComponent<DragObject>();
        if (dragObject != null)
        {
            GameObject gameObject = other.gameObject;
            ComputerComponent component = gameObject.GetComponent<ComputerComponent>();
            if (component != null && component.Component == correctComponentName)
            {
                other.transform.position = transform.position;
                dragObject.enabled = false;
                gameObject.SetActive(false);
                CorrectDropComponent();
                Debug.Log($"{component.ComponentName} установлено правильно!");
            }
            else
            {
                Debug.Log($"Неправильный компонент: {other.name}. Ожидалось: {correctComponentName}");
            }
        }
    }

    private void CorrectDropComponent()
    {
        EnebledChildren(true);
        TriggerChildren(false);

        // Воспроизведение звукового эффекта
        if (placementSound != null)
        {
            audioSource.PlayOneShot(placementSound);
        }

        // Воспроизведение эффекта частиц
        if (particleEffectPrefab != null)
        {
            GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 2.0f); // Удалить эффект после 2 секунд
        }

        OnDropComponent.Invoke();
    }
    private void EnebledChildren(bool enable)
    {
        if (slot != null)
        {
            slot.GetComponent<MeshRenderer>().enabled = enable;

            var childrens = slot.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < childrens.Length; i++)
            {
                childrens[i].enabled = enable;
            }
        }
    }

    private void TriggerChildren(bool enable)
    {
        if (slot != null)
        {
            slot.GetComponent<BoxCollider>().isTrigger = enable;

            var childrens = slot.GetComponentsInChildren<BoxCollider>();
            for (int i = 0; i < childrens.Length; i++)
            {
                childrens[i].isTrigger = false;
            }
        }
    }
}
