/*using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }
}*/
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public float moveSpeed = 20f; // Скорость перемещения по оси Z
    private Vector3 offset;
    private float zCoord;
    private Rigidbody rb;
    private bool isDragging = false;

    [SerializeField] private ComponentSlot hintInstance; // Экземпляр подсказки

    private float lastClickTime = 0f;
    private float doubleClickDelay = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing.");
        }
    }

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;

        /* if (gameObject != null)
         {
             *//* hintInstance = Instantiate(hintInstance, transform.position, Quaternion.identity);*//*
             // Делаем подсказку полупрозрачной
             hintInstance.GetComponent<MeshRenderer>().enabled = true;
             SetTransparency(hintInstance.gameObject, 0.5f);
         }*/

        float timeSinceLastClick = Time.time - lastClickTime;
        if (timeSinceLastClick <= doubleClickDelay)
        {
            // При двойном клике отображаем информацию о компоненте
            ShowComponentInfo();
        }
        lastClickTime = Time.time;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 newPos = GetMouseWorldPos() + offset;
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            float moveZ = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                moveZ = moveSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveZ = -moveSpeed * Time.deltaTime;
            }

            if (moveZ != 0f)
            {
                Vector3 newPos = transform.position + new Vector3(0, 0, moveZ);
                rb.MovePosition(newPos);
            }
        }
    }

    // Метод для установки прозрачности объекта
    private void SetTransparency(GameObject obj, float transparency)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = transparency;
        renderer.material.color = color;
    }

    //private void OnMouseDown()
    //{
    //    float timeSinceLastClick = Time.time - lastClickTime;
    //    if (timeSinceLastClick <= doubleClickDelay)
    //    {
    //        // При двойном клике отображаем информацию о компоненте
    //        ShowComponentInfo();
    //    }
    //    lastClickTime = Time.time;
    //}

    private void ShowComponentInfo()
    {
        // Ваш код для отображения информации о компоненте
        UIManager uIManager = GameObject.FindObjectOfType<UIManager>();
        if (uIManager != null)
        {
            ComputerComponent component = gameObject.GetComponent<ComputerComponent>();
            if (component != null)
            {
                uIManager.OpenInfo(component);
            }
        }
    }
}



