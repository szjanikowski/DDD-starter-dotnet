# Technology Stack & Build System

## Core Technologies

- **.NET 8**: Target framework for all projects
- **C# Latest**: Using modern C# features including primary constructors, nullable reference types, implicit usings
- **ASP.NET Core**: Web framework for REST APIs
- **Entity Framework Core**: ORM for relational data access
- **PostgreSQL**: Primary database (via Npgsql provider)
- **Marten**: Document database and Event Store capabilities on PostgreSQL

## Key Libraries & Frameworks

- **NoesisVision.Annotations**: Domain modeling annotations for documentation
- **Scrutor**: Assembly scanning and dependency injection
- **Newtonsoft.Json**: JSON serialization
- **System.Collections.Immutable**: Immutable collections for domain models
- **TaskTupleAwaiter**: Async/await enhancements
- **Quartz.NET**: Background job scheduling (via TechnicalStuff.Outbox.Quartz)
- **Kafka**: Message broker integration (via TechnicalStuff.Kafka)

## Build System

### NUKE Build System
- **Build Tool**: NUKE (C#-based build automation)
- **Build Scripts**: `build.sh` (Unix/macOS), `build.cmd` (Windows), `build.ps1` (PowerShell)
- **Build Project**: `Build/Nuke/Nuke.csproj`

### Common Commands

```bash
# Build the entire solution
./build.sh

# Run specific build targets (examples)
./build.sh --target Clean
./build.sh --target Restore
./build.sh --target Compile
./build.sh --target Test

# Windows equivalent
build.cmd
```

### Project Structure Commands

```bash
# Build solution
dotnet build MyCompany.ECommerce.sln

# Run main application
dotnet run --project Sources/Monolith.Startup

# Run search service
dotnet run --project Sources/Search.Startup

# Run tests
dotnet test

# Database migrations (if applicable)
dotnet run --project Sources/Sales/Sales.FluentMigrations
```

## Development Environment

- **IDE**: JetBrains Rider preferred (project includes .idea folder)
- **VS Code**: Supported (includes .vscode configuration)
- **Docker**: Used for infrastructure dependencies
- **Git**: Version control with conventional commit messages

## Testing Framework

- **xUnit**: Primary testing framework
- **BDD Toolkit**: Custom BDD testing utilities (separate project by same authors)
- **Integration Tests**: Database integration testing with real PostgreSQL

## Configuration

- **appsettings.json**: Base configuration
- **appsettings.Development.json**: Development overrides
- **User Secrets**: Sensitive configuration (UserSecretsId: "MyCompanyCrm")
- **Environment Variables**: Runtime configuration