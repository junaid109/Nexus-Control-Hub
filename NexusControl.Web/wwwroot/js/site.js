// NexusControl Admin Hub - Main Script

document.addEventListener('DOMContentLoaded', async () => {
    console.log('NexusControl Hub: Initialization...');

    // Initialize SignalR
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/dashboardHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ReceiveAlert", (message) => {
        console.warn(`[SERVER ALERT]: ${message}`);
        // TODO: Show toast notification
    });

    connection.on("UpdatePlayerCount", (count) => {
        console.log(`Live Player Count: ${count}`);
        const el = document.querySelector('.stat-value'); // Basic selector for demo
        if (el) el.innerText = count.toLocaleString();
    });

    try {
        await connection.start();
        console.log("🟢 SignalR Connected.");
    } catch (err) {
        console.error("🔴 SignalR Connection Error: ", err);
    }
});

