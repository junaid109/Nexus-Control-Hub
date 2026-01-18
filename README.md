# Nexus Control Hub

**Nexus Control Hub** is a professional-grade LiveOps management system designed for high-performance Unity VR multiplayer games. Built with **.NET 10** and **PostgreSQL**, it serves as the central command center for game operations, moderation, and infrastructure control.

## 🚀 Key Features

*   **Operations Center**: Real-time dashboard monitoring CCU, servers, and alerts.
*   **LiveOps Management**: Player moderation, inventory control, and social graph visualization.
*   **Remote Configuration**: Feature flags and JSON-based rules engine.
*   **Asset Management**: Hot-swappable asset delivery via Azure Blob Storage.
*   **High Performance**: Built on ASP.NET Core MVC with SignalR for sub-second updates.

## 🛠️ Technology Stack

*   **Backend**: .NET 10 (ASP.NET Core MVC / Web API)
*   **Database**: PostgreSQL (Entity Framework Core)
*   **Frontend**: Razor Views + Vanilla CSS ("Glassmorphism" Design)
*   **Real-time**: Azure SignalR Service

## 📦 Getting Started

### Prerequisites

*   .NET 10 SDK
*   PostgreSQL Database

### Installation

1.  Clone the repository:
    ```bash
    git clone https://github.com/junaid109/Nexus-Control-Hub.git
    cd Nexus-Control-Hub
    ```

2.  Configure Database Credentials:
    Update `NexusControl.Web/appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=NexusControlDb;Username=postgres;Password=yourparams"
    }
    ```

3.  Apply Migrations:
    ```bash
    dotnet ef database update -p NexusControl.Infrastructure -s NexusControl.Web
    ```

4.  Run the Application:
    ```bash
    dotnet run --project NexusControl.Web
    ```

## 📄 License

Code and documentation copyright 2026 Junaid Malik.
For custom solutions or commercial usage permissions, please contact: **junaidmalik.rm@gmail.com**

## 🤝 Contact

**Junaid Malik** - [junaidmalik.rm@gmail.com](mailto:junaidmalik.rm@gmail.com)
