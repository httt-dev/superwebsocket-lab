// script.js
//window.onload = function() {
//    const fileInput = document.getElementById('fileInput');
//    fileInput.addEventListener('change', handleFileSelect);
//};

document.addEventListener('DOMContentLoaded', function () {
    // Code xử lý sự kiện khi DOM được tải hoàn chỉnh
    const fileInput = document.getElementById('fileInput');
    fileInput.addEventListener('change', handleFileSelect);
});

function handleFileSelect(event) {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function(e) {
        const logContent = e.target.result;
        displayLog(logContent);

        // const parsedLogs = parseLog(logContent);
        // document.getElementById('logTimeline').innerHTML = parsedLogs;

    };

    reader.readAsText(file);
}
function displayLog(logContent) {
    const logEntries = logContent.split(/(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2},\d{3})/);
    const logTimeline = document.getElementById('logTimeline');

    let previousTimestamp = null;

    for (let i = 1; i < logEntries.length; i += 2) {
        const timestampStr = logEntries[i];
        const message = logEntries[i + 1];

        const timestamp = parseTimestamp(timestampStr);

        console.log(message)

        if (previousTimestamp) {
            const timeDiff = timestamp - previousTimestamp;
            const timeDiffStr = millisecondsToTime(timeDiff);
            const timeDiffElem = document.createElement('div');

            if (timeDiff >= 10000) {
                timeDiffElem.style.color = 'red';
            }

            timeDiffElem.textContent = `Time since last log: ${timeDiffStr}`;
            logTimeline.appendChild(timeDiffElem);
        }

        const logEntry = document.createElement('div');
        logEntry.classList.add('logEntry');

        const timestampElem = document.createElement('span');
        timestampElem.classList.add('timestamp');
        timestampElem.innerHTML = `<strong>${timestampStr}</strong>`;

        const logMessageElem = document.createElement('span');
        logMessageElem.classList.add('logMessage');
        logMessageElem.innerHTML = highlightJson(message);

        logEntry.appendChild(timestampElem);
        logEntry.appendChild(logMessageElem);

        logTimeline.appendChild(logEntry);

        previousTimestamp = timestamp;
    }
}

function highlightJson(message) {
    // Biểu thức chính quy để nhận dạng JSON
    const jsonRegex = /{(?:[^{}]|{(?:[^{}]|{[^{}]*})*})*}/g;
    const highlightedMessage = message.replace(jsonRegex, match => `<pre><code class="json">${match}</code></pre>`);
    console.log('highlightedMessage\n' + highlightedMessage)
    return highlightedMessage;
}



function parseTimestamp(timestampStr) {
    const parts = timestampStr.split(/[- : ,]/);
    return new Date(parts[0], parts[1] - 1, parts[2], parts[3], parts[4], parts[5], parts[6]);
}

function millisecondsToTime(milliseconds) {
    const seconds = Math.floor(milliseconds / 1000);
    const minutes = Math.floor(seconds / 60);
    const hours = Math.floor(minutes / 60);

    const formattedHours = pad(hours % 24);
    const formattedMinutes = pad(minutes % 60);
    const formattedSeconds = pad(seconds % 60);

    return `${formattedHours}:${formattedMinutes}:${formattedSeconds}`;
}

function pad(value) {
    return value < 10 ? '0' + value : value;
}

function parseLog(logContent) {
    const logLines = logContent.split('\n');
    let parsedLogs = '';

    let prevLogTime = null;

    function findAndParseJSON(line) {
        const startIndex = line.indexOf('{');
        if (startIndex !== -1) {
            const jsonChunk = line.slice(startIndex);
            try {
                const json = JSON.parse(jsonChunk);
                parsedLogs += line.slice(0, startIndex) + '<pre class="json">' + JSON.stringify(json, null, 2) + '</pre><br>';
            } catch (error) {
                parsedLogs += line + '<br>';
            }
        } else {
            parsedLogs += line + '<br>';
        }
    }

    function calculateTimeDifference(currentTime) {
        if (prevLogTime) {
            const timeDifference = (currentTime - prevLogTime) / 1000; // chuyển đổi sang giây
            if (timeDifference > 10) {
                parsedLogs += `<span class="error">Time Gap: ${timeDifference.toFixed(2)} seconds</span><br>`;
            } else {
                parsedLogs += `Time Gap: ${timeDifference.toFixed(2)} seconds<br>`;
            }
        }
        prevLogTime = currentTime;
    }

    logLines.forEach(line => {
        const logComponents = line.split(' | ');
        if (logComponents.length > 1) {
            const logTime = Date.parse(logComponents[0]);
            if (!isNaN(logTime)) {
                calculateTimeDifference(logTime);
            }
        }
        findAndParseJSON(line);
    });

    return parsedLogs;
}