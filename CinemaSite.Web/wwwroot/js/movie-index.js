function watchMovie(movieName, movieImage) {
    // Заповнення інформації про фільм в модальному вікні
    document.getElementById('movieTitle').textContent = movieName;
    document.getElementById('movieImage').src = movieImage; // Встановлюємо картинку
    document.getElementById('movieImage').alt = movieName; // Встановлюємо alt текст для картинки

    // Показуємо базову ціну для онлайн перегляду
    const onlineViewingPrice = 100;
    document.getElementById('onlinePrice').textContent = onlineViewingPrice;

    // Генерація місць для перегляду в кіно
    generateCinemaSeats(20); // Ось тут можна налаштувати кількість місць
    updateCinemaPrice(); // Оновлення ціни для кіно

    // Відображення модального вікна
    document.getElementById('movieModal').style.display = 'block';
}

function closeModal() {
    // Закриваємо модальне вікно
    document.getElementById('movieModal').style.display = 'none';
}

function showOnlineView() {
    // Показуємо онлайн перегляд
    document.getElementById('cinemaView').style.display = 'none';
    document.getElementById('onlineView').style.display = 'block';
}

function showCinemaView() {
    // Показуємо перегляд у кіно
    document.getElementById('onlineView').style.display = 'none';
    document.getElementById('cinemaView').style.display = 'block';
}




// Функції для генерації місць та обчислення ціни в кіно
function generateCinemaSeats(totalSeats) {
    const cinemaSeats = document.getElementById('cinemaSeats');
    cinemaSeats.innerHTML = '';

    for (let i = 1; i <= totalSeats; i++) {
        const seat = document.createElement('div');
        seat.classList.add('seat');
        seat.textContent = i;
        seat.dataset.price = getPriceForSeat(i); // Задаємо ціну для кожного місця
        seat.onclick = () => toggleSeatSelection(seat);
        cinemaSeats.appendChild(seat);
    }
}

function getPriceForSeat(seatNumber) {
    if (seatNumber <= 5) return 200; // Перші 5 місць — найдорожчі
    if (seatNumber <= 15) return 150; // Місця з 6 по 15 — середня ціна
    return 100; // Останні місця — найдешевші
}

function toggleSeatSelection(seat) {
    seat.classList.toggle('selected');
    updateCinemaPrice();
}

function updateCinemaPrice() {
    const selectedSeats = document.querySelectorAll('.seat.selected');
    let totalPrice = 0;

    selectedSeats.forEach(seat => {
        totalPrice += parseInt(seat.dataset.price);
    });

    document.getElementById('cinemaTotalPrice').textContent = totalPrice;
}

function confirmBooking() {
    const selectedSeats = Array.from(document.querySelectorAll('.seat.selected')).map(seat => seat.textContent);
    const cinemaTotalPrice = parseInt(document.getElementById('cinemaTotalPrice').textContent, 10);
    const movieTitle = document.getElementById('movieTitle').textContent;

    let message = `Ви обрали перегляд фільму "${movieTitle}".`;

    if (selectedSeats.length > 0) {
        message += ` Ви забронювали місця: ${selectedSeats.join(', ')}. Загальна ціна: ${cinemaTotalPrice} грн.`;
    }

    alert(message);
    closeModal();
}

function confirmOnlineBooking() {
    const movieTitle = document.getElementById('movieTitle').textContent;
    const onlinePrice = document.getElementById('onlinePrice').textContent;

    alert(`Ви обрали онлайн перегляд фільму "${movieTitle}". Загальна ціна: ${onlinePrice} грн.`);
    closeModal();
}
