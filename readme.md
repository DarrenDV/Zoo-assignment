# Zoo assignment

## Aanpak
Voor deze assignment besloot ik gebruik te maken van scriptable objects. Dit deed ik om het makkelijker te maken voor nieuwe personen om extra dieren toe te voegen. Ieder dier is een scriptable object dat een aantal variabelen bevat. Deze variabelen zijn:
- Naam
- Soort (Carnivoor, Herbivoor, Omnivoor)
- Afbeelding
- Hallo text
- Eet text
- Kan een trucje doen (true/false)

Deze scriptable objects worden uit de folder in runtime geladen zonder dat dit handmatig geassigned hoeft te worden. Verder maak ik gebruik van events om de dieren hun textbollen te activeren of een trucje te laten doen. Deze events zitten gekoppeld aan de buttons in de UI.
<br>
Een compromis die ik heb genomen voor schoonheid van code is het samenvoegen van beide etensfuncties in 1. Dit zorgt ervoor dat een herbivoor geen eatmeat functie kan hebben. Het enige nadeel is dat de tekst bij omnivoren hetzelfde is voor zowel leaves als meat.
<br>
Een mogelijke oplossing hiervoor is om component based te gaan waarbij er een carnivoor en herbivoor script zou zijn en deze toegevoegd zouden worden per dier adv hun dieet. Voor de schaal van dit project vond ik dat alleen niet nodig.
