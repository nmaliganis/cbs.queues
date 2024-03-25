const socket = new WebSocket("ws://localhost:6001");

socket.onopen = function (e) {
    console.log("[open] Connection established");
};

socket.onmessage = function (event) {
    console.log(`[message] Data received from server: ${event.data}`);
    document.getElementById("dataDisplay").innerText = `Data received: ${event.data}`;
};

socket.onclose = function (event) {
    if (event.wasClean) {
        console.log(`[close] Connection closed cleanly, code=${event.code} reason=${event.reason}`);
    } else {
        // e.g. server process killed or network down
        console.log('[close] Connection died');
    }
};

socket.onerror = function (error) {
    console.log(`[error] ${error.message}`);
};
