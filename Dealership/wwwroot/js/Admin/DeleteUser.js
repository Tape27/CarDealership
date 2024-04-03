document.addEventListener('DOMContentLoaded', () => {
    const deleteUserBtns = document.querySelectorAll('.delete-btn');

    // Добавить обработчик события "click" для каждой кнопки "Delete"
    deleteUserBtns.forEach(btn => {
        btn.addEventListener('click', async () => {
            if (confirm('Вы уверены, что хотите удалить этого пользователя из базы данных БЕЗ ВОЗМОЖНОСТИ ВОССТАНОВЛЕНИЯ?')) {
                // Получить ID user из атрибута data-user-id
                const userId = btn.dataset.userId;

                // Отправить запрос на удаление user с помощью fetch API
                const response = await fetch(`/admin/api/deleteuser/${userId}`, {
                    method: 'DELETE'
                });

                // Проверить статус ответа
                if (response.ok) {
                    // Удаление user прошло успешно
                    // Обновить страницу или список user
                    location.reload();
                } else {
                    // Удаление user не удалось
                    // Вывести сообщение об ошибке
                    console.error('Failed to delete user');
                }

            }
        });
    });
});