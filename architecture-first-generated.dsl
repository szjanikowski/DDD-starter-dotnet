workspace {
    model {
        # Definicje osób
        wholesaleClient = person "Klient hurtowy" "Klient korzystający z systemu w trybie hurtowym"
        onlineClient = person "Klient online" "Klient korzystający z systemu w trybie online"
        administrator = person "Administrator" "Administrator systemu"
        
        # Definicje systemów zewnętrznych
        paymentsSystem = softwareSystem "System płatności" "Zewnętrzny system obsługi płatności"
        deliverySystem = softwareSystem "System dostaw" "Zewnętrzny system zarządzania dostawami"
        searchSystem = softwareSystem "System wyszukiwania" "Zewnętrzny system wyszukiwania produktów"
        
        # Definicja głównego systemu
        dddStarter = softwareSystem "DDD Starter for .NET" "System DDD Starter for .NET" {
            # Definicje kontenerów
            monolith = container "Monolith" "Aplikacja monolityczna" "C# Application"
            
            # Moduł Sales
            salesDeepModel = container "Sales.DeepModel" "Model domenowy sprzedaży" "C# Class Library" {
                orders = component "Orders" "Komponenty zamówień"
                products = component "Products" "Komponenty produktów"
                pricing = component "Pricing" "Komponenty wyceny"
                clients = component "Clients" "Komponenty klientów"
                commons = component "Commons" "Komponenty wspólne"
                exchangeRates = component "ExchangeRates" "Komponenty kursów walut"
            }
            salesProcessModel = container "Sales.ProcessModel" "Model procesowy sprzedaży" "C# Class Library" {
                onlineOrdering = component "OnlineOrdering" "Proces zamawiania online"
                wholesaleOrdering = component "WholesaleOrdering" "Proces zamawiania hurtowego"
                fulfillment = component "Fulfillment" "Proces realizacji zamówień"
                orderEventsOutbox = component "OrderEventsOutbox" "Outbox zdarzeń zamówień"
                salesCrudOperations = component "SalesCrudOperations" "Operacje CRUD dla sprzedaży"
            }
            salesAdapters = container "Sales.Adapters" "Adaptery dla modułu sprzedaży" "C# Class Library"
            salesRestApi = container "Sales.RestApi" "API REST dla modułu sprzedaży" "ASP.NET Core Web API"
            salesCrudContracts = container "Sales.Crud.Contracts" "Kontrakty CRUD dla modułu sprzedaży" "C# Class Library"
            salesIntegrationTests = container "Sales.IntegrationTests" "Testy integracyjne dla modułu sprzedaży" "C# Test Project"
            
            # Moduł Search
            searchApi = container "Search.Api" "API wyszukiwania" "C# Class Library" {
                searchApiProducts = component "Search.Api.Products" "API wyszukiwania produktów"
            }
            
            searchInfrastructure = container "Search.Infrastructure" "Infrastruktura wyszukiwania" "C# Class Library" {
                searchInfraProducts = component "Search.Infrastructure.Products" "Implementacja wyszukiwania produktów"
                searchInfraDb = component "Search.Infrastructure.SearchDb" "Baza danych wyszukiwania"
            }
            
            # Moduł Contacts
            contacts = container "Contacts" "Moduł kontaktów" "C# Class Library"
            
            # Moduł Payments
            payments = container "Payments" "Moduł płatności" "C# Class Library"
            
            # Moduł ProductsDelivery
            productsDelivery = container "ProductsDelivery" "Moduł dostaw produktów" "C# Class Library"
            
            # Moduł RiskManagement
            riskManagement = container "RiskManagement" "Moduł zarządzania ryzykiem" "C# Class Library"
            
            # Moduł TechnicalStuff
            technicalStuff = container "TechnicalStuff" "Wspólne komponenty techniczne" "C# Class Library" {
                api = component "Api" "Komponenty API"
                crud = component "Crud" "Komponenty CRUD"
                ef = component "Ef" "Komponenty Entity Framework"
                json = component "Json" "Komponenty JSON"
                kafka = component "Kafka" "Komponenty Kafka"
                marten = component "Marten" "Komponenty Marten"
                outbox = component "Outbox" "Komponenty Outbox"
                persistence = component "Persistence" "Komponenty persystencji"
                postgres = component "Postgres" "Komponenty PostgreSQL"
                processModel = component "ProcessModel" "Komponenty modelu procesowego"
                transactions = component "Transactions" "Komponenty transakcji"
            }
            technicalStuffApi = container "TechnicalStuff.Api" "API dla wspólnych komponentów" "C# Class Library"
            technicalStuffCrud = container "TechnicalStuff.Crud" "Komponenty CRUD" "C# Class Library"
            technicalStuffCrudApi = container "TechnicalStuff.Crud.Api" "API dla komponentów CRUD" "C# Class Library"
            technicalStuffCrudEf = container "TechnicalStuff.Crud.Ef" "Implementacja CRUD z Entity Framework" "C# Class Library"
            technicalStuffEf = container "TechnicalStuff.Ef" "Komponenty Entity Framework" "C# Class Library"
            technicalStuffJson = container "TechnicalStuff.Json" "Komponenty JSON" "C# Class Library"
            technicalStuffKafka = container "TechnicalStuff.Kafka" "Integracja z Kafka" "C# Class Library"
            technicalStuffMarten = container "TechnicalStuff.Marten" "Integracja z Marten" "C# Class Library"
            technicalStuffOutbox = container "TechnicalStuff.Outbox" "Wzorzec Outbox" "C# Class Library"
            technicalStuffOutboxKafka = container "TechnicalStuff.Outbox.Kafka" "Implementacja Outbox z Kafka" "C# Class Library"
            technicalStuffOutboxPostgres = container "TechnicalStuff.Outbox.Postgres" "Implementacja Outbox z PostgreSQL" "C# Class Library"
            technicalStuffOutboxQuartz = container "TechnicalStuff.Outbox.Quartz" "Integracja Outbox z Quartz" "C# Class Library"
            technicalStuffPersistence = container "TechnicalStuff.Persistence" "Komponenty persystencji" "C# Class Library"
            technicalStuffPersistenceRepoDb = container "TechnicalStuff.Persistence.RepoDb" "Implementacja persystencji z RepoDb" "C# Class Library"
            technicalStuffPostgres = container "TechnicalStuff.Postgres" "Integracja z PostgreSQL" "C# Class Library"
            technicalStuffProcessModel = container "TechnicalStuff.ProcessModel" "Model procesowy dla komponentów technicznych" "C# Class Library"
            technicalStuffTransactions = container "TechnicalStuff.Transactions" "Komponenty transakcji" "C# Class Library"
            
            # Moduły startupowe
            monolithStartup = container "Monolith.Startup" "Konfiguracja startupowa dla monolitu" "C# Class Library"
            searchStartup = container "Search.Startup" "Konfiguracja startupowa dla wyszukiwarki" "C# Class Library"
        }
        
        # Relacje między osobami a systemem
        wholesaleClient -> dddStarter "Przegląda i składa zamówienia"
        onlineClient -> dddStarter "Przegląda produkty i składa zamówienia"
        administrator -> dddStarter "Zarządza systemem"
        
        # Relacje między systemami
        dddStarter -> paymentsSystem "Przetwarza płatności"
        dddStarter -> deliverySystem "Zarządza dostawami"
        dddStarter -> searchSystem "Wyszukuje produkty"
        
        # Relacje między kontenerami
        salesRestApi -> salesProcessModel "Używa"
        salesProcessModel -> salesDeepModel "Używa"
        salesProcessModel -> salesCrudContracts "Używa"
        salesAdapters -> salesDeepModel "Implementuje"
        salesAdapters -> technicalStuff "Używa"
        
        searchApi -> searchInfrastructure "Używa"
        
        monolithStartup -> salesRestApi "Konfiguruje"
        monolithStartup -> searchApi "Konfiguruje"
        monolithStartup -> technicalStuff "Konfiguruje"
        
        searchStartup -> searchApi "Konfiguruje"
        searchStartup -> searchInfrastructure "Konfiguruje"
        searchStartup -> technicalStuff "Konfiguruje"
        
        # Relacje między komponentami Sales.DeepModel
        orders -> products "Używa"
        orders -> pricing "Używa"
        orders -> clients "Używa"
        orders -> commons "Używa"
        products -> commons "Używa"
        pricing -> commons "Używa"
        pricing -> exchangeRates "Używa"
        clients -> commons "Używa"
        
        # Relacje między komponentami Sales.ProcessModel
        onlineOrdering -> orders "Używa"
        onlineOrdering -> products "Używa"
        onlineOrdering -> pricing "Używa"
        wholesaleOrdering -> orders "Używa"
        wholesaleOrdering -> products "Używa"
        wholesaleOrdering -> pricing "Używa"
        fulfillment -> orders "Używa"
        orderEventsOutbox -> orders "Używa"
        salesCrudOperations -> orders "Używa"
        
        # Relacje między komponentami Search
        searchApiProducts -> searchInfraProducts "Używa"
        searchInfraProducts -> searchInfraDb "Używa"
        
        # Relacje między komponentami TechnicalStuff
        crud -> api "Używa"
        ef -> crud "Implementuje"
        json -> api "Używa"
        kafka -> api "Używa"
        marten -> persistence "Implementuje"
        outbox -> api "Używa"
        persistence -> api "Używa"
        postgres -> persistence "Implementuje"
        processModel -> api "Używa"
        transactions -> api "Używa"
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
        
        # Diagram komponentów dla modułu Sales.DeepModel
        component salesDeepModel "SalesDeepModelComponents" {
            include *
            autoLayout
        }
        
        # Diagram komponentów dla modułu Sales.ProcessModel
        component salesProcessModel "SalesProcessModelComponents" {
            include *
            autoLayout
        }
        
        # Diagram komponentów dla modułu Search.Api
        component searchApi "SearchApiComponents" {
            include *
            autoLayout
        }
        
        # Diagram komponentów dla modułu Search.Infrastructure
        component searchInfrastructure "SearchInfrastructureComponents" {
            include *
            autoLayout
        }
        
        # Diagram komponentów dla modułu TechnicalStuff
        component technicalStuff "TechnicalStuffComponents" {
            include *
            autoLayout
        }
        
        theme default
    }
} 