public class PSU : ComputerComponent
{
    public PSU()
    {
        Component = EComponent.PSU;
        ComponentName = "Блок питания (PSU)";
        Description = "Устройство, подающее электрическую энергию на все компоненты. Блок питания (БП) — база любой системы. Эта неприметная черная коробочка питает все компоненты компьютера.";
    }
}
