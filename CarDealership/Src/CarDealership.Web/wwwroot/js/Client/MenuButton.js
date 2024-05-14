function toggleMenu() {
    var nav = document.getElementById("nav");
    var phone = document.getElementById("phone");
    var computedStyle = getComputedStyle(nav);

    // проверяем, установлено ли свойство display для элемента nav в CSS-стилях
    if (computedStyle.display === "none") {
        nav.style.display = "flex";
        phone.style.display = "none";
    } else if (computedStyle.display === "flex") {
        nav.style.display = "none";
        phone.style.display = "flex";
    } else {
        // свойство display не установлено, устанавливаем его в значение flex
        nav.style.display = "flex";
        phone.style.display = "none";
    }
}