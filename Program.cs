

using ScamTroller.Clients;
using ScamTroller.Models;
using ScamTroller.Utils;

PrePostSEOClient identityClient = new PrePostSEOClient();
//https://surprisegifttoday.com/promo/ipad-air/v1
TrollClient trollClient = new TrollClient(new TrollClientArgs("https://www.hottestdealsfortechandgadgets.com/vac-2sv2-2p"));

ConsoleEx.WriteLine($"Targeting {trollClient.BaseUrl}", ConsoleColor.Red);

//var delay = TimeSpan.FromMilliseconds(10);

int count = 2000;
for(int i = 0; i < count; i++)
{

    ConsoleEx.WriteLine($"Iteration {(i + 1)} out of {count}");

    var fakeIdentity = await identityClient.GetFakeIdentity();
    var identity = new Identity(fakeIdentity);

    ConsoleEx.WriteLine($"Using fake identity {identity.FirstName} {identity.LastName}");

    //Console.WriteLine(JsonConvert.SerializeObject(identity, Formatting.Indented));

    ConsoleEx.WriteLine("Posting prospect");
    var postProspectResponse = await trollClient.PostProspect(identity);
    ConsoleEx.WriteLine(postProspectResponse.Status, postProspectResponse.Status == System.Net.HttpStatusCode.OK ? ConsoleColor.Green : ConsoleColor.Red);
    Console.WriteLine(await postProspectResponse.Content.ReadAsStringAsync());

    ConsoleEx.WriteLine("Pause before downsell");
    //Thread.Sleep(25);

    ConsoleEx.WriteLine("Posting downsell");
    var postDownsellResponse = await trollClient.PostDownsell(identity);
    ConsoleEx.WriteLine(postDownsellResponse.Status, postDownsellResponse.Status == System.Net.HttpStatusCode.OK ? ConsoleColor.Green: ConsoleColor.Red);
    ConsoleEx.WriteLine(await postDownsellResponse.Content.ReadAsStringAsync());


    //Console.WriteLine("Sleeping");
    //Thread.Sleep((int)delay.TotalMilliseconds);
    ConsoleEx.WriteLine(new String('-', Console.WindowWidth));
}

