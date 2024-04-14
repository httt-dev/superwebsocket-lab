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
    //const file = event.target.files[0];
    //const reader = new FileReader();

    //reader.onload = function(e) {
    //    const logContent = e.target.result;
    //    displayLog(logContent);

    //    // const parsedLogs = parseLog(logContent);
    //    // document.getElementById('logTimeline').innerHTML = parsedLogs;

    //};

    //reader.readAsText(file);

    applyFilter(); // Áp dụng bộ lọc khi người dùng chọn tệp
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

function applyFilter() {
    const startDate = new Date(document.getElementById('startDate').value);
    const endDate = new Date(document.getElementById('endDate').value);

    const logTimeline = document.getElementById('logTimeline');
    logTimeline.innerHTML = ''; // Xóa log hiện tại trên giao diện trước khi áp dụng bộ lọc

    // Hiển thị log phù hợp với khoảng thời gian lọc
    displayFilteredLog(startDate, endDate);
}
function displayFilteredLog(startDate, endDate) {
    const fileInput = document.getElementById('fileInput');
    const file = fileInput.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
        const logContent = e.target.result;
        const logEntries = logContent.split(/(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2},\d{3})/);

        let previousTimestamp = null;

        for (let i = 1; i < logEntries.length; i += 2) {
            const timestampStr = logEntries[i];
            const message = logEntries[i + 1];

            const timestamp = parseTimestamp(timestampStr);

            const startDateLogFormat = parseTimestamp(convertToLogDateTime(startDate));
            const endDateLogFormat = parseTimestamp(convertToLogDateTime(endDate));

            console.log('startDateLogFormat : ' + startDateLogFormat);
            console.log('endDateLogFormat : ' + endDateLogFormat);

            if (timestamp >= startDateLogFormat && timestamp <= endDateLogFormat) {
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
                //logEntry.classList.add('logEntry');

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
    };

    reader.readAsText(file);
}

function convertToLogDateTime(dateTimeStr) {
    const date = new Date(dateTimeStr);
    const year = date.getFullYear();
    const month = padWithZero(date.getMonth() + 1);
    const day = padWithZero(date.getDate());
    const hours = padWithZero(date.getHours());
    const minutes = padWithZero(date.getMinutes());
    const seconds = padWithZero(date.getSeconds());
    const milliseconds = padWithZero(date.getMilliseconds(), 3);
    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds},${milliseconds}`;
}

function padWithZero(value, length = 2) {
    return String(value).padStart(length, '0');
}

