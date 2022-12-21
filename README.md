# christmas-architecture
Et enkelt eksempel på Clean Architecture ifm julekalenderen til Bekk på [lille julaften](https://www.bekk.christmas/post/2022/23/hva-er-clean-architecture).

Strukturen i repoet er inspirert av Clean Architecture fra: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

I src-mappen vil du finne:
1. **Domain**  
   Domeneobjekter; det innerste delen av arkitekturen og skal derfor ikke referere til noe annet lag.
2. **Application**  
   Applikasjonslogikk, query og command handlere; kan bare referere til **Domain**
3. **Infrastructure**  
   Repsitory; kan referere til **Application** og **Domain**. 
4. **Web**  
   Controllere, dependency injection setup ++ ; er ytterst og kan dermed kjenne til alle lag.

   ## Forutsetninger

- .NET 6.0 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Editor (Visual studio code, Visual Studio, Rider)

## Kjøre applikasjonen

- Åpne en terminal der .NET CLI er tilgjengelig
- Navigèr til `src\Web` og skriv `dotnet run` etterfulgt av enter: