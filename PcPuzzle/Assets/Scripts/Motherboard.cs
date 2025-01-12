public class Motherboard : ComputerComponent
{
    public Motherboard()
    {
        Component = EComponent.Motherboard;
        ComponentName = "Материнская плата";
        Description = "Это главный узел компьютера, все прочие компоненты подключаются именно к ней. Она плоская, но по длине и ширине занимает много места, а потому обычно крепится параллельно одной из стенок корпуса.";
    }
}
