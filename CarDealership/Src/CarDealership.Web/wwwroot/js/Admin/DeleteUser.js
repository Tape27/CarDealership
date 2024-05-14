document.addEventListener('DOMContentLoaded', () => {
    const deleteUserBtns = document.querySelectorAll('.delete-btn');

    deleteUserBtns.forEach(btn => {
        btn.addEventListener('click', async () => {
            if (confirm('Вы уверены, что хотите удалить этого пользователя из базы данных БЕЗ ВОЗМОЖНОСТИ ВОССТАНОВЛЕНИЯ?')) {
                
                const userId = btn.dataset.userId;

               
                const response = await fetch(`/api/admin/delete/${userId}`, {
                    method: 'DELETE'
                });

                
                if (response.ok) {
                    
                    location.reload(); // обновить страницу
                } else {
                    c
                    console.error('Failed to delete user');
                }

            }
        });
    });
});