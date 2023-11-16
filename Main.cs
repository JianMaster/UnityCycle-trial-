using System;
using Client;
using Client.Scripts;
public class Entry
{
    public static void Main(string[] command)
    {
        Client.Client client = new Client.Client(10);
        GameObject gameObject = new GameObject();
        // gameObject.AddComponent<GameMain>();
        client.StartGame();
    }
}