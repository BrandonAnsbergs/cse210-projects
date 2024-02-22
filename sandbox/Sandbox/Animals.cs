using System.Reflection.Metadata;

public abstract class Animal{

    public string name;

    public string sound;

    protected Animal(string name, string sound) {
        this.name = name;
    }
    public virtual void MakeSound(){
        Console.WriteLine("**Ominous Silince**");
    }
}