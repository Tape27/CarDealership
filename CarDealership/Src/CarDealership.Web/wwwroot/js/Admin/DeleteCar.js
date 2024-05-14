document.addEventListener('DOMContentLoaded', () => {
    const deleteCarBtns = document.querySelectorAll('.delete-btn');

    // Добавить обработчик события "click" для каждой кнопки "Delete"
    deleteCarBtns.forEach(btn => {
        btn.addEventListener('click', async () => {
            if (confirm('Вы уверены, что хотите удалить этот автомибиль из базы данных БЕЗ ВОЗМОЖНОСТИ ВОССТАНОВЛЕНИЯ?')) {
                // Получить ID автомобиля из атрибута data-car-id
                const carId = btn.dataset.carId;

                // Отправить запрос на удаление автомобиля с помощью fetch API
                const response = await fetch(`/api/car/delete/${carId}`, {
                    method: 'DELETE'
                });

                // Проверить статус ответа
                if (response.ok) {
                    // Удаление автомобиля прошло успешно
                    // Обновить страницу или список автомобилей
                    location.reload();
                } else {
                    // Удаление автомобиля не удалось
                    // Вывести сообщение об ошибке
                    console.error('Failed to delete car');
                }

            }
        });
    });
});