# Implementation Plan

- [x] 1. Set up Loyalty bounded context project structure
  - Create Loyalty.DeepModel project with proper references and assembly attributes
  - Create Loyalty.ProcessModel project with dependencies on DeepModel and TechnicalStuff
  - Create Loyalty.Adapters project with EF Core and infrastructure dependencies
  - Create Loyalty.RestApi project with ASP.NET Core controllers
  - _Requirements: All requirements depend on proper project structure_

- [x] 2. Implement core domain model and value objects
  - [x] 2.1 Create ClientId integration and basic value objects
    - Reference existing ClientId from Sales.DeepModel
    - Implement PointTransaction value object with transaction types and validation
    - Implement LoyaltyConfiguration value object with business rules
    - _Requirements: 1.1, 1.2, 4.1, 4.2, 4.3_
  
  - [x] 2.2 Implement LoyaltyAccount aggregate root
    - Create LoyaltyAccount aggregate with point balance management
    - Implement AwardPoints method with business rule validation
    - Implement RedeemPoints method with insufficient balance checks
    - Add ExpirePoints method for automatic point expiration
    - _Requirements: 1.1, 1.3, 3.3, 3.4, 5.1, 5.4_
  
  - [ ]* 2.3 Write unit tests for domain model
    - Test point calculation scenarios and edge cases
    - Test redemption validation and business rules
    - Test expiration logic and FIFO point usage
    - _Requirements: 1.1, 3.3, 5.4_

- [x] 3. Create repository interfaces and domain services
  - [x] 3.1 Define repository contracts in DeepModel
    - Create LoyaltyAccountRepository interface with async methods
    - Create LoyaltyConfigurationRepository interface for admin settings
    - Add domain service interfaces for point calculation and expiration
    - _Requirements: 2.1, 4.1, 5.1_
  
  - [x] 3.2 Implement domain services for business logic
    - Create PointCalculationService with configurable ratios
    - Create ExpirationPolicyService with FIFO redemption logic
    - Add validation services for configuration changes
    - _Requirements: 1.2, 4.1, 4.2, 5.4_

- [x] 4. Implement process model layer with commands and queries
  - [x] 4.1 Create command and event DTOs
    - Define AwardPoints, RedeemPoints, and UpdateConfiguration commands
    - Create PointsAwarded, PointsRedeemed domain events
    - Add query DTOs for balance and transaction history
    - _Requirements: 1.1, 3.1, 4.1_
  
  - [x] 4.2 Implement command handlers for point operations
    - Create AwardPointsHandler for processing payment events
    - Create RedeemPointsHandler for checkout point redemption
    - Create UpdateLoyaltyConfigurationHandler for admin operations
    - _Requirements: 1.1, 1.3, 3.2, 3.3, 4.1, 4.2_
  
  - [x] 4.3 Implement query handlers for data retrieval
    - Create GetLoyaltyBalanceHandler with transaction history
    - Create GetLoyaltyReportsHandler for administrative analytics
    - Add pagination support for transaction history queries
    - _Requirements: 2.1, 2.2, 2.4, 6.1, 6.2, 6.3_
  
  - [ ]* 4.4 Write unit tests for process model handlers
    - Test command handler business logic and validation
    - Test query handler data transformation and pagination
    - Test error scenarios and exception handling
    - _Requirements: 1.1, 2.1, 3.3_

- [ ] 5. Implement database persistence layer
  - [ ] 5.1 Create Entity Framework DbContext and entities
    - Create LoyaltyDbContext with proper entity configurations
    - Define database entities for accounts, transactions, and configuration
    - Add Entity Framework value converters for domain value objects
    - _Requirements: 2.1, 2.3, 4.4_
  
  - [ ] 5.2 Implement repository concrete classes
    - Create LoyaltyAccountSqlRepository with optimized queries
    - Create LoyaltyConfigurationSqlRepository for admin settings
    - Add proper error handling and transaction management
    - _Requirements: 2.1, 2.2, 4.1, 4.4_
  
  - [ ] 5.3 Create database migrations
    - Generate EF Core migrations for loyalty tables
    - Add indexes for performance on ClientId and transaction queries
    - Include seed data for default loyalty configuration
    - _Requirements: 2.1, 4.1_
  
  - [ ]* 5.4 Write integration tests for data access
    - Test repository implementations against real database
    - Test transaction handling and concurrent access scenarios
    - Test migration scripts and seed data
    - _Requirements: 2.1, 4.1_

- [ ] 6. Implement event integration with Sales context
  - [ ] 6.1 Create event handlers for Sales integration
    - Create PaymentEventHandler to subscribe to PaymentRequestFulfilled events
    - Implement event processing logic to trigger point awarding
    - Add error handling and retry mechanisms for event processing
    - _Requirements: 1.1, 1.2, 1.5_
  
  - [ ] 6.2 Implement outbox pattern for loyalty events
    - Create LoyaltyEventOutbox using existing TechnicalStuff infrastructure
    - Configure event publishing for PointsAwarded and PointsRedeemed events
    - Add partition key strategy for event ordering
    - _Requirements: 1.4, 3.5, 6.4_
  
  - [ ]* 6.3 Write integration tests for event processing
    - Test end-to-end event flow from Sales to Loyalty
    - Test event ordering and duplicate handling
    - Test failure scenarios and retry mechanisms
    - _Requirements: 1.1, 1.5_

- [ ] 7. Create REST API controllers and endpoints
  - [ ] 7.1 Implement LoyaltyController for customer operations
    - Create GET endpoint for loyalty balance and transaction history
    - Create POST endpoint for point redemption during checkout
    - Add proper request validation and error response formatting
    - _Requirements: 2.1, 2.2, 3.1, 3.2_
  
  - [ ] 7.2 Implement LoyaltyConfigurationController for admin operations
    - Create GET endpoint for current loyalty configuration
    - Create PUT endpoint for updating loyalty rules and ratios
    - Add authorization checks for administrative operations
    - _Requirements: 4.1, 4.2, 4.3, 4.4_
  
  - [ ] 7.3 Add API documentation and validation
    - Configure Swagger/OpenAPI documentation for all endpoints
    - Add request/response models with proper validation attributes
    - Implement consistent error response format across all endpoints
    - _Requirements: 2.1, 3.1, 4.1_
  
  - [ ]* 7.4 Write API integration tests
    - Test HTTP endpoints with various input scenarios
    - Test authentication and authorization for admin endpoints
    - Test error response formats and status codes
    - _Requirements: 2.1, 3.1, 4.1_

- [ ] 8. Implement point expiration background processing
  - [ ] 8.1 Create scheduled job for point expiration
    - Create ExpirePointsJob using existing Quartz.NET infrastructure
    - Implement batch processing for expired points cleanup
    - Add logging and monitoring for expiration job execution
    - _Requirements: 5.1, 5.2, 5.3_
  
  - [ ] 8.2 Add customer notification system for expiring points
    - Create notification service for points expiring in 30 days
    - Implement email/message templates for expiration warnings
    - Add customer preference management for notifications
    - _Requirements: 5.2_
  
  - [ ]* 8.3 Write tests for background processing
    - Test expiration job logic and batch processing
    - Test notification delivery and customer preferences
    - Test job scheduling and error recovery
    - _Requirements: 5.1, 5.2, 5.3_

- [ ] 9. Add dependency injection and startup configuration
  - [ ] 9.1 Configure services in Monolith.Startup
    - Register Loyalty bounded context services in DI container
    - Configure database connection and Entity Framework context
    - Add event handler registrations for Sales integration
    - _Requirements: All requirements depend on proper DI setup_
  
  - [ ] 9.2 Add configuration settings and validation
    - Create configuration section for loyalty settings in appsettings
    - Add configuration validation for required loyalty parameters
    - Implement configuration hot-reload for runtime updates
    - _Requirements: 4.1, 4.2, 4.3_
  
  - [ ] 9.3 Configure API routing and middleware
    - Add loyalty API routes to existing API configuration
    - Configure authentication and authorization middleware
    - Add request/response logging and error handling middleware
    - _Requirements: 2.1, 3.1, 4.1_

- [ ] 10. Implement reporting and analytics features
  - [ ] 10.1 Create loyalty program metrics and reports
    - Implement queries for total points issued and redeemed over time
    - Create customer participation rate calculations
    - Add average points per customer and redemption rate metrics
    - _Requirements: 6.1, 6.2, 6.3_
  
  - [ ] 10.2 Add expired points tracking and optimization reports
    - Track expired points for program effectiveness analysis
    - Create reports correlating loyalty participation with retention
    - Add configurable date ranges and filtering for reports
    - _Requirements: 6.4, 6.5_
  
  - [ ]* 10.3 Write tests for reporting functionality
    - Test report calculations with various data scenarios
    - Test date range filtering and aggregation logic
    - Test performance with large datasets
    - _Requirements: 6.1, 6.2, 6.3_