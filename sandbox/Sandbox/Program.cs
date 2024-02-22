using System;

class Program
{
    static void Main(string[] args)
    {
        BaldEagle joey = new BaldEagle("Night Hawk", "KU KAAAA **Fireball Explosions**");
        BaldEagle dragon = new BaldEagle("Dragon", "AMERICAAA **Warthog A10 sounds**");


        joey.MakeSound();
        dragon.MakeSound();
    }
}