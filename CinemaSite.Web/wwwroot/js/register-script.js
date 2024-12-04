// script.js

// Функція для перемикання видимості пароля у двох полях
function togglePasswordVisibility() {
    // Знаходимо обидва поля пароля
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirm-password');
    const toggleButton = document.getElementById('toggle-password');

    // Перевіряємо стан видимості
    const isVisible = passwordInput.type === 'text';

    // Змінюємо тип для обох полів
    const newType = isVisible ? 'password' : 'text';
    passwordInput.type = newType;
    confirmPasswordInput.type = newType;

    // Оновлюємо текст кнопки
    toggleButton.textContent = isVisible ? '👁️' : '🙈';
}

// Додаємо слухач події до кнопки
document.getElementById('toggle-password').addEventListener('click', togglePasswordVisibility);
