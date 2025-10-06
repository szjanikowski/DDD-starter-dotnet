workspace {
    model {
        # Definicje osób
        wholesaleClient = person "Klient hurtowy" "Klient korzystający z systemu w trybie hurtowym"
        onlineClient = person "Klient online" "Klient korzystający z systemu w trybie online"
        
        
        # Definicja głównego systemu
        dddStarter = softwareSystem "DDD Starter for .NET" "System DDD Starter for .NET" {
            # Definicje kontenerów (jednostek wdrożeniowych)
            ecommerceMonolith = container "E-commerce Monolith" "Aplikacja monolityczna e-commerce" "ASP.NET Core Web Application" {
                # Komponenty reprezentujące główne przestrzenie nazw
                sales = component "Sales" "Moduł sprzedaży"
                contacts = component "Contacts" "Moduł kontaktów"
                payments = component "Payments" "Moduł płatności"
                productsDelivery = component "ProductsDelivery" "Moduł dostaw produktów"
                riskManagement = component "RiskManagement" "Moduł zarządzania ryzykiem"
                monolithTechnicalStuff = component "TechnicalStuff" "Wspólne komponenty techniczne"
            }
            
            ecommerceSearch = container "E-commerce Search" "Aplikacja wyszukiwania produktów" "ASP.NET Core Web Application" {
                # Komponenty reprezentujące główne przestrzenie nazw
                searchApi = component "Search.Api" "API wyszukiwania"
                searchInfrastructure = component "Search.Infrastructure" "Infrastruktura wyszukiwania"
                searchTechnicalStuff = component "TechnicalStuff" "Wspólne komponenty techniczne"
            }
        }
        
        # Relacje między osobami a systemem
        wholesaleClient -> dddStarter "Przegląda i składa zamówienia"
        onlineClient -> dddStarter "Przegląda produkty i składa zamówienia"

        
        # Relacje między komponentami w monolicie
        sales -> payments "Używa"
        sales -> productsDelivery "Używa"
        sales -> riskManagement "Używa"
        sales -> monolithTechnicalStuff "Używa"
        contacts -> monolithTechnicalStuff "Używa"
        payments -> monolithTechnicalStuff "Używa"
        productsDelivery -> monolithTechnicalStuff "Używa"
        riskManagement -> monolithTechnicalStuff "Używa"
        
        # Relacje między komponentami w wyszukiwarce
        searchApi -> searchInfrastructure "Używa"
        searchApi -> searchTechnicalStuff "Używa"
        searchInfrastructure -> searchTechnicalStuff "Używa"
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