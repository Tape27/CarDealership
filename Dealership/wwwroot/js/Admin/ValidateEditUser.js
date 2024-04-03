document.addEventListener('DOMContentLoaded', () => {
    document.getElementById("editUserForm").addEventListener("submit", function (event) {
        event.preventDefault();

        var isValid = true;

        var fullName = document.getElementById("FullName").value;
        if (fullName.length < 10) {
            document.getElementById("FullNameError").textContent = "Длина строки должна быть не менее 10 символов";
            isValid = false;
        } else {
            document.getElementById("FullNameError").textContent = "";
        }

        var login = document.getElementById("Login").value;
        if (login.length < 7) {
            document.getElementById("LoginError").textContent = "Длина строки должна быть не менее 7 символов";
            isValid = false;
        } else {
            document.getElementById("LoginError").textContent = "";
        }

        var password = document.getElementById("Password").value;
        if (password.length > 0 && password.length < 7) {
            document.getElementById("PasswordError").textContent = "Длина строки должна быть не менее 7 символов";
            isValid = false;
        } else {
            document.getElementById("PasswordError").textContent = "";
        }

        if (isValid) {
            this.submit();
        }
    });
});