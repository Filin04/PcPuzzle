using UnityEngine;

public abstract class ComputerComponent : MonoBehaviour
{
    private EComponent _component;
    private string _componentName;
    private string _description;

    

    public ComputerComponent()
    {
    }

    public ComputerComponent(EComponent component, string componentName, string desc)
    {
        _component = component;
        _componentName = componentName;
        _description = desc;
    }

    public EComponent Component { get => _component; set => _component = value; }
    public string ComponentName { get => _componentName; set => _componentName = value; }
    public string Description { get => _description; set => _description = value; }

   
}
