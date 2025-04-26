# Plan Onboardingu dla Nowych Developerów

## 1. Kluczowe Komponenty i Moduły

Projekt jest podzielony na następujące główne moduły:

- **Sales** - moduł obsługujący procesy sprzedażowe
- **Search** - wyszukiwarka produktów
- **RiskManagement** - zarządzanie ryzykiem
- **ProductsDelivery** - dostawy produktów
- **Payments** - obsługa płatności
- **Contacts** - zarządzanie kontaktami
- **TechnicalStuff** - wspólne komponenty techniczne

## 2. Kolejność Zapoznawania się z Modułami

1. **TechnicalStuff** - podstawowe komponenty techniczne
2. **Sales** - główny moduł biznesowy
3. **Search** - integracja z wyszukiwarką
4. Pozostałe moduły w zależności od przypisanych zadań

## 3. Aktywni Kontrybutorzy

Główne osoby do kontaktu:
- Marcin Markowski - główny maintainer
- Khanbala Rashidov - aktywny kontrybutor
- technites-pl - zespół dokumentacji

## 4. Dobre Praktyki i Wzorce

### Dobre Praktyki
- Używanie nowych funkcji C# (primary constructors)
- Regularne aktualizacje pakietów
- Czytelne nazwy commitów
- Usuwanie nieużywanych importów

### Antywzorce
- Unikać zbędnych adnotacji NotNull
- Unikać zbędnych katalogów Properties

## 5. Plan Onboardingu

### Tydzień 1: Poznanie Repozytorium

#### Dzień 1-2: Konfiguracja Środowiska
- [ ] Sklonowanie repozytorium
- [ ] Konfiguracja .NET 8
- [ ] Uruchomienie projektu lokalnie
- [ ] Zapoznanie się z [README.md](README.md)

#### Dzień 3-4: Dokumentacja i Architektura
- [ ] Przeczytanie [DomainVisionStatement.md](Sources/DomainVisionStatement.md)
- [ ] Analiza [Projects-and-Namespaces.md](Projects-and-Namespaces.md)
- [ ] Zapoznanie się z dokumentacją w katalogu [Docs/](Docs/)

#### Dzień 5: Analiza Kodu
- [ ] Przegląd struktury modułów w [Sources/](Sources/)
- [ ] Analiza wybranych commitów z historii
- [ ] Zapoznanie się z procesem CI/CD w [.github/](.github/)

### Tydzień 2: Pierwsze Zadania

#### Dzień 1-2: Proste Zmiany
- [ ] Utworzenie brancha feature
- [ ] Wprowadzenie prostych zmian (np. aktualizacja dokumentacji)
- [ ] Utworzenie pierwszego Pull Request

#### Dzień 3-5: Code Review
- [ ] Przeglądanie aktywnych Pull Requestów
- [ ] Nauka procesu code review
- [ ] Zapoznanie się z wymaganiami jakości kodu

### Tydzień 3+: Rozwój

- [ ] Przypisanie do pierwszego feature'a
- [ ] Regularne code review
- [ ] Aktywny udział w spotkaniach zespołowych

## 6. Przydatne Linki

- [README.md](README.md) - główna dokumentacja projektu
- [Projects-and-Namespaces.md](Projects-and-Namespaces.md) - struktura projektu
- [DomainVisionStatement.md](Sources/DomainVisionStatement.md) - wizja domenowa
- [Docs/](Docs/) - dodatkowa dokumentacja

## 7. Wsparcie

W razie pytań lub problemów:
1. Sprawdź dokumentację w repozytorium
2. Skontaktuj się z Marcinem Markowskim (główny maintainer)
3. Dołącz do kanału #ddd-starter-dotnet na Slacku 