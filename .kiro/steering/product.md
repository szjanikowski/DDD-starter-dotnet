# Product Overview

## What is DDD Starter for .NET

This is a **DDD (Domain-Driven Design) starter project** for .NET that demonstrates various implementation approaches for building domain-centric applications. It's designed as a learning resource and comparison tool for different DDD patterns and architectural styles.

## Key Characteristics

- **Educational Focus**: Shows different implementation options for the same requirements
- **Comparison Platform**: Demonstrates various DDD patterns (Hexagonal Architecture, CQRS, Event Sourcing, BDD)
- **Practical Examples**: Ready-made solutions that can be adapted for real projects
- **Minimal Domain**: Simplified e-commerce domain to focus on implementation techniques rather than domain complexity

## Domain Context

The project implements a simplified **e-commerce system** with the following bounded contexts:

- **Sales**: Core business logic with online and wholesale ordering processes
- **Contacts**: Customer relationship management
- **Search**: Product search and filtering
- **Payments**: Payment processing
- **ProductsDelivery**: Order fulfillment and delivery
- **RiskManagement**: Risk assessment and limits

## Architecture Philosophy

- **Screaming Architecture**: Structure reflects business domain and architectural choices
- **Selective Complexity**: Uses advanced patterns (Hexagonal Architecture) only where business complexity justifies it
- **Hybrid Approach**: Combines DDD Deep Model for complex parts with simple CRUD for straightforward operations
- **Readability First**: Code optimized for reading and understanding over brevity

## Important Disclaimers

- **Not a complete domain study**: Focuses on implementation patterns, not domain exploration
- **Simplified for learning**: Real-world complexity is intentionally reduced
- **Pattern demonstration**: Shows "how" to implement DDD, not "when" to use specific patterns
- **Technology agnostic**: Patterns can be applied with different tech stacks