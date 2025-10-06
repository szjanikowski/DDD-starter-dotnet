workspace {
    model {
        # Definicje osób
        wholesaleClient = person "Klient hurtowy" "Klient korzystający z systemu w trybie hurtowym"
        onlineClient = person "Klient online" "Klient korzystający z systemu w trybie online"
        
        # Definicja głównego systemu
        dddStarter = softwareSystem "DDD Starter for .NET" "System DDD Starter for .NET" {
            # Definicje kontenerów (jednostek wdrożeniowych)
            ecommerceMonolith = container "E-commerce Monolith" "Aplikacja monolityczna e-commerce" "ASP.NET Core Web Application" {
                # Komponenty modułu sprzedaży
                sales = component "Sales" "Moduł sprzedaży"
                orderFactory = component "OrderFactory" "Fabryka zamówień"
                orderRepository = component "OrderRepository" "Repozytorium zamówień"
                orderService = component "OrderService" "Serwis zamówień"
                orderHandler = component "OrderHandler" "Handler zamówień"
                salesInfrastructure = component "Sales.Infrastructure" "Infrastruktura modułu sprzedaży"
                
                # Komponenty modułu kontaktów
                contacts = component "Contacts" "Moduł kontaktów"
                contactFactory = component "ContactFactory" "Fabryka kontaktów"
                contactRepository = component "ContactRepository" "Repozytorium kontaktów"
                contactService = component "ContactService" "Serwis kontaktów"
                contactHandler = component "ContactHandler" "Handler kontaktów"
                contactsInfrastructure = component "Contacts.Infrastructure" "Infrastruktura modułu kontaktów"
                
                # Komponenty modułu płatności
                payments = component "Payments" "Moduł płatności"
                paymentFactory = component "PaymentFactory" "Fabryka płatności"
                paymentRepository = component "PaymentRepository" "Repozytorium płatności"
                paymentService = component "PaymentService" "Serwis płatności"
                paymentHandler = component "PaymentHandler" "Handler płatności"
                paymentsInfrastructure = component "Payments.Infrastructure" "Infrastruktura modułu płatności"
                
                # Komponenty modułu dostaw
                productsDelivery = component "ProductsDelivery" "Moduł dostaw produktów"
                deliveryFactory = component "DeliveryFactory" "Fabryka dostaw"
                deliveryRepository = component "DeliveryRepository" "Repozytorium dostaw"
                deliveryService = component "DeliveryService" "Serwis dostaw"
                deliveryHandler = component "DeliveryHandler" "Handler dostaw"
                deliveryInfrastructure = component "Delivery.Infrastructure" "Infrastruktura modułu dostaw"
                
                # Komponenty modułu zarządzania ryzykiem
                riskManagement = component "RiskManagement" "Moduł zarządzania ryzykiem"
                riskFactory = component "RiskFactory" "Fabryka oceny ryzyka"
                riskRepository = component "RiskRepository" "Repozytorium oceny ryzyka"
                riskService = component "RiskService" "Serwis oceny ryzyka"
                riskHandler = component "RiskHandler" "Handler oceny ryzyka"
                riskInfrastructure = component "Risk.Infrastructure" "Infrastruktura modułu ryzyka"
                
                # Wspólne komponenty techniczne
                monolithTechnicalStuff = component "TechnicalStuff" "Wspólne komponenty techniczne"
                logging = component "Logging" "Komponent logowania"
                monitoring = component "Monitoring" "Komponent monitoringu"
                security = component "Security" "Komponent bezpieczeństwa"
                caching = component "Caching" "Komponent cachowania"
            }
            
            # Kontener wyszukiwarki
            ecommerceSearch = container "E-commerce Search" "Aplikacja wyszukiwania produktów" "ASP.NET Core Web Application" {
                # Komponenty wyszukiwarki
                searchApi = component "Search.Api" "API wyszukiwania"
                searchFactory = component "SearchFactory" "Fabryka wyszukiwania"
                searchRepository = component "SearchRepository" "Repozytorium wyszukiwania"
                searchService = component "SearchService" "Serwis wyszukiwania"
                searchHandler = component "SearchHandler" "Handler wyszukiwania"
                
                searchInfrastructure = component "Search.Infrastructure" "Infrastruktura wyszukiwania"
                elasticsearch = component "Elasticsearch" "Integracja z Elasticsearch"
                indexing = component "Indexing" "Komponent indeksowania"
                searchCache = component "SearchCache" "Cache wyszukiwania"
                
                searchTechnicalStuff = component "TechnicalStuff" "Wspólne komponenty techniczne"
                searchLogging = component "SearchLogging" "Komponent logowania"
                searchMonitoring = component "SearchMonitoring" "Komponent monitoringu"
                searchSecurity = component "SearchSecurity" "Komponent bezpieczeństwa"
            }
        }
        
        # Relacje między osobami a systemem
        wholesaleClient -> dddStarter "Przegląda i składa zamówienia"
        onlineClient -> dddStarter "Przegląda produkty i składa zamówienia"
        
        # Relacje między komponentami w monolicie
        orderService -> paymentService "Używa"
        orderService -> deliveryService "Używa"
        orderService -> riskService "Używa"
        orderService -> logging "Używa"
        orderService -> monitoring "Używa"
        
        contactService -> logging "Używa"
        contactService -> monitoring "Używa"
        
        paymentService -> logging "Używa"
        paymentService -> monitoring "Używa"
        paymentService -> security "Używa"
        
        deliveryService -> logging "Używa"
        deliveryService -> monitoring "Używa"
        
        riskService -> logging "Używa"
        riskService -> monitoring "Używa"
        
        # Relacje między komponentami w wyszukiwarce
        searchService -> elasticsearch "Używa"
        searchService -> indexing "Używa"
        searchService -> searchCache "Używa"
        searchService -> searchLogging "Używa"
        searchService -> searchMonitoring "Używa"
        
        indexing -> searchLogging "Używa"
        indexing -> searchMonitoring "Używa"
    }
    
    views {
        # Definicje stylów
        styles {
            element "Person" {
                shape Person
                background #08427b
            }
            element "Software System" {
                background #1168bd
            }
            element "Container" {
                background #91a4be
            }
            element "Component" {
                background #85c5dc
            }
            element "Database" {
                shape Cylinder
                background #f5da81
            }
            element "Queue" {
                shape Pipe
                background #f5da81
            }
        }
        
        # Diagram kontekstu
        systemContext dddStarter "SystemContext" {
            include *
            autoLayout
        }
        
        # Diagram kontenerów
        container dddStarter "Containers" {
            include *
            autoLayout
        }
        
        # Diagram komponentów dla monolitu e-commerce
        component ecommerceMonolith "EcommerceMonolithComponents" {
            include *
            autoLayout
        }
        
        # Diagram komponentów dla wyszukiwarki e-commerce
        component ecommerceSearch "EcommerceSearchComponents" {
            include *
            autoLayout
        }
        
        theme default
    }
}