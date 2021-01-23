# Charlotte Magnusson

Har brutit ut all business logic till en egen klass och delat upp metoderna enligt Single responsibility principles. Detta gör dessutom klasserna mindre i storlek och det blir mer lättläsligt. Källhänvisning: Clean Code s.138

Gjorde ett test på sorteringen som inte har några sidoeffekter. Hade det varit en metod med sidoeffekter, som t.ex. något som gör en förändring på en databas, så hade det krävts extra implementationer, som att koppla bort beroenden via mocking, för att testa den sanna logiken funktionen utför. Annars vet vi inte om vårt test misslyckas på grund av att något annat den är beroende på inte fungerar korrekt. Källhänvisning: https://www.toptal.com/qa/how-to-write-testable-code-and-why-it-matters och det som har tagits upp under lektionerna.

"Adapter is a structural design pattern that allows objects with incompatible interfaces to collaborate." Som de olika Json formaten på filmerna. De går inte att deserialisera ner till ett objekt av samma klass och därför har jag gjort två olika klasser: Movie och DetailedMovie. Eftersom att vi vill kunna använda dom på samma sätt så har jag byggt en adapter klass som konverterar DetailedMovie till Movie. Källhänvisning: https://refactoring.guru/design-patterns/adapter
