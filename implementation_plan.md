# NexusControl Admin Hub - Implementation Plan

## Project Overview
NexusControl Admin Hub (Nexus Control) is a professional-grade LiveOps management system for a live Unity VR multiplayer game. It focuses on high availability, remote content delivery, and real-time player management using .NET 10, PostgreSQL, and Azure.

## Phase 1: Foundation & Architecture
- [x] **Solution Setup**: Initialize .NET 10 Solution with MVC Web Project and Core Class Libraries.
    - `NexusControl.Web` (ASP.NET Core MVC + API)
    - `NexusControl.Core` (Domain entities, Interfaces)
    - `NexusControl.Infrastructure` (Data access, Azure integrations)
- [x] **Database Configuration**:
    - Configure PostgreSQL connection (Npgsql).
    - Setup Entity Framework Core.
    - Implement initial schema (FeatureFlags, GameAssets).
    - *Note: Connection string in appsettings.json needs valid credentials.*
- [ ] **Authentication**:
    - Setup Identity (Local dev) preparing for Azure AD integration.
    - Create Admin Roles.

## Phase 2: Core Modules
- [x] **Dashboard UI**:
    - Create a high-end, dark-mode "Glassmorphism" layout using Vanilla CSS.
    - Implement sidebar navigation and responsive header.
- [x] **Real-time Monitoring Foundation**:
    - SignalR Hub created and registered.
    - Client-side connection script added.
- [ ] **Feature Flags & Remote Config**:
    - Implement `FeatureFlags` CRUD.
    - Create API endpoint for Unity client polling.
- [ ] **Content Delivery**:
    - Create Asset Management UI (Upload/List).
    - Implement `GameAssets` service (Azure Blob storage abstraction).
    - Generate `version.json` logic.

## Phase 3: Player & Social Management (LiveOps)
- [ ] **Player Inventory & Moderation**:
    - Create Player read-only views (Mock data for now, connected to DB).
    - Implement Ban/Kick/Mute actions (SignalR triggers).
- [ ] **Real-time Monitoring**:
    - Integrate Azure SignalR (or local mock) for live updates.
    - "Live Room" visualization (basic list or 2D map).

## Phase 4: Operations & Analytics
- [ ] **Infrastructure Control**:
    - Mock interface for Server Scale/Orchestration.
- [ ] **Analytics Interface**:
    - Integration of dummy charts (Grafana/Prometheus style) for system health.

## Technology Stack
- **Framework**: .NET 10 (ASP.NET Core MVC)
- **Database**: PostgreSQL
- **Frontend**: Razor Views + Vanilla CSS + SignalR Client (JS)
- **Cloud**: Azure (Services abstracted for dev)

## Next Steps
1. Initialize the .NET solution.
2. Setup the basic MVC project structure.
3. Apply the "Premium" CSS theme.

