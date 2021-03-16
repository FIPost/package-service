# ipost-pakketservice

## Wat is dit?
Pakket service voor de IPost applicatie om pakketjes te registreren en op te halen.

## Gerelateerde projecten
- [ipost-userservice](https://git.fhict.nl/I418126/ipost-userservice) - Authenticatie voor Fontys medewerkers.
- [ipost-personeelsservice](https://git.fhict.nl/I418126/ipost-personeelsservice) - Email-adressen en namen van Fontys accounts.
- [ipost-locatieservice](https://git.fhict.nl/I418126/ipost-locatieservice) - Fontys afhaalpunten voor post.
- [ipost-ui](https://git.fhict.nl/I418126/ipost-ui) - Front-end voor het logistieke proces.
- [ipost-track-and-trace-ui)](https://git.fhict.nl/I418126/ipost-track-and-trace-ui) - Front-end voor Track & Trace ontvanger.

## Getting started
Het project werkt met docker-compose. Controleer vooraf of Docker correct geïnstalleerd is.
Volg deze stappen om het project te runnen:

(Stap 1 tot 5 hoeven alleen de eerste keer.)
1. Navigeer naar het projectpad in je terminal (het pad waar docker-compose.yml in staat).
2. Voer het volgende command uit om de container te starten:
    `docker-compose up`
3. Controleer of de container actief is in Docker Desktop of door het volgende command uit te voeren:
    `docker ps`
4. Open het project in Visual Studio en open de Package Manager Console via Tools > NuGet Package Manager > Package Manager Console
5. Voer het volgende command uit om de database in te stellen:
    `update-database`
6. Het project is nu klaar om te starten met IIExpress.
