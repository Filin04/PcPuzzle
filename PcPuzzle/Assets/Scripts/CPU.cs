public class CPU : ComputerComponent
{
    public CPU()
    {
        Component = EComponent.CPU;
        ComponentName = "Процессор (CPU)";
        Description = "Процессор обрабатывает весь код операционной системы и взаимодействует с остальными компонентами. Многие процессоры оснащаются еще и встроенным графическим чипом.";
    }
}
