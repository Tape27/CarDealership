const btnOrder = document.querySelector('.btn-order');
const overlay = document.querySelector('#overlay');
const createOrderForm = document.querySelector('#createOrderForm');
const nameInput = document.querySelector('#name');
const phoneInput = document.querySelector('#phoneNumber');
const messageInput = document.querySelector('#message');
const nameError = document.querySelector('#name-error');
const phoneError = document.querySelector('#phone-error');
const messageError = document.querySelector('#message-error');

const showForm = () => {
    overlay.style.display = 'block';
};

btnOrder.addEventListener('click', showForm);

const validateAndSubmitForm = (event) => {
    event.preventDefault();

    let isValid = true;

    if (nameInput.value.length > 100) {
        nameError.textContent = 'Максимальная длина имени 100 символов';
        nameError.style.display = 'block';
        isValid = false;
    } else {
        nameError.style.display = 'none';
    }

    if (phoneInput.value.length > 25) {
        phoneError.textContent = 'Максимальная длина номера телефона 25 символов';
        phoneError.style.display = 'block';
        isValid = false;
    } else {
        phoneError.style.display = 'none';
    }

    if (messageInput.value.length > 1000) {
        messageError.textContent = 'Максимальная длина сообщения 1000 символов!';
        messageError.style.display = 'block';
        isValid = false;
    } else {
        messageError.style.display = 'none';
    }

    if (isValid) {
        const formData = new FormData(createOrderForm);
        console.log(formData);

        fetch('/api/order/create', {
            method: 'POST',
            body: formData
        })
            .then(response => {
                if (response.ok) {

                    overlay.style.display = 'none';

                    nameInput.value = '';
                    phoneInput.value = '';
                    messageInput.value = '';

                    alert('Заявка отправлена!');
                } else {
                    alert('Ошибка, некорректные данные!');
                }
            })
            .catch(error => {
                alert('Ошибка, сервер не может сейчас обработать запрос!');
            });
    }
};

overlay.addEventListener('click', (e) => {
    if (e.target === overlay) {
        overlay.style.display = 'none';
    }
});

createOrderForm.addEventListener('click', (e) => {
    e.stopPropagation();
});

createOrderForm.addEventListener('submit', validateAndSubmitForm);