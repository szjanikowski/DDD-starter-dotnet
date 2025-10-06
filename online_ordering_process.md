# Proces Online Ordering

## Diagram przepływu procesu

```mermaid
sequenceDiagram
    participant C as Client
    participant A as API
    participant P as Process
    participant D as Domain
    participant O as Outbox

    Note over C,O: 1. Price Cart
    C->>A: POST /offer-request
    A->>P: PriceCart
    P->>D: calculatePrices
    P->>O: CartPriced
    A-->>C: 200 OK

    Note over C,O: 2. Place Order
    C->>A: POST /orders
    A->>P: PlaceOrder
    P->>D: calculatePrices
    P->>D: ImmediatelyPlacedBasedOn
    P->>D: Save order
    P->>O: OrderPlaced
    A-->>C: 201 Created

    Note over C,O: 3. Get Details
    C->>A: GET /orders/{id}
    A->>P: GetOrderDetails
    P->>D: GetBy
    A-->>C: 200 OK
```

## Funkcjonalności Online Ordering

### Główne cechy:
- **Proces jednokrokowy** - zamówienie składane od razu
- **Natychmiastowa wycena** - ceny obliczane w czasie rzeczywistym
- **Walidacja płatności** - sprawdzenie metod płatności
- **Adres dostawy** - weryfikacja adresu dostawy
- **Potwierdzenie zamówienia** - automatyczne generowanie potwierdzenia

### Endpointy API:
1. `POST /rest/online-ordering/offer-request` - Wycena koszyka
2. `POST /rest/online-ordering/orders` - Złożenie zamówienia
3. `GET /rest/online-ordering/orders/{id}` - Pobieranie szczegółów zamówienia

### Kolejność wywołań:
1. **Price Cart** → Wycena produktów w koszyku (opcjonalne)
2. **Place Order** → Bezpośrednie złożenie zamówienia z produktami
3. **Get Order Details** → Pobieranie szczegółów zamówienia

### Różnice w stosunku do Wholesale:
- **Brak etapu potwierdzenia oferty** - cena jest finalna
- **Brak możliwości modyfikacji** - zamówienie składane od razu
- **Prostszy przepływ** - mniej kroków w procesie
- **Natychmiastowa realizacja** - zamówienie trafia od razu do realizacji
