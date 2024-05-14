function getNotificationCount() {
    fetch('/api/order/count/uncompleted/')
        .then(response => response.json())
        .then(count => {
            var badge = document.querySelector('.notification .badge');
            badge.textContent = count;
            if (count > 0) {
                badge.classList.remove('invisible');
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

window.onload = getNotificationCount;