function watchMovie(movieName, moviePrice) {
    // Заповнення інформації про фільм в модальному вікні
    document.getElementById('movieTitle').textContent = movieName;
    document.getElementById('moviePrice').textContent = `Ціна: ${moviePrice}`;

    // Показуємо модальне вікно
    document.getElementById('movieModal').style.display = 'block';
}

function closeModal() {
    // Закриваємо модальне вікно
    document.getElementById('movieModal').style.display = 'none';
}

function scrollCarousel(category, direction) {
    const container = document.getElementById(category);
    const scrollAmount = direction * 200; // Налаштуйте прокрутку
    container.scrollLeft += scrollAmount;
}

document.getElementById('viewType').addEventListener('change', function () {
    const seatSelection = document.getElementById('seatSelection');
    if (this.value === 'cinema') {
        seatSelection.style.display = 'block';  // Показываем выбор места при виборі кіно
    } else {
        seatSelection.style.display = 'none';  // Ховаємо вибір місця при виборі онлайн перегляду
    }
});

function confirmBooking() {
    const viewType = document.getElementById('viewType').value;
    const seat = document.getElementById('seat').value;
    const movieTitle = document.getElementById('movieTitle').textContent;

    let message = `Ви обрали перегляд фільму "${movieTitle}"`;

    if (viewType === 'cinema') {
        message += ` в кіно, місце №${seat}.`;
    } else {
        message += ' онлайн.';
    }

    alert(message);
    closeModal(); // Закриваємо модальне вікно після підтвердження
}
