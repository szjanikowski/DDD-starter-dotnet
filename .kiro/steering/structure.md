# Project Structure & Organization

## Solution Organization

The solution follows **Screaming Architecture** principles where the structure reflects business domains and architectural choices.

### Top-Level Structure

```
Sources/                    # All source code
├── [BoundedContext]/      # One folder per bounded context
├── TechnicalStuff/        # Shared technical infrastructure
├── Monolith.Startup/      # Main application startup
└── Search.Startup/        # Search service startup

Build/                     # Build automation (NUKE)
Docs/                      # Documentation and architecture diagrams
```

## Bounded Context Structure

Each bounded context follows a layered architecture pattern:

```
[BoundedContext]/
├── [Context].DeepModel/           # Domain layer (rich domain model)
├── [Context].ProcessModel/        # Application/Process layer
├── [Context].Adapters/           # Infrastructure adapters
├── [Context].RestApi/            # REST API controllers
├── [Context].Adapters.Api/       # API adapters (hexagonal ports)
├── [Context].Adapters.Out/       # Outbound adapters
├── [Context].DeepModel.Tests/    # Domain model tests
├── [Context].ProcessModel.Tests/ # Process model tests
└── [Context].IntegrationTests/   # Integration tests
```

## Naming Conventions

### Projects and Assemblies
- **Project Name**: Start with bounded context name (e.g., `Sales.DeepModel`)
- **Assembly Name**: Include company prefix (e.g., `MyCompany.ECommerce.Sales.DeepModel.dll`)
- **Root Namespace**: Company + bounded context (e.g., `MyCompany.ECommerce.Sales`)

### Namespaces
- **Business-focused**: Reflect domain concepts, not technical layers
- **Hierarchical**: Follow business module divisions
- **No technical suffixes**: Avoid `.Domain`, `.Infrastructure` in namespaces (already in project names)
- **Example**: `MyCompany.ECommerce.Sales.Orders.PriceChanges`

## Architectural Layers

### DeepModel Layer
- **Purpose**: Rich domain model with business logic
- **Contains**: Aggregates, Value Objects, Domain Services, Policies
- **Dependencies**: Only TechnicalStuff base classes
- **Example**: `Sales.DeepModel/Orders/Order.cs`

### ProcessModel Layer  
- **Purpose**: Application services and use case orchestration
- **Contains**: Command/Query Handlers, Application Services, DTOs
- **Dependencies**: DeepModel + infrastructure abstractions
- **Example**: `Sales.ProcessModel/OnlineOrdering/PlaceOrderHandler.cs`

### Adapters Layer
- **Purpose**: Infrastructure implementations
- **Contains**: Repositories, External service clients, Database contexts
- **Dependencies**: ProcessModel + external libraries
- **Example**: `Sales.Adapters/Orders/OrderSqlRepository.cs`

### RestApi Layer
- **Purpose**: HTTP API endpoints
- **Contains**: Controllers, API models, routing
- **Dependencies**: ProcessModel for handlers
- **Example**: `Sales.RestApi/OnlineOrdering/OnlineOrderingController.cs`

## Module Organization Patterns

### Sales Module (Complex - Full DDD)
- Uses all layers (DeepModel, ProcessModel, Adapters, RestApi)
- Demonstrates Hexagonal Architecture
- Combines rich domain model with CRUD operations
- Separate processes: OnlineOrdering, WholesaleOrdering, Fulfillment

### Contacts Module (Simple - CRUD)
- Single project with minimal layers
- Entity Framework-based CRUD operations
- Simple data structures without rich behavior

### TechnicalStuff Module
- Shared infrastructure components
- Cross-cutting concerns (transactions, outbox, persistence)
- Base classes and interfaces for DDD patterns

## File Organization Within Projects

### Domain Model Files
```
Orders/
├── Order.cs              # Main aggregate
├── Order.Events.cs       # Domain events (partial class)
├── Order.Snapshot.cs     # Aggregate snapshot (partial class)
├── OrderId.cs           # Value object identifier
├── OrderHeader.cs       # CRUD data structure
└── PriceChanges/        # Sub-domain module
    ├── PriceChangesPolicy.cs
    └── AllowPriceChangesIfTotalPriceIsLower.cs
```

### Process Model Files
```
OnlineOrdering/
├── PlaceOrderHandler.cs     # Command handler
├── PriceCartHandler.cs      # Query handler
├── PlaceOrder.cs           # Command DTO
└── OrderPlaced.cs          # Event DTO
```

## Dependency Rules

1. **DeepModel**: No dependencies on infrastructure or frameworks
2. **ProcessModel**: Can depend on DeepModel + abstractions only
3. **Adapters**: Can depend on ProcessModel + external libraries
4. **RestApi**: Can depend on ProcessModel for handlers
5. **Startup**: Knows about everything, does only initialization

## Visibility Guidelines

- **Default to `internal`**: Use `public` only when truly needed across assemblies
- **Explicit interfaces**: Define clear contracts between layers
- **Minimal surface area**: Expose only what's necessary for integration