document.addEventListener('DOMContentLoaded', () => {
    document.getElementById("createCarForm").addEventListener("submit", function (event) {
        event.preventDefault();

        var isValid = true;

        var name = document.getElementById("name").value;
        if (name.length < 3 || name.length > 100) {
            document.getElementById("nameError").textContent = "Длина строки должна быть не менее 3 и не более 100 символов";
            isValid = false;
        } else {
            document.getElementById("nameError").textContent = "";
        }

        var description = document.getElementById("description").value;
        if (description.length > 2000) {
            document.getElementById("descriptionError").textContent = "Длина строки не должна превышать 2000 символов";
            isValid = false;
        } else {
            document.getElementById("descriptionError").textContent = "";
        }

        var year = document.getElementById("year").value;
        if (year < 1900 || year > 2100) {
            document.getElementById("yearError").textContent = "Год выпуска должен быть в диапазоне от 1900 до 2100";
            isValid = false;
        } else {
            document.getElementById("yearError").textContent = "";
        }

        var power = document.getElementById("power").value;
        if (power > 2147483647) {
            document.getElementById("powerError").textContent = "Максимальное значение 2 147 483 647";
            isValid = false;
        } else {
            document.getElementById("powerError").textContent = "";
        }

        var price = document.getElementById("price").value;
        if (price < 0) {
            document.getElementById("priceError").textContent = "Цена должна быть положительным числом";
            isValid = false;
        } else {
            document.getElementById("priceError").textContent = "";
        }

        if (isValid) {
            this.submit();
        }
    });
});