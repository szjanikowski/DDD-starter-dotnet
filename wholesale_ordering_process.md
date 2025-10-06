# Proces Wholesale Ordering

## Diagram przepływu procesu

```mermaid
sequenceDiagram
    participant C as Client
    participant A as API
    participant P as Process
    participant D as Domain
    participant O as Outbox

    Note over C,O: 1. Create Order
    C->>A: POST /orders
    A->>P: CreateOrder
    P->>D: NewWithMaxTotalCostFor
    P->>D: Save order
    P->>O: OrderCreated
    A-->>C: 201 Created

    Note over C,O: 2. Add Products
    C->>A: PUT /orders/{id}/items
    A->>P: AddToOrder
    P->>D: AddProduct
    P->>O: AddedToOrder
    A-->>C: 204 No Content

    Note over C,O: 3. Get Offer
    C->>A: GET /orders/{id}/current-offer
    A->>P: GetOffer
    P->>D: calculatePrices
    P->>O: OfferCalculated
    A-->>C: 200 OK

    Note over C,O: 4. Confirm Offer
    C->>A: PUT /orders/{id}/confirmed-offer
    A->>P: ConfirmOffer
    P->>D: ConfirmOffer
    P->>O: OfferConfirmed
    A-->>C: 204 No Content

    Note over C,O: 5. Place Order
    C->>A: PUT /orders/{id}/placement
    A->>P: PlaceOrder
    P->>D: Place
    P->>O: OrderPlaced
    A-->>C: 204 No Content
```

## Funkcjonalności Wholesale Ordering

### Główne cechy:
- **Proces wieloetapowy** - zamówienie przechodzi przez kilka etapów
- **Walidacja biznesowa** - minimum 5 produktów w zamówieniu hurtowym
- **Weryfikacja kredytu** - sprawdzenie zdolności kredytowej klienta
- **Umowy handlowe** - generowanie dokumentów umownych
- **Warunki dostawy** - specjalne warunki dla klientów hurtowych

### Endpointy API:
1. `POST /rest/wholesale-ordering/orders` - Tworzenie zamówienia
2. `GET /rest/wholesale-ordering/orders/{id}` - Pobieranie szczegółów zamówienia
3. `PUT /rest/wholesale-ordering/orders/{id}/items` - Dodawanie produktów
4. `GET /rest/wholesale-ordering/orders/{id}/current-offer` - Pobieranie aktualnej oferty
5. `PUT /rest/wholesale-ordering/orders/{id}/confirmed-offer` - Potwierdzenie oferty
6. `PUT /rest/wholesale-ordering/orders/{id}/placement` - Złożenie zamówienia
7. `GET /rest/wholesale-ordering/quotes` - Szybka wycena produktu

### Kolejność wywołań:
1. **Create Order** → Tworzenie pustego zamówienia
2. **Add Products** → Dodawanie produktów (można wielokrotnie)
3. **Get Offer** → Pobieranie wyceny
4. **Confirm Offer** → Potwierdzenie ceny
5. **Place Order** → Finalne złożenie zamówienia
