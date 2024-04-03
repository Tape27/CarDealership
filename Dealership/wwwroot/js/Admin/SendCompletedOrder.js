function markOrderAsCompleted(button) {
    if (confirm('Вы уверены, что хотите отметить этот заказ как выполненный?')) {
        var orderId = button.getAttribute('data-id');
        var row = button.closest('tr');
        fetch('/admin/api/completedorder/' + orderId, {
            method: 'POST'
        })
            .then(function () {

                row.style.opacity = '0';
                setTimeout(function () {
                    row.remove();
                }, 300);
                getNotificationCount();
            })
            .catch(function () {
                alert('Error marking order as completed.');
            });
    }
}