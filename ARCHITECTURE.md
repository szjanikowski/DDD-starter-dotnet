# Diagramy Architektury

Ten plik zawiera instrukcje dotyczące diagramów architektury dla projektu DDD Starter for .NET.

## Plik architecture.dsl

Plik `architecture.dsl` zawiera definicje diagramów architektury w formacie Structurizr DSL. Diagramy te przedstawiają:

1. **Diagram kontekstu** - pokazuje system w kontekście użytkowników i systemów zewnętrznych
2. **Diagram kontenerów** - pokazuje główne kontenery (moduły) systemu
3. **Diagramy komponentów** - pokazują komponenty wewnątrz wybranych modułów

## Jak wygenerować diagramy

Aby wygenerować diagramy z pliku `architecture.dsl`, możesz użyć narzędzia Structurizr CLI:

```bash
# Instalacja Structurizr CLI
npm install -g structurizr-cli

# Generowanie diagramów
structurizr-cli export -workspace architecture.dsl -format png
```

Alternatywnie, możesz użyć [Structurizr Lite](https://github.com/structurizr/lite), który pozwala na wizualizację diagramów w przeglądarce:

```bash
# Uruchomienie Structurizr Lite
docker run -it --rm -p 8080:8080 -v "$PWD:/usr/local/structurizr" structurizr/lite
```

Następnie otwórz przeglądarkę pod adresem `http://localhost:8080` i załaduj plik `architecture.dsl`.

## Struktura diagramów

### Diagram kontekstu

Diagram kontekstu pokazuje system DDD Starter for .NET w kontekście użytkowników i systemów zewnętrznych. Zawiera:

- Użytkowników: Klient hurtowy, Klient online, Administrator
- Systemy zewnętrzne: System płatności, System dostaw, System wyszukiwania
- Relacje między użytkownikami, systemami zewnętrznymi a systemem

### Diagram kontenerów

Diagram kontenerów pokazuje główne moduły systemu:

- Moduł Sales (DeepModel, ProcessModel, Adapters, RestApi, Crud.Contracts, IntegrationTests)
- Moduł Search (Api, Infrastructure)
- Moduł Contacts
- Moduł Payments
- Moduł ProductsDelivery
- Moduł RiskManagement
- Moduł TechnicalStuff (wspólne komponenty techniczne)
- Moduły startupowe (Monolith.Startup, Search.Startup)

### Diagramy komponentów

Diagramy komponentów pokazują wewnętrzną strukturę wybranych modułów:

- **Sales.DeepModel** - komponenty modelu domenowego sprzedaży
- **Sales.ProcessModel** - komponenty modelu procesowego sprzedaży
- **Search.Api** - komponenty API wyszukiwania
- **Search.Infrastructure** - komponenty infrastruktury wyszukiwania
- **TechnicalStuff** - wspólne komponenty techniczne

## Aktualizacja diagramów

Diagramy powinny być aktualizowane przy każdej znaczącej zmianie w architekturze systemu. Aby zaktualizować diagramy:

1. Edytuj plik `architecture.dsl`
2. Wygeneruj diagramy zgodnie z instrukcjami powyżej
3. Zatwierdź zmiany w repozytorium

## Przydatne linki

- [Structurizr DSL](https://github.com/structurizr/dsl)
- [Structurizr CLI](https://github.com/structurizr/cli)
- [Structurizr Lite](https://github.com/structurizr/lite)
- [C4 Model](https://c4model.com/) 