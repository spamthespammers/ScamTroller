
using ScamTroller.Clients;
using ScamTroller.Models;
using ScamTroller.Utils;



int numIdentities = 10000;
CreditCardGenerator.Cook(numIdentities);


//https://surprisegifttoday.com/promo/ipad-air/v1

string target = "https://www.hottestdealsfortechandgadgets.com/vac-2sv2-2p";

target = "";

TrollClient trollClient = new TrollClient(new TrollClientArgs(target));

ConsoleEx.WriteLine($"Targeting {trollClient.BaseUrl}", ConsoleColor.Red);


for(int i = 0; i < numIdentities; i++)
{

    ConsoleEx.WriteLine($"Iteration {(i + 1)} out of {numIdentities}");

    var identity = Identity.Fabricate();

    ConsoleEx.WriteLine($"Using fake identity {identity.FirstName} {identity.LastName} ({identity.CreditCardNumber})");


    ConsoleEx.WriteLine("Posting prospect");
    var postProspectResponse = await trollClient.PostProspect(identity);
    ConsoleEx.WriteLine(postProspectResponse.Status, postProspectResponse.Status == System.Net.HttpStatusCode.OK ? ConsoleColor.Green : ConsoleColor.Red);
    Console.WriteLine(await postProspectResponse.Content.ReadAsStringAsync());

    ConsoleEx.WriteLine("Pause before downsell");

    ConsoleEx.WriteLine("Posting downsell");
    var postDownsellResponse = await trollClient.PostDownsell(identity);
    ConsoleEx.WriteLine(postDownsellResponse.Status, postDownsellResponse.Status == System.Net.HttpStatusCode.OK ? ConsoleColor.Green: ConsoleColor.Red);
    ConsoleEx.WriteLine(await postDownsellResponse.Content.ReadAsStringAsync());


    ConsoleEx.WriteLine(new String('-', Console.WindowWidth));
}

