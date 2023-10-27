using ClientComponent;

namespace ClientService;

public static class Program
{
    private static readonly IClientComponent<string, string> ClientComponent =
        new ClientComponent<string, string>("http://172.28.28.117:8001");

    public static async Task Main(string[] args)
    {
        if (args.Length.Equals(0)) throw new Exception();

        ClientComponent.KeyValuePair<string, string>? pair;
        switch (args[0])
        {
            case "get":
                pair = await ClientComponent.Get(args[1]);
                Console.WriteLine(pair?.Value);
                break;
            case "set":
                pair = await ClientComponent.Set(args[1], args[2]);
                Console.WriteLine("Set pair:");
                Console.WriteLine($"key = {pair?.Key}");
                Console.WriteLine($"value = {pair?.Value}");
                break;
            default:
                throw new Exception();
        }
    }
}